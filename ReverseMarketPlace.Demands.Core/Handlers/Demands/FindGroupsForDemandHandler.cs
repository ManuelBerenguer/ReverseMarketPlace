using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Demands.Core.Constants;
using ReverseMarketPlace.Demands.Core.Dtos;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Exceptions;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using ReverseMarketPlace.Demands.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Handlers.Demands
{
    public class FindGroupsForDemandHandler : BaseCommandHandler<FindGroupsForDemandHandler>, IRequestHandler<FindGroupsForDemandCommand, FindGroupsForDemandResult>
    {
        private readonly IUnitOfWorkOld _unitOfWork;

        public FindGroupsForDemandHandler(IUnitOfWorkOld unitOfWork, IStringLocalizer<FindGroupsForDemandHandler> localizer, 
            ILogger<FindGroupsForDemandHandler> logger, IMapper mapper) : base(localizer, logger, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FindGroupsForDemandResult> Handle(FindGroupsForDemandCommand request, CancellationToken cancellationToken)
        {
            // We get the demand by id and if the demand doesn't exist we throw exception
            var demand = await _unitOfWork.DemandsRepository.GetDemandByIdWithCategoryAndAttributes(request.DemandId);
            if (demand.IsNull())
                throw new DemandNotFoundException(_localizer[ExceptionConstants.DemandNotFound]);

            // We get the groups that already exist for the category's demand and, if the category does not have any group we create a new group just for this demand
            var groupsCategory = await _unitOfWork.GroupRepository.GetGroupsByCategoryWithDemands(demand.Category.Id);
            if (groupsCategory.EmptyOrNull())
            {
                // We create the new group for the category
                var newGroup = new Group(demand);

                await _unitOfWork.GroupRepository.AddAsync(newGroup);

                // We persist the changes
                await _unitOfWork.SaveChangesAsync();
                                
                // We return a list of groups including only the group just created for the demand (the group only contains the requested demand)
                return new FindGroupsForDemandResult(null, new List<GroupDto>() {
                    _mapper.Map<GroupDto>(newGroup)
                });
            } 

            // There are groups available for the category of the demand. We need to select the most appropriate. 

            
            return null;
        }
    }
}
