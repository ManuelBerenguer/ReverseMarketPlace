using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<DemandAttributeValue> DemandAttributeValues { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductTypeAttribute> ProductTypeAttributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category
            modelBuilder.Entity<Category>()
                .HasOne(c => c.UpperCategory)
                .WithMany(u => u.SubCategories);

            // DemandAttributeValue
            modelBuilder.Entity<DemandAttributeValue>()
                .HasOne(dav => dav.Demand)
                .WithMany(d => d.DemandAttributeValues)
                .HasForeignKey(dav => dav.DemandId);

            modelBuilder.Entity<DemandAttributeValue>()
                .HasOne(dav => dav.Attribute)
                .WithMany(att => att.DemandAttributeValues)
                .HasForeignKey(dav => dav.AttributeId);

            // ProductType
            modelBuilder.Entity<ProductType>()
                .HasOne(pt => pt.Category)
                .WithMany(c => c.ProductTypes);

            // ProductTypeAttribute
            modelBuilder.Entity<ProductTypeAttribute>()
                .HasOne(pta => pta.ProductType)
                .WithMany(pt => pt.ProductTypeAttributes);

            modelBuilder.Entity<ProductTypeAttribute>()
                .HasOne(pta => pta.Attribute)
                .WithMany(att => att.ProductTypeAttributes);

            // Demand
            modelBuilder.Entity<Demand>()
                .HasOne(d => d.ProductType)
                .WithMany(pt => pt.Demands)
                .HasForeignKey(d => d.ProductTypeId);
        }
    }
}
