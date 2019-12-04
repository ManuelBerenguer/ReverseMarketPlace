using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class DemandsGroup : BaseEntity
    {
        /// <summary>
        /// Group of demands
        /// </summary>
        public Group Group { get; private set; }

        /// <summary>
        /// Demand that belongs to the group
        /// </summary>
        public Demand Demand { get; private set; }


        private DemandsGroup() { }

        public DemandsGroup(Group group, Demand demand)
        {
            Group = group;
            Demand = demand;
        }
    }
}
