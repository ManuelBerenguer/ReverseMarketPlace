using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class Offer : BaseEntity
    {
        /// <summary>
        /// Price of the product offerted
        /// </summary>
        [Required]
        public float Price { get; private set; }

        /// <summary>
        /// Minimum number of demands that should accept the offer
        /// </summary>
        [Required]
        public int MinimumDemands { get; private set; }

        /// <summary>
        /// Maximum number of demands that can accept the offer
        /// </summary>
        public int? MaximumDemands { get; private set; }

        /// <summary>
        /// Date from wich the offer will ceases to have effect
        /// </summary>
        [Required]
        public DateTime ExpirationDate { get; private set; }

        /// <summary>
        /// Reference of the seller that emits the offer
        /// </summary>
        [Required]
        public string SellerReference { get; private set; }

        /// <summary>
        /// Attributes to detail more what the seller exactly offers
        /// </summary>
        public ICollection<OfferAttributes> OfferAttributes { get; private set; }

        private Offer() { }

        public Offer(float price, int minimumDemands, int? maximumDemands, DateTime expirationDate, string sellerReference) {
            Price = price;
            MinimumDemands = minimumDemands;
            MaximumDemands = maximumDemands;
            ExpirationDate = expirationDate;
            SellerReference = sellerReference;
            OfferAttributes = new List<OfferAttributes>(); // Empty list
        }

        public Offer(float price, int minimumDemands, int? maximumDemands, DateTime expirationDate, string sellerReference, ICollection<OfferAttributes> offerAttributes)
        {
            Price = price;
            MinimumDemands = minimumDemands;
            MaximumDemands = maximumDemands;
            ExpirationDate = expirationDate;
            SellerReference = sellerReference;
            OfferAttributes = offerAttributes.IsNull() ? new List<OfferAttributes>() : offerAttributes;
        }

        public void AddAttribute(Attribute attribute, object value)
        {
            if (attribute.IsNull())
                throw new ArgumentNullException(nameof(attribute));

            if (value.IsNull())
                throw new ArgumentNullException(nameof(value));

            OfferAttributes.Add(new Entities.OfferAttributes(this, attribute, value));
        }
    }
}
