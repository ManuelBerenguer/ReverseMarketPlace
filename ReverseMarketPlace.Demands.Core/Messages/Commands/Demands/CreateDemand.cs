using Newtonsoft.Json;
using ReverseMarketPlace.Common.Types.Messages;
using System;
using System.Collections.Generic;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.Demands
{
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
        public Guid BuyerReference { get; }

        /// <summary>
        /// Category id of the product demanded
        /// </summary>
        public Guid CategoryId { get; }

        /// <summary>
        /// Quantity of the product demanded
        /// </summary>
        public float Quantity { get; }

        /// <summary>
        /// Attributes for the demand
        /// </summary>
        public IDictionary<int, object> Attributes { get; }

        [JsonConstructor]
        public CreateDemand(Guid id, Guid buyerReference, Guid categoryId, float quantity, IDictionary<int, object> attributes)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            BuyerReference = buyerReference;
            CategoryId = categoryId;
            Quantity = quantity;
            Attributes = attributes;
        }
    }
}
