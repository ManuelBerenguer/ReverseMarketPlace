using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using ReverseMarketPlace.Demands.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.Repositories
{
    public class EfCategoriesRepository : EfRepository<Category>, ICategoriesRepository
    {
        public EfCategoriesRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Category> GetByIdWithAttributes(int categoryId)
        {
            // TODO: Why can't we use FindAsync() ??
            var category = await _dbContext.Categories.Where(c => c.Id == categoryId).Include(c => c.CategoryAttributes)
                .ThenInclude(ca => ca.Attribute).FirstOrDefaultAsync();

            return category;
        }
    }
}
