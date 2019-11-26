using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Repositories
{
    public class EfCategoriesRepository : EfRepository<Category>, ICategoriesRepository
    {
        public EfCategoriesRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
