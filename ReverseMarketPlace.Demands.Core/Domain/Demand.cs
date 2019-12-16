using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types.Entities;
using ReverseMarketPlace.Demands.Core.Enums.Demands;
using ReverseMarketPlace.Demands.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ReverseMarketPlace.Demands.Core.Domain
{
    /// <summary>
    /// Aggregate Root. https://vaadin.com/learn/v14
    /// The aggregate is created, retrieved and stored as a whole.
    /// The aggregate is always in a consistent state.
    /// The aggregate is owned by an entity called the aggregate root, whose ID is used to identify the aggregate itself.
    /// Instead of referencing another aggregate directly, create a value object that wraps the ID of the aggregate root 
    /// and use that as the reference. This makes it easier to maintain aggregate consistency boundaries since you cannot 
    /// even accidentally change the state of one aggregate from within another. It also prevents deep object trees from 
    /// being retrieved from the data store when an aggregate is retrieved.
    /// </summary>
    public class Demand : BaseEntity
    {
        /// <summary>
        /// Id of the buyer who make the demand
        /// </summary>
        public Guid BuyerId { get; private set; }

        /// <summary>
        /// Type of the product demanded
        /// </summary>
        public Guid ProductTypeId { get; private set; }

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
        public ICollection<AttributeValue> Attributes { get; private set; }

        /// <summary>
        /// Creates a new demand from the parameters given and status CREATED.
        /// </summary>
        /// <param name="id">Id of the demand</param>
        /// <param name="buyerId">Id of the buyer that makes the demand</param>
        /// <param name="productTypeId">Product type id associated to the demand</param>
        /// <param name="quantity">Quantity of the product demanded</param>
        /// <param name="attributes">Attributes to get more detail about the demand</param>
        public Demand(Guid id, Guid buyerId, Guid productTypeId, float quantity, ICollection<AttributeValue> attributes)
        {            
            SetId(id);
            SetBuyerId(buyerId);
            SetProductTypeId(productTypeId);
            SetQuantity(quantity);
            SetStatus(DemandStatusEnum.Created);
            SetAttributes(attributes);
        }

        /// <summary>
        /// Creates a new demand from the parameters given.
        /// </summary>
        /// <param name="id">Id of the demand</param>
        /// <param name="buyerId">Id of the buyer that makes the demand</param>
        /// <param name="productType">Product type of the demand</param>
        /// <param name="quantity">Quantity of the product demanded</param>
        /// <param name="status">State of the demand</param>
        /// <param name="attributes">Attributes to get more detail about the demand</param>
        public Demand(Guid id, Guid buyerId, Guid productTypeId, float quantity, DemandStatusEnum status, ICollection<AttributeValue> attributes)
        {
            SetId(id);
            SetBuyerId(buyerId);
            SetProductTypeId(productTypeId);
            SetQuantity(quantity);
            SetStatus(status);
            SetAttributes(attributes);
        }

        public void SetBuyerId(Guid buyerId)
        {
            if (buyerId == null || buyerId == Guid.Empty)
                throw new InvalidIdException(nameof(buyerId));

            BuyerId = buyerId;
        }

        public void SetProductTypeId(Guid productTypeId)
        {
            if (ProductTypeId.IsNull() || productTypeId == Guid.Empty)
                throw new ArgumentNullException(nameof(productTypeId));

            ProductTypeId = productTypeId;
        }

        public void SetQuantity(float quantity)
        {
            if (quantity <= 0)
                throw new QuantityMustBeGreaterThanZeroException(nameof(quantity));

            Quantity = quantity;
        }

        public void SetStatus(DemandStatusEnum status)
        {
            Status = status;
        }

        public void SetAttributes(ICollection<AttributeValue> attributes)
        {
            Attributes = attributes;
        }       

        public bool HasAttributes()
        {
            return !Attributes.EmptyOrNull();
        }

        public bool WithoutAttributes()
        {
            return !HasAttributes();
        }

        public int GetNumberOfAttributes()
        {
            return Attributes.EmptyOrNull() ? 0 : Attributes.Count();
        }

        public Dictionary<Guid, AttributeValue> GetAttributesDictionary()
        {
            return Attributes.ToDictionary(att => att.Attribute.Id);
        }
    }
}
