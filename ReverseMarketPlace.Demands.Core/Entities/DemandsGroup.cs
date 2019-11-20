using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class DemandsGroup : BaseEntity
    {
        public ICollection<Demand> Demands { get; private set; }

        [IgnoreMember]
        public ICollection<Offer> Offers { get; private set; } // Ignored in comparisons because of attribute

        private DemandsGroup() { }

        public DemandsGroup(ICollection<Demand> demands, ICollection<Offer> offers)
        {
            Demands = demands;
            Offers = offers;
        }
    }
}
