using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class DemandsGroup : BaseEntity
    {
        /// <summary>
        /// Demands inside the group
        /// </summary>
        public ICollection<Demand> Demands { get; private set; }

        /// <summary>
        /// Offers received
        /// </summary>
        [IgnoreMember]
        public IReadOnlyCollection<Offer> Offers { get; private set; } // Ignored in comparisons because of attribute

        /// <summary>
        /// Category of all the demands
        /// </summary>
        public Category Category { get; private set; }


        private DemandsGroup() { }

        public DemandsGroup(ICollection<Demand> demands, IReadOnlyCollection<Offer> offers)
        {
            Demands = demands;
            Offers = offers;
        }

        /// <summary>
        /// Constructor to create a new group from it's first demand
        /// </summary>
        /// <param name="demand">First demand for the group just created</param>
        public DemandsGroup(Demand demand)
        {
            Demands = new List<Demand>() { demand };
            Category = demand.Category;
        }
    }
}
