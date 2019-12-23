using Newtonsoft.Json;
using ReverseMarketPlace.Common.Types.Messages;
using System;
using System.Collections.Generic;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.Demands
{
    [MessageNamespace("demands")]
    /// <summary>
    /// Represents the intention to create a new demand. Inmutable cause the properties have no setters.
    /// </summary>
    public class CreateDemand : ICommand
    {
        /// <summary>
        /// Id of the new demand
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Id of the buyer who is creating the demand
        /// </summary>
        public Guid BuyerId { get; }

        /// <summary>
        /// Type id of the product demanded
        /// </summary>
        public Guid ProductTypeId { get; }

        /// <summary>
        /// Quantity of the product demanded
        /// </summary>
        public float Quantity { get; }

        /// <summary>
        /// Attributes for the demand
        /// </summary>
        public IDictionary<Guid, object> Attributes { get; }

        [JsonConstructor]
        public CreateDemand(Guid id, Guid buyerReference, Guid productTypeId, float quantity, IDictionary<Guid, object> attributes)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            BuyerId = buyerReference;
            ProductTypeId = productTypeId;
            Quantity = quantity;
            Attributes = attributes;
        }
    }
}
