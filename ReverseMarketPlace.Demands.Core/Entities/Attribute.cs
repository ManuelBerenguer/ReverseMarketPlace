using ReverseMarketPlace.Common.Types;
using ReverseMarketPlace.Demands.Core.Enums.Demands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class Attribute : BaseEntity
    {
        [Required]
        public string Name { get; private set; }

        [Required]
        public AttributeDataTypeEnum DataTypeId { get; private set; }

        private Attribute() { }

        public Attribute(string name, AttributeDataTypeEnum dataType)
        {
            Name = name;
            DataTypeId = dataType;
        }
    }
}
