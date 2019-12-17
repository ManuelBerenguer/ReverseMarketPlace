using ReverseMarketPlace.Common.Extensions;
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
        public Boolean? BooleanValue { get; private set; }

        private DemandAttributes() { }

        public DemandAttributes(Demand demand, Attribute attribute)
        {
            Demand = demand;
            Attribute = attribute;
        }

        public DemandAttributes(Demand demand, Attribute attribute, object value)
        {
            if(demand.IsNull())
                throw new ArgumentNullException(nameof(demand));

            if (attribute.IsNull())
                throw new ArgumentNullException(nameof(attribute));

            if (value.IsNull())
                throw new ArgumentNullException(nameof(value));

            Demand = demand;
            Attribute = attribute;

            SetValue(value);
        }

        public void SetValue(object value)
        {
            switch(Attribute.DataTypeId)
            {
                case Enums.Demands.AttributeDataTypeEnum.BoleanValue:
                    BooleanValue = (bool)value; // TODO: Handle cast exception
                    break;
                case Enums.Demands.AttributeDataTypeEnum.StringValue:
                    StringValue = (string)value; // TODO: Handle cast exception
                    break;
                case Enums.Demands.AttributeDataTypeEnum.NumericValue:
                    NumericValue = Convert.ToDouble(value); // TODO: Handle cast exception
                    break;
                case Enums.Demands.AttributeDataTypeEnum.DateValue:
                    DateValue = (DateTime)value; // TODO: Handle cast exception
                    break;
            }                 
        }
    }
}
