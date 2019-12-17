using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models
{
    public class ProductType : BaseEntity
    {
        /// <summary>
        /// Name of the product type
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Category of the product type
        /// </summary>
        [Required]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        /// <summary>
        /// Collection of attributes allowed for this product type 
        /// </summary>
        public ICollection<ProductTypeAttribute> ProductTypeAttributes { get; set; }

        /// <summary>
        /// All the demands associated to this product type
        /// </summary>
        public ICollection<Demand> Demands { get; set; }

        public ProductType() { }
    }
}