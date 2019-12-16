using AutoMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Common.Types.MessagesQueu;
using ReverseMarketPlace.Demands.Core.Constants;
using ReverseMarketPlace.Demands.Core.Domain;
using ReverseMarketPlace.Demands.Core.Exceptions;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using ReverseMarketPlace.Demands.Core.Messages.Events;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Core.UseCases.Demands;
using ReverseMarketPlace.Demands.Core.UseCases.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Handlers.Demands
{
    // <summary>
    /// Handler for create demand commands
    /// </summary>
    public sealed class CreateDemandHandler : BaseCommandHandler<CreateDemandHandler>, ICommandHandler<CreateDemand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttributesBelongToProductTypeUseCase _attributesBelongToProductTypeUseCase;
        private readonly ICheckDuplicatedDemandUseCase _checkDuplicatedDemandUseCase;
        private readonly IBusPublisher _busPublisher;

        public CreateDemandHandler(IUnitOfWork unitOfWork, IAttributesBelongToProductTypeUseCase attributesBelongToProductTypeUseCase,
            ICheckDuplicatedDemandUseCase checkDuplicatedDemandUseCase, IBusPublisher busPublisher, IStringLocalizer<CreateDemandHandler> localizer, 
            ILogger<CreateDemandHandler> logger, IMapper mapper) : base(localizer, logger, mapper)
        {
            _unitOfWork = unitOfWork;
            _attributesBelongToProductTypeUseCase = attributesBelongToProductTypeUseCase;
            _checkDuplicatedDemandUseCase = checkDuplicatedDemandUseCase;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(CreateDemand command, ICorrelationContext context)
        {
            if (command.Quantity <= 0)
                throw new QuantityMustBeGreaterThanZeroException(_localizer[ExceptionConstants.QuantityMustBeGreaterThanZero]);

            // We get the product type by id and if it doesn't exist we throw exception
            var productType = await _unitOfWork.ProductTypesRepository.GetByIdAsync(command.ProductTypeId);
            if (productType.IsNull())
                throw new ProductTypeNotFoundException(_localizer[ExceptionConstants.ProductTypeNotFound]);

            ICollection<AttributeValue> attributes = new List<AttributeValue>();
            // If there are attributes to process
            if (command.Attributes.IsNotNull())
            {
                // We check if the attributes added to the demand belongs to the product type
                var attributesBelongToProductTypeResult = await _attributesBelongToProductTypeUseCase.ExecuteAsync(productType, command.Attributes.Keys);
                if (!attributesBelongToProductTypeResult)
                    throw new ProductTypeAttributeNotFoundException(_localizer[ExceptionConstants.ProductTypeAttributeNotFound]);

                // For each attribute in the demand
                foreach (var demandAttribute in command.Attributes)
                {
                    // We previously checked that all demand attributes belong to the product type, so we can get them with trust from the product type
                    var attribute = productType.Attributes.SingleOrDefault(attr => attr.Id == demandAttribute.Key);
                    attributes.Add(new AttributeValue(attribute, demandAttribute.Value));
                }
            }

            // We create the demand
            Demand newDemand = new Demand(command.Id, command.BuyerId, command.ProductTypeId, command.Quantity, attributes);

            // We get all the buyer demands. TODO: Only retrieve active demands.
            var buyerDemands = await _unitOfWork.DemandsRepository.GetBuyerDemands(command.BuyerId);

            // We check if the demand is duplicated for the buyer
            var isDemandDuplicated = await _checkDuplicatedDemandUseCase.ExecuteAsync(buyerDemands, newDemand);
            if (isDemandDuplicated)
                throw new DuplicatedDemandException(_localizer[ExceptionConstants.DuplicatedDemand]);

            // We persist the new demand
            await _unitOfWork.DemandsRepository.AddAsync(newDemand);

            // We publish demand created event
            await _busPublisher.PublishAsync(new DemandCreated(command.Id, command.BuyerId, command.ProductTypeId, 
                command.Quantity, command.Attributes), context);
        }
    }
}
