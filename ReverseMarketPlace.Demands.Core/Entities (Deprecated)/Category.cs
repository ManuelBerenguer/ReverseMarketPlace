using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; private set; }

        public Category UpperCategory { get; private set; }

        public ICollection<Category> SubCategories { get; private set; }

        public ICollection<CategoryAttributes> CategoryAttributes { get; private set; }

        private Category() { }

        /// <summary>
        /// Constructor to set the name of a Category without upper category
        /// </summary>
        /// <param name="name">The name of the category</param>
        public Category(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Constructor to create a new Category with name and upper category
        /// </summary>
        /// <param name="name"></param>
        /// <param name="upperCategory"></param>
        public Category(string name, Category upperCategory)
        {
            Name = name;
            UpperCategory = upperCategory;
        }
    }
}
