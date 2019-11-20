using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Dtos
{
    public class DemandDto : BaseDto
    {
        public string Category { get; set; }
        public float Quantity { get; set; }
        public string Status { get; set; }
    }
}
