using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Demand> Demands { get; set; }
    }
}
