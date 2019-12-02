using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ReverseMarketPlace.Common.Handlers;
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
    public class CheckDuplicateDemandHandler : BaseCommandHandler<CheckDuplicateDemandHandler>, IRequestHandler<CheckDuplicateDemandCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckDuplicateDemandHandler(
            IUnitOfWork unitOfWork, IStringLocalizer<CheckDuplicateDemandHandler> localizer, ILogger<CheckDuplicateDemandHandler> logger, IMapper mapper) : base(localizer, logger, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Checks if a buyer's potential demand could be duplicated
        /// </summary>
        /// <param name="request">Buyer reference and potential demand properties</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(CheckDuplicateDemandCommand request, CancellationToken cancellationToken)
        {
            // We get all the demands for the buyer
            var buyerDemands = await _unitOfWork.DemandsRepository.GetBuyerDemands(request.BuyerReference, d => d.Category, d => d.DemandAttributes);

            // For each buyer's demand
            foreach(var demand in buyerDemands)
            {
                // If both demands correspond to the same category
                if(demand.Category.Id == request.CategoryId)
                {
                    // We check the attributes length of both demands
                    if(request.Attributes.Count == demand.DemandAttributes.Count)
                    {
                        var attributesIdSortedToCheck = request.Attributes.Keys.OrderBy(key => key);
                        var attributesIdSortedToCompareWith = demand.DemandAttributes.Select(attr => attr.Attribute.Id);

                        for(int i=0; i < attributesIdSortedToCheck.Count(); i++)
                        {
                            // If same attribute id
                            if (attributesIdSortedToCheck.ElementAt(i) == attributesIdSortedToCompareWith.ElementAt(i))
                            {
                            }
                            else
                                return false;
                        }                                                
                    }
                }
            }

            return false;
        }
    }
}
