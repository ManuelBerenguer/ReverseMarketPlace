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

        public ICollection<CategoryAttributes> CategoryAttributes { get; private set; }

        public Category() { }

        public Category(string name, Category upperCategory)
        {
            Name = name;
            UpperCategory = upperCategory;
        }
    }
}
