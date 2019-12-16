using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models
{
    public class ProductTypeAttribute : BaseEntity
    {
        ProductType ProductType { get; set; }

        Attribute Attribute { get; set; }

        private ProductTypeAttribute() { }
    }
}
