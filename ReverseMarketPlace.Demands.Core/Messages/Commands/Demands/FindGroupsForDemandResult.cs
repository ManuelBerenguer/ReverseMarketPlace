using ReverseMarketPlace.Demands.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.Demands
{
    public class FindGroupsForDemandResult
    {
        /// <summary>
        /// All the suitable groups for the demand
        /// </summary>
        public IEnumerable<DemandsGroupDto> DemandGroups { get; set; }

        public FindGroupsForDemandResult(IEnumerable<DemandsGroupDto> demandGroups)
        {
            DemandGroups = demandGroups;
        }
    }
}
