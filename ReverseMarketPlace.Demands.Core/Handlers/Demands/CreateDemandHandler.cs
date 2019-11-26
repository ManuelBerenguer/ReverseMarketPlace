using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Handlers;
using ReverseMarketPlace.Demands.Core.Constants;
using ReverseMarketPlace.Demands.Core.Dtos;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Exceptions;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using ReverseMarketPlace.Demands.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Handlers.Demands
{
    /// <summary>
    /// Handler for create demand commands
    /// </summary>
    public sealed class CreateDemandHandler : BaseCommandHandler<CreateDemandHandler>, IRequestHandler<CreateDemandCommand, CreateDemandResult>
    {        
        private readonly IUnitOfWork _unitOfWork;

        public CreateDemandHandler(            
            IUnitOfWork unitOfWork, IStringLocalizer<CreateDemandHandler> localizer, ILogger<CreateDemandHandler> logger, IMapper mapper) : base(localizer, logger, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateDemandResult> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        {            
            if (request.Quantity <= 0)
                throw new QuantityMustBeGreaterThanZeroException(_localizer[ExceptionConstants.QuantityMustBeGreaterThanZero]);

            // We get the category by id and if the category doesn't exist we throw exception
            var category = await _unitOfWork.CategoriesRepository.GetByIdAsync(request.CategoryId);
            if (category.IsNull())
                throw new CategoryNotFoundException(_localizer[ExceptionConstants.CategoryNotFound]);

            // The demand to be created
            var newDemand = new Demand(request.BuyerReference, category, request.Quantity);

            // We get all the demands for this buyer
            var buyerDemands = await _unitOfWork.DemandsRepository.GetBuyerDemands(request.BuyerReference);

            // The user can not create a demand exactly like another previously created by himself
            var duplicatedDemand = buyerDemands.FirstOrDefault( d => d.Equals(newDemand) );
            if (!duplicatedDemand.IsNull())
                return new CreateDemandResult(null, _mapper.Map<DemandDto>(duplicatedDemand));
            else
            {
                await _unitOfWork.DemandsRepository.AddAsync(newDemand);
                return new CreateDemandResult(_mapper.Map<DemandDto>(newDemand), null);
            }
        }       
    }
}
