using ReverseMarketPlace.Common.Types.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Domain
{
    /// <summary>
    /// Aggregate Root. https://deviq.com/aggregate-pattern/
    /// Any domain entity object is responsible to keep it's valid state (it should make the proper validations)
    /// </summary>
    public class Category : BaseEntity
    {
        /// <summary>
        /// Name of the category
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Parent category. Could be null.
        /// </summary>
        public Category UpperCategory { get; private set; }

        /// <summary>
        /// Collection of child categories. Could be null or empty.
        /// </summary>
        public ICollection<Category> SubCategories { get; private set; }
    }
}
