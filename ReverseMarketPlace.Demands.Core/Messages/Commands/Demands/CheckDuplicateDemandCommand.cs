using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.Demands
{
    public class CheckDuplicateDemandCommand : IRequest<bool>
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

        public CheckDuplicateDemandCommand(string buyerReference, int categoryId, float quantity, IDictionary<int, object> attributes)
        {
            BuyerReference = buyerReference;
            CategoryId = categoryId;
            Quantity = quantity;
            Attributes = attributes;
        }
    }
}
