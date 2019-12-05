using MediatR;
using ReverseMarketPlace.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.Demands
{
    /// <summary>
    /// Command for creating a new demand. It stores all neccessary data to create the demand.
    /// </summary>
    public class CreateDemandCommand : IRequest<CreateDemandResult>
    {        
        /// <summary>
        /// Reference of the buyer who is creating the demand
        /// </summary>
        public string BuyerReference { get; }

        /// <summary>
        /// Category id of the product demanded
        /// </summary>
        public int CategoryId { get; }

        /// <summary>
        /// Quantity of the product demanded
        /// </summary>
        public float Quantity { get; }

        /// <summary>
        /// Attributes for the demand
        /// </summary>
        public IDictionary<int, object> Attributes { get; }

        public CreateDemandCommand(string buyerReference, int categoryId, float quantity, IDictionary<int, object> attributes)
        {
            BuyerReference = buyerReference;
            CategoryId = categoryId;
            Quantity = quantity;
            Attributes = attributes.IsNull() ? new Dictionary<int, object>() : attributes;
        }
    }
}
