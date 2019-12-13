using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Demands.Core.Enums.Demands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Domain
{
    public class ValueAttribute : Domain.Attribute
    {
        /// <summary>
        /// Value of the attribute
        /// </summary>
        [Required]
        public object Value { get; private set; }

        public ValueAttribute(Guid id, string name, AttributeDataTypeEnum dataTypeId, object value) : base(id, name, dataTypeId)
        {
            SetValue(value);
        }

        public ValueAttribute(Attribute attribute, object value) : base(attribute)
        {
            SetValue(value);
        }

        public void SetValue(object value)
        {
            if (value.IsNull())
                throw new ArgumentException(nameof(value));

            Value = value;            
        }

        /// <summary>
        /// Checks if has the same value of other ValueAttribute object
        /// </summary>
        /// <param name="other">ValueAttribute object for compare to</param>
        /// <returns>True if both have the same value, false otherwise</returns>
        public bool HasSameValue(ValueAttribute other)
        {
            if (DataType == AttributeDataTypeEnum.NumericValue)
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
        /// <param name="other">ValueAttribute object for compare to</param>
        /// <returns>True if both have different value, false otherwise</returns>
        public bool HasDifferentValue(ValueAttribute other)
        {
            return !HasSameValue(other);
        }
    }
}
