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
        public string Name { get; private set; }

        /// <summary>
        /// Parent category
        /// </summary>
        public Category UpperCategory { get; private set; }

        /// <summary>
        /// Collection of child categories.
        /// </summary>
        public ICollection<Category> SubCategories { get; private set; }

        private Category() { }
    }
}