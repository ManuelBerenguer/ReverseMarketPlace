using ReverseMarketPlace.Common.Types;
using ReverseMarketPlace.Demands.Core.Enums.Demands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// Quantity of the product demanded
        /// </summary>
        [IgnoreMember] // The quantity should not being taken into account comparing demands. For us, two demands are the same if the same buyer demands the same product.
        [Required]
        public float Quantity { get; private set; }

        /// <summary>
        /// Current status of the demand
        /// </summary>
        [IgnoreMember]
        public DemandStatusEnum Status { get; private set; } // Ignored in comparisons because of attribute

        public Demand() { }

        public Demand(string buyerReference, Category category, float quantity)
        {
            BuyerReference = buyerReference;
            Category = category;
            Quantity = quantity;
            Status = DemandStatusEnum.Created; // Initially is on 'Created' status
        }
    }
}
