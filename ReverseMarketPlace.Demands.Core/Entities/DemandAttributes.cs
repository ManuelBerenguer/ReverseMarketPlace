using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class DemandAttributes : BaseEntity
    {
        [Required]
        public Demand Demand { get; private set; }

        [Required]
        public Attribute Attribute { get; private set; }

        public string StringValue { get; private set; }
        public double? NumericValue { get; private set; }
        public DateTime? DateValue { get; private set; }

        private DemandAttributes() { }

        public DemandAttributes(Demand demand, Attribute attribute, string sValue, double? nValue, DateTime? dValue)
        {
            Demand = demand;
            Attribute = attribute;
            StringValue = sValue;
            NumericValue = nValue;
            DateValue = dValue;
        }
    }
}
