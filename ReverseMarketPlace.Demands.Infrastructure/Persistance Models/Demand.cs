using ReverseMarketPlace.Demands.Core.Enums.Demands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models
{
    public class Demand : BaseEntity
    {
        /// <summary>
        /// Id of the buyer who make the demand
        /// </summary>
        [Required]
        public Guid BuyerId { get; set; }

        /// <summary>
        /// Type of the product demanded
        /// </summary>
        [Required]
        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Quantity of the product demanded.
        /// </summary>
        [Required]
        public float Quantity { get; set; }

        /// <summary>
        /// Current status of the demand
        /// </summary>
        [Required]
        public DemandStatusEnum Status { get; set; }

        /// <summary>
        /// Attributes to detail more what the buyer wants
        /// </summary>
        public ICollection<DemandAttributeValue> DemandAttributeValues { get; set; }

        public Demand() { }

        public Demand(Core.Domain.Demand demand, List<DemandAttributeValue> demandAttributeValues)
        {
            Id = demand.Id;
            ProductTypeId = demand.ProductTypeId;
            Quantity = demand.Quantity;
            Status = demand.Status;
            DemandAttributeValues = demandAttributeValues;
        }
    }
}
