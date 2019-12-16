using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types.Entities;
using ReverseMarketPlace.Demands.Core.Enums.Demands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Domain
{
    public class AttributeValue : BaseEntity
    {
        /// <summary>
        /// Attribute that gets the value
        /// </summary>
        public Attribute Attribute { get; private set; }

        /// <summary>
        /// Value of the attribute
        /// </summary>
        public object Value { get; private set; }

        public void SetValue(object value)
        {
            if (value.IsNull())
                throw new ArgumentException(nameof(value));

            Value = value;
        }

        public AttributeValue(Attribute attribute, object value)
        {
            SetId(Guid.NewGuid());
            SetAttribute(attribute);
            SetValue(value);
        }

        public AttributeValue(Guid id, Attribute attribute, object value)
        {
            SetId(id);
            SetAttribute(attribute);
            SetValue(value);
        }

        public void SetAttribute(Attribute attribute)
        {
            if (attribute.IsNull())
                throw new ArgumentNullException(nameof(attribute));

            Attribute = attribute;
        }

        /// <summary>
        /// Checks if has the same value of other ValueAttribute object
        /// </summary>
        /// <param name="other">AttributeValue object for compare to</param>
        /// <returns>True if both have the same value, false otherwise</returns>
        public bool HasSameValue(AttributeValue other)
        {
            if (Attribute.DataType == AttributeDataTypeEnum.NumericValue)
            {
                if (Convert.ToInt32(Value) == Convert.ToInt32(other.Value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if has different value of other ValueAttribute object
        /// </summary>
        /// <param name="other">AttributeValue object for compare to</param>
        /// <returns>True if both have different value, false otherwise</returns>
        public bool HasDifferentValue(AttributeValue other)
        {
            return !HasSameValue(other);
        }
    }
}
