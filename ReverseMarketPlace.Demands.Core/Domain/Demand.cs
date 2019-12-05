using ReverseMarketPlace.Common.Types.Entities;
using ReverseMarketPlace.Demands.Core.Enums.Demands;
using ReverseMarketPlace.Demands.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace ReverseMarketPlace.Demands.Core.Domain
{
    /// <summary>
    /// Aggregate Root. https://deviq.com/aggregate-pattern/
    /// Any domain entity object is responsible to keep it's valid state (it should make the proper validations)
    /// </summary>
    public class Demand : BaseEntity
    {
        /// <summary>
        /// Id of the buyer who make the demand
        /// </summary>        
        public Guid BuyerId { get; private set; }

        /// <summary>
        /// Category of the product demanded
        /// </summary>
        public Category Category { get; private set; }

        /// <summary>
        /// Quantity of the product demanded.
        /// </summary>     
        public float Quantity { get; private set; }

        /// <summary>
        /// Current status of the demand
        /// </summary>
        public DemandStatusEnum Status { get; private set; }

        /// <summary>
        /// Attributes to detail more what the buyer wants
        /// </summary>
        public ICollection<Attribute> Attributes { get; private set; }


        public Demand(Guid id, Guid buyerId)
        {
            if (id == null || id == Guid.Empty)
                throw new InvalidIdException(nameof(id));

            Id = id;
            BuyerId = buyerId;
        }

        public void SetBuyerId(Guid buyerId)
        {
            if (buyerId == null || buyerId == Guid.Empty)
                throw new InvalidIdException(nameof(buyerId));

            BuyerId = buyerId;
        }
    }
}
