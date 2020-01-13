using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Configuration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public static readonly Guid TvAndAudio = Guid.NewGuid();
                
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasOne(c => c.UpperCategory)
                .WithMany(u => u.SubCategories);

            entity.HasData(
                new Category { 
                    Id = TvAndAudio,
                    Name = "Tv & Audio"
                }
            );
        }
    }
}
