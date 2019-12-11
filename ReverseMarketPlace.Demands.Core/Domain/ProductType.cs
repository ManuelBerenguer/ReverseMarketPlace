using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types.Entities;
using ReverseMarketPlace.Demands.Core.Constants;
using ReverseMarketPlace.Demands.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Domain
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
        public ICollection<Attribute> Attributes { get; private set; }

        public ProductType(Guid id, string name, Category category, ICollection<Attribute> attributes)
        {
            if (id.IsNull() || id == Guid.Empty)
                throw new InvalidIdException(nameof(id));

            if (String.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            if (category.IsNull())
                throw new ArgumentNullException(nameof(category));

            Id = id;
            Name = name;
            Category = category;
            Attributes = attributes;
        }
    }
}
