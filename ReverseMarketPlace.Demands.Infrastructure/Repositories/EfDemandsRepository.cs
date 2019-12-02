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
    public class EfDemandsRepository : EfRepository<Demand>, IDemandsRepository
    {   
        public EfDemandsRepository(AppDbContext appDbContext) : base(appDbContext) {}

        public async Task<IEnumerable<Demand>> GetBuyerDemands(string buyerReference, params Expression<Func<Demand, object>>[] includeExpressions)
        {
            if (string.IsNullOrWhiteSpace(buyerReference))
                return null;

            var query = GetQueryable(includeExpressions);

            return query != null ? await query.Where(d => d.BuyerReference.Equals(buyerReference)).ToListAsync() 
                : await DbSet.Where(d => d.BuyerReference.Equals(buyerReference)).ToListAsync();
        }

        public async Task<IEnumerable<Demand>> GetBuyerDemandsWithCategoryAndAttributes(string buyerReference)
        {
            return await _dbContext.Demands.Where(d => d.BuyerReference.Equals(buyerReference))
                .Include(d => d.Category)
                .Include(d => d.DemandAttributes).ThenInclude(da => da.Attribute)
                .ToListAsync();
        }
    }
}
