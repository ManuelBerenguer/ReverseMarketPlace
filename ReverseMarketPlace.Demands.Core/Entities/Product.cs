using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; private set; }

        [Required]
        public Category Category { get; set; }

        private Product() { }

        public Product(string name, Category category)
        {
            Name = name;
            Category = category;
        }
    }
}
