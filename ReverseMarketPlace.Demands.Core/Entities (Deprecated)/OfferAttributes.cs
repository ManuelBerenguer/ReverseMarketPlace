using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class OfferAttributes : BaseEntity
    {
        [Required]
        public Offer Offer { get; private set; }

        [Required]
        public Attribute Attribute { get; private set; }

        public string StringValue { get; private set; }
        public double? NumericValue { get; private set; }
        public DateTime? DateValue { get; private set; }
        public Boolean? BooleanValue { get; private set; }

        private OfferAttributes() { }

        public OfferAttributes(Offer offer, Attribute attribute)
        {
            Offer = offer;
            Attribute = attribute;
        }

        public OfferAttributes(Offer offer, Attribute attribute, object value)
        {
            if (offer.IsNull())
                throw new ArgumentNullException(nameof(offer));

            if (attribute.IsNull())
                throw new ArgumentNullException(nameof(attribute));

            if (value.IsNull())
                throw new ArgumentNullException(nameof(value));

            Offer = offer;
            Attribute = attribute;

            SetValue(value);
        }

        public void SetValue(object value)
        {
            switch (Attribute.DataTypeId)
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
