using ReverseMarketPlace.Demands.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.Demands
{
    public class FindGroupsForDemandResult
    {
        /// <summary>
        /// All the suitable groups for the demand. The demand is not included in any of these groups, but could be if the demander consider it.
        /// </summary>
        public IEnumerable<GroupDto> SuitableDemandGroups { get; set; }

        /// <summary>
        /// All the groups where the demand is already included.
        /// </summary>
        public IEnumerable<GroupDto> DemandGroups { get; set; }

        public FindGroupsForDemandResult(IEnumerable<GroupDto> suitableDemandGroups, IEnumerable<GroupDto> demandGroups)
        {
            SuitableDemandGroups = SuitableDemandGroups;
            DemandGroups = demandGroups;
        }
    }
}
