using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models
{
    public class ProductTypeAttribute : BaseEntity
    {
        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        public Attribute Attribute { get; set; }

        private ProductTypeAttribute() { }
    }
}
