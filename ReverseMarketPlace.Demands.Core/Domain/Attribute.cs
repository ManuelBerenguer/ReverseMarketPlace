using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types.Entities;
using ReverseMarketPlace.Demands.Core.Constants;
using ReverseMarketPlace.Demands.Core.Enums.Demands;
using ReverseMarketPlace.Demands.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Domain
{
    public class Attribute : BaseEntity
    {
        /// <summary>
        /// Attribute name
        /// </summary>
        [Required]
        public string Name { get; private set; }

        /// <summary>
        /// Data type of the value 
        /// </summary>
        [Required]
        public AttributeDataTypeEnum DataType { get; private set; }

        public Attribute(Guid id, string name, AttributeDataTypeEnum dataTypeId)
        {
            SetId(id);
            SetName(name);
            SetDataType(dataTypeId);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="attribute">Attribute to copy properties from</param>
        public Attribute(Attribute attribute)
        {
            SetId(attribute.Id);
            SetName(attribute.Name);
            SetDataType(attribute.DataType);
        }

        public void SetId(Guid id)
        {
            if(id.IsNull() || id == Guid.Empty)
                throw new InvalidIdException(nameof(id));

            Id = id;
        }

        public void SetName(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Name = name;
        }

        public void SetDataType(AttributeDataTypeEnum dataTypeId)
        {
            DataType = dataTypeId;
        }
    }
}
