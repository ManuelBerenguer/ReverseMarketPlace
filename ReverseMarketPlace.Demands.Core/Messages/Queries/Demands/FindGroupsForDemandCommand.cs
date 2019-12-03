using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.Demands
{
    /// <summary>
    /// Command to find groups for a demand
    /// </summary>
    public class FindGroupsForDemandCommand : IRequest<FindGroupsForDemandResult>
    {
        /// <summary>
        /// Id of the demand to find groups for
        /// </summary>
        public int DemandId { get; set; }

        public FindGroupsForDemandCommand(int demandId)
        {
            DemandId = demandId;
        }
    }
}
