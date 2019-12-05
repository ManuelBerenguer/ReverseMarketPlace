using ReverseMarketPlace.Common.Types.Entities;
using ReverseMarketPlace.Demands.Core.Enums.Demands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Domain
{
    public class Attribute : BaseEntity
    {
        public string Name { get; private set; }

        public AttributeDataTypeEnum DataTypeId { get; private set; }

        public object Value { get; private set; }
    }
}
