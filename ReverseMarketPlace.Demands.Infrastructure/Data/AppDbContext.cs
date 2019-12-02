using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Attribute = ReverseMarketPlace.Demands.Core.Entities.Attribute;

namespace ReverseMarketPlace.Demands.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<CategoryAttributes> CategoryAttributes { get; set; }
        public DbSet<DemandsGroup> DemandsGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category
            modelBuilder.Entity<Category>()
                .HasOne(c => c.UpperCategory)
                .WithMany(u => u.SubCategories);               

            // CategoryAttributes
            modelBuilder.Entity<CategoryAttributes>()
                .HasOne(ca => ca.Category)
                .WithMany(c => c.CategoryAttributes);
            modelBuilder.Entity<CategoryAttributes>()
                .HasOne(ca => ca.Attribute)
                .WithMany();
                
                //.WithMany(a => a.CategoryAttributes).HasForeignKey("AttributeId") // Shadow property;                
        }
    }
}
