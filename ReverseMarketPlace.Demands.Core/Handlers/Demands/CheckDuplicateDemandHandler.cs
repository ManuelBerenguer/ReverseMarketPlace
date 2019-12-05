using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Demands.Core.Dtos;
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
    public class CheckDuplicateDemandHandler : BaseCommandHandler<CheckDuplicateDemandHandler>, IRequestHandler<CheckDuplicateDemandCommand, CheckDuplicateDemandResult>
    {
        private readonly IUnitOfWorkOld _unitOfWork;

        public CheckDuplicateDemandHandler(
            IUnitOfWorkOld unitOfWork, IStringLocalizer<CheckDuplicateDemandHandler> localizer, ILogger<CheckDuplicateDemandHandler> logger, IMapper mapper) : base(localizer, logger, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Checks if a buyer's potential demand could be duplicated
        /// </summary>
        /// <param name="request">Buyer reference and potential demand properties</param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if duplicated demand, false otherwise. </returns>
        public async Task<CheckDuplicateDemandResult> Handle(CheckDuplicateDemandCommand request, CancellationToken cancellationToken)
        {
            // We get all the demands for the buyer
            var buyerDemands = await _unitOfWork.DemandsRepository.GetBuyerDemandsWithCategoryAndAttributes(request.BuyerReference);

            // For each buyer's demand
            foreach(var demand in buyerDemands)
            {
                // If both demands correspond to the same category
                if(demand.Category.Id == request.CategoryId)
                {
                    // Both attribute collections are not null
                    if(request.Attributes.IsNotNull() && demand.DemandAttributes.IsNotNull())
                    {
                        // We check the attributes length of both demands
                        if (request.Attributes.Count == demand.DemandAttributes.Count)
                        {
                            var attributesIdSortedToCheck = request.Attributes.Keys.OrderBy(key => key);
                            var attributesIdSortedToCompareWith = demand.DemandAttributes.Select(attr => attr.Attribute.Id);

                            for (int i = 0; i < attributesIdSortedToCheck.Count(); i++)
                            {
                                if (attributesIdSortedToCheck.ElementAt(i) != attributesIdSortedToCompareWith.ElementAt(i))
                                {
                                    // Different attributes found, so is not duplicated, we continue with next demand
                                    break;
                                }
                                else
                                {
                                    // TODO: Compare value
                                }
                            }

                            return new CheckDuplicateDemandResult() { Duplicated = _mapper.Map<DemandDto>(demand) };
                        }
                    }
                    else
                    {
                        // Both attribute collections are null and both demands have the same category so is duplicated
                        if(request.Attributes.IsNull() && demand.DemandAttributes.IsNull())
                            return new CheckDuplicateDemandResult() { Duplicated = _mapper.Map<DemandDto>(demand) };
                    }
                }
            }

            return new CheckDuplicateDemandResult() { Duplicated = null }; // Not duplicated demand
        }
    }
}
