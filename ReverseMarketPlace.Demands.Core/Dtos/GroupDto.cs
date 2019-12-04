using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Dtos
{
    public class GroupDto : BaseDto
    {
        ///// <summary>
        ///// Collection of the demands that are already included in this group
        ///// </summary>
        ////public DemandDto Demand { get; set; } 

        /// <summary>
        /// Number of demands included in the group
        /// </summary>
        public int NumberOfDemands { get; set; }

        public GroupDto(int numberOfDemands)
        {
            NumberOfDemands = numberOfDemands;
        }
    }
}
