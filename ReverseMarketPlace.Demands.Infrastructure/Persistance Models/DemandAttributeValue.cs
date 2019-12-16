using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models
{
    public class DemandAttributeValue : BaseEntity
    {
        public Demand Demand { get; set; }
        public Attribute Attribute { get; set; }
        public object Value { get; set; }

        private DemandAttributeValue() { }
    }
}
