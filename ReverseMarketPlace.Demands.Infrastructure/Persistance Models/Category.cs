using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models
{
    public class Category : BaseEntity
    {
        /// <summary>
        /// Name of the category
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Parent category
        /// </summary>
        public Category UpperCategory { get; set; }

        /// <summary>
        /// Collection of child categories.
        /// </summary>
        public ICollection<Category> SubCategories { get; set; }

        /// <summary>
        /// Collection of product types related to this category
        /// </summary>
        public ICollection<ProductType> ProductTypes { get; set; }

        private Category() { }
    }
}