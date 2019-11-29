using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Infrastructure.Repositories
{
    public class EfCategoryAttributesRepository : EfRepository<CategoryAttributes>, ICategoryAttributesRepository
    {
        public EfCategoryAttributesRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<IEnumerable<CategoryAttributes>> GetCategoryAttributes(int categoryId, params Expression<Func<CategoryAttributes, object>>[] includeExpressions)
        {
            var query = GetQueryable(includeExpressions);

            return query != null ? await query.Where(catAtt => catAtt.Category.Id == categoryId).ToListAsync()
                : await DbSet.Where(catAtt => catAtt.Category.Id == categoryId).ToListAsync();
        }
    }
}
