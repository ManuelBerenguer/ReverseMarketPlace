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
    public class EfCategoryAttributesRepository : EfRepository<CategoryAttributes>, ICategoryAttributesRepository
    {
        public EfCategoryAttributesRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<IEnumerable<CategoryAttributes>> GetCategoryAttributes(int categoryId)
        {
            return await _dbContext.CategoryAttributes.Where(catAtt => catAtt.Category.Id == categoryId).Include(catAtt => catAtt.Attribute).ToListAsync();
        }
    }
}
