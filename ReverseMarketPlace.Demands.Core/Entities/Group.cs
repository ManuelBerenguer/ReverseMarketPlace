using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class Group : BaseEntity
    {
        /// <summary>
        /// Attributes to detail more what the user wants
        /// </summary>
        public ICollection<DemandsGroup> GroupDemands { get; private set; }

        /// <summary>
        /// Offers received
        /// </summary>        
        public ICollection<Offer> Offers { get; private set; }

        /// <summary>
        /// Category of all the demands
        /// </summary>
        public Category Category { get; private set; }

        public Group(Category category)
        {
            Category = category;
            Offers = new List<Offer>();
            GroupDemands = new List<DemandsGroup>(); // Empty list
        }

        private Group() { }

        public Group(Category category, ICollection<Offer> offers)
        {
            if (category.IsNull())
                throw new ArgumentNullException(nameof(category));

            Category = category;
            Offers = offers.IsNull() ? new List<Offer>() : offers;
            GroupDemands = new List<DemandsGroup>(); // Empty list
        }

        public Group(Category category, ICollection<Offer> offers, ICollection<DemandsGroup> groupDemands)
        {
            if (category.IsNull())
                throw new ArgumentNullException(nameof(category));

            Category = category;
            Offers = offers.IsNull() ? new List<Offer>() : offers;
            GroupDemands = groupDemands.IsNull() ? new List<DemandsGroup>() : groupDemands;
        }

        public void AddDemand(Demand demand)
        {
            if (demand.IsNull())
                throw new ArgumentNullException(nameof(demand));

            DemandsGroup newGroupDemand = new DemandsGroup(this, demand);
            GroupDemands.Add(newGroupDemand);
        }

        public void AddOffer(Offer offer)
        {
            if (offer.IsNull())
                throw new ArgumentNullException(nameof(offer));

            Offers.Add(offer);
        }

        public IEnumerable<Demand> GetDemands()
        {
            return GroupDemands.Select(gd => gd.Demand);
        }

        public int GetNumberOfDemands()
        {
            return GroupDemands.Count();
        }
    }
}
