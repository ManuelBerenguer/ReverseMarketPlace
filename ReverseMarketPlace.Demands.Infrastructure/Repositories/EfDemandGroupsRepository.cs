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

namespace ReverseMarketPlace.Demands.Infrastructure.Data.Repositories
{
    public class EfDemandGroupsRepository : EfRepository<DemandsGroup>, IDemandGroupsRepository
    {
        public EfDemandGroupsRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<IEnumerable<DemandsGroup>> GetGroupsByCategoryId(int categoryId, params Expression<Func<DemandsGroup, object>>[] includeExpressions)
        {            
            var query = GetQueryable(includeExpressions);

            return query != null ? await query.Where(dg => dg.Category.Id == categoryId).ToListAsync()
                : await DbSet.Where(dg => dg.Category.Id == categoryId).ToListAsync();
        }
    }
}
