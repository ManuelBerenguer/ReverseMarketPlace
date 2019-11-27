using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Infrastructure.Repositories
{
    public class EfCategoriesRepository : EfRepository<Category>, ICategoriesRepository
    {
        public EfCategoriesRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
