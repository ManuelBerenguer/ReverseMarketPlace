using ReverseMarketPlace.Common.Types.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Messages.Events
{
    public class DemandCreated : IEvent
    {
        /// <summary>
        /// Id of the demand just created
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Id of the buyer who make the demand
        /// </summary>
        public Guid BuyerId { get; }

        /// <summary>
        /// Type of the product demanded
        /// </summary>
        public Guid ProductTypeId { get; }

        /// <summary>
        /// Quantity of the product demanded.
        /// </summary>   
        public float Quantity { get; private set; }

        /// <summary>
        /// Attributes to detail more what the buyer wants
        /// </summary>
        public IDictionary<Guid, object> Attributes { get; private set; }

        public DemandCreated(Guid id, Guid buyerId, Guid productTypeId, float quantity, IDictionary<Guid, object> attributes)
        {
            Id = id;
            BuyerId = buyerId;
            ProductTypeId = productTypeId;
            Quantity = quantity;
            Attributes = attributes;
        }
    }
}
