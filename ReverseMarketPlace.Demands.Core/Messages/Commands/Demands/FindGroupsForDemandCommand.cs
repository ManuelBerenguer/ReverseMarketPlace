using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.Demands
{
    /// <summary>
    /// Command to find groups for a demand
    /// </summary>
    public class FindGroupsForDemandCommand : IRequest<FindGroupsForDemandResultResult>
    {
        /// <summary>
        /// Id of the demand to find groups for
        /// </summary>
        public int Id { get; set; }

        public FindGroupsForDemandCommand(int id)
        {
            Id = id;
        }
    }
}
