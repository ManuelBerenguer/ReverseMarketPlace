using ReverseMarketPlace.Demands.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.Demands
{
    public class CreateDemandResult
    {
        /// <summary>
        /// The demand created
        /// </summary>
        public DemandDto Created { get; set; }

        /// <summary>
        /// The demand previously created that it's the same that the one to create
        /// </summary>
        public DemandDto Duplicated { get; set; }

        public CreateDemandResult(DemandDto created, DemandDto duplicated)
        {
            Created = created;
            Duplicated = duplicated;
        }
    }
}
