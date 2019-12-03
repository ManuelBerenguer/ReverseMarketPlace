using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types;
using ReverseMarketPlace.Demands.Core.Enums.Demands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class Demand : BaseEntity
    {
        /// <summary>
        /// Reference of the buyer who make the demand
        /// </summary>
        [Required]
        public string BuyerReference { get; private set; }              

        /// <summary>
        /// Category of the product demanded
        /// </summary>
        [Required]
        public Category Category { get; set; }

        /// <summary>
        /// Quantity of the product demanded.
        /// </summary>
        [Required]
        public float Quantity { get; private set; }

        /// <summary>
        /// Attributes to detail more what the user wants
        /// </summary>
        public ICollection<DemandAttributes> DemandAttributes { get; private set; }

        /// <summary>
        /// Current status of the demand
        /// </summary>
        [IgnoreMember]
        public DemandStatusEnum Status { get; private set; } // Ignored in comparisons because of attribute

        private Demand() { }

        public Demand(string buyerReference, Category category, float quantity)
        {
            BuyerReference = buyerReference;
            Category = category;
            Quantity = quantity;
            Status = DemandStatusEnum.Created; // Initially is on 'Created' status
            DemandAttributes = new List<DemandAttributes>();
        }

        public Demand(string buyerReference, Category category, float quantity, ICollection<DemandAttributes> demandAttributes)
        {
            BuyerReference = buyerReference;
            Category = category;
            Quantity = quantity;
            Status = DemandStatusEnum.Created; // Initially is on 'Created' status
            DemandAttributes = demandAttributes.IsNull() ? new List<DemandAttributes>() : demandAttributes;
        }

        public void AddAttribute(Attribute attribute, object value)
        {
            if (attribute.IsNull())
                throw new ArgumentNullException(nameof(attribute));

            if(value.IsNull())
                throw new ArgumentNullException(nameof(value));

            DemandAttributes.Add( new Entities.DemandAttributes(this, attribute, value) );        
        }                
    }
}
