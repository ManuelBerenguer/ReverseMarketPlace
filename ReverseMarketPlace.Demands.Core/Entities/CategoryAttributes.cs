using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class CategoryAttributes : BaseEntity
    {
        [Required]
        public Category Category { get; private set; }

        [Required]
        public Attribute Attribute { get; private set; }

        private CategoryAttributes() { }

        public CategoryAttributes(Category c, Attribute att)
        {
            Category = c;
            Attribute = att;
        }
    }
}
