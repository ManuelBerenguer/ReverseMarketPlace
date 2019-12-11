using ReverseMarketPlace.Common.Types.Entities;
using ReverseMarketPlace.Demands.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Domain
{
    /// <summary>
    /// Aggregate Root. https://deviq.com/aggregate-pattern/
    /// </summary>
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

        public Category(Guid id, string name, Category upperCategory, ICollection<Category> subCategories)
        {
            if (id == null || id == Guid.Empty)
                throw new InvalidIdException(nameof(id));

            if (String.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Id = id;
            Name = name;
            UpperCategory = upperCategory;
            SubCategories = subCategories;
        }
    }
}
