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

            //switch(DataType)
            //{
            //    case AttributeDataTypeEnum.BoleanValue:
            //        try
            //        {
            //            Value = Convert.ToBoolean(value);
            //        }
            //        catch(Exception ex)
            //        {
            //            throw new AttributeValueNotValidException(ExceptionConstants.AttributeValueNotValid, ex);
            //        }                    
            //        break;

            //    case AttributeDataTypeEnum.NumericValue:

            //}
        }
    }
}
