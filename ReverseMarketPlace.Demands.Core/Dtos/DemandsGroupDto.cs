using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Dtos
{
    public class DemandsGroupDto : BaseDto
    {
        /// <summary>
        /// Collection of the demands that already included in this group
        /// </summary>
        public IEnumerable<DemandDto> Demands { get; set; } 
    }
}
