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
        public string Name { get; private set; }

        /// <summary>
        /// Category of the product type
        /// </summary>
        public Category Category { get; private set; }

        /// <summary>
        /// Collection of attributes allowed for this product type 
        /// </summary>
        public ICollection<ProductTypeAttribute> Attributes { get; private set; }

        public ProductType() { }
    }
}