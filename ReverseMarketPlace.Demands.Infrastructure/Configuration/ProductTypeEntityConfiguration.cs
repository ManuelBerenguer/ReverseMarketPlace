using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Configuration
{
    public class ProductTypeEntityConfiguration : IEntityTypeConfiguration<ProductType>
    {        
        public void Configure(EntityTypeBuilder<Persistance_Models.ProductType> entity)
        {
            entity.HasOne(pt => pt.Category)
                .WithMany(c => c.ProductTypes);              
        }
    }
}
