using ReverseMarketPlace.Demands.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.Demands
{
    public class CheckDuplicateDemandResult
    {
        /// <summary>
        /// The demand previously created that it's the same that the one to create
        /// </summary>
        public DemandDto Duplicated { get; set; }
    }
}
