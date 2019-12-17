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
        /// Id of the category of the product type
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// Collection of attributes allowed for this product type 
        /// </summary>
        public ICollection<Attribute> Attributes { get; private set; }

        public ProductType(Guid id, string name, Guid categoryId, ICollection<Attribute> attributes)
        {        
            SetId(id);
            SetName(name);
            SetCategoryId(categoryId);
            SetAttributes(attributes);
        }

        public void SetName(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Name = name;
        }

        public void SetCategoryId(Guid categoryId)
        {
            if (categoryId == null || categoryId == Guid.Empty)
                throw new InvalidIdException(nameof(categoryId));

            CategoryId = categoryId;
        }

        public void SetAttributes(ICollection<Attribute> attributes)
        {
            Attributes = attributes;
        }
    }
}
