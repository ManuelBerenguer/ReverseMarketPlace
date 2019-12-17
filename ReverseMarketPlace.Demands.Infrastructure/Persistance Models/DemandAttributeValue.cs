using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models
{
    public class DemandAttributeValue : BaseEntity
    {
        [Required]
        public Demand Demand { get; set; }
        public Guid DemandId { get; set; }

        [Required]
        public Attribute Attribute { get; set; }
        public Guid AttributeId { get; set; }

        [Required]
        public object Value { get; set; }

        public DemandAttributeValue() { }

        public DemandAttributeValue(Core.Domain.AttributeValue attributeValue, Guid demandId)
        {
            Id = attributeValue.Id;
            AttributeId = attributeValue.Attribute.Id;
            DemandId = demandId;
            Value = attributeValue.Value;
        }
    }
}
