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
        public ICollection<GroupDemands> GroupDemands { get; private set; }

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
            GroupDemands = new List<GroupDemands>(); // Empty list
        }

        private Group() { }

        /// <summary>
        /// Creates a new group for the demand
        /// </summary>
        /// <param name="demand">First demand to be included in the new group (the lead demand)</param>
        public Group (Demand demand)
        {
            if (demand.IsNull())
                throw new ArgumentNullException(nameof(demand));

            Category = demand.Category;
            Offers = new List<Offer>(); // No offers at the moment
            GroupDemands newGroupDemand = new GroupDemands(this, demand, true);
            GroupDemands = new List<GroupDemands>() { newGroupDemand };
        }

        public Group(Category category, ICollection<Offer> offers)
        {
            if (category.IsNull())
                throw new ArgumentNullException(nameof(category));

            Category = category;
            Offers = offers.IsNull() ? new List<Offer>() : offers;
            GroupDemands = new List<GroupDemands>(); // Empty list
        }

        public Group(Category category, ICollection<Offer> offers, ICollection<GroupDemands> groupDemands)
        {
            if (category.IsNull())
                throw new ArgumentNullException(nameof(category));

            Category = category;
            Offers = offers.IsNull() ? new List<Offer>() : offers;
            GroupDemands = groupDemands.IsNull() ? new List<GroupDemands>() : groupDemands;
        }

        public void AddDemand(Demand demand)
        {
            if (demand.IsNull())
                throw new ArgumentNullException(nameof(demand));

            GroupDemands newGroupDemand = new GroupDemands(this, demand, false);
            GroupDemands.Add(newGroupDemand);
        }

        public void AddOffer(Offer offer)
        {
            if (offer.IsNull())
                throw new ArgumentNullException(nameof(offer));

            Offers.Add(offer);
        }

        /// <summary>
        /// Get the demands included
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Demand> GetDemands()
        {
            return GroupDemands.Select(gd => gd.Demand);
        }

        public int GetNumberOfDemands()
        {
            return GroupDemands.Count();
        }

        public int GetNumberOfOffers()
        {
            return Offers.Count();
        }

        public 
    }
}
