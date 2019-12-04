using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class GroupDemands : BaseEntity
    {
        /// <summary>
        /// Group of demands
        /// </summary>
        public Group Group { get; private set; }

        /// <summary>
        /// Demand that belongs to the group
        /// </summary>
        public Demand Demand { get; private set; }

        /// <summary>
        /// Indicates if the demand is the one that created the group. If true, the group is based in the attributes of this demand. 
        /// </summary>
        public bool IsLeader { get; private set; }

        private GroupDemands() { }

        public GroupDemands(Group group, Demand demand, bool isLeader)
        {
            Group = group;
            Demand = demand;
            IsLeader = isLeader;
        }
    }
}
