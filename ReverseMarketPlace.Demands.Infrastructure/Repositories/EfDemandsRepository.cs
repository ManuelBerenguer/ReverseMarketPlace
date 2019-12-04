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
                
        public async Task<IEnumerable<Demand>> GetBuyerDemandsWithCategoryAndAttributes(string buyerReference)
        {
            return await _dbContext.Demands.Where(d => d.BuyerReference.Equals(buyerReference))
                .Include(d => d.Category)
                .Include(d => d.DemandAttributes).ThenInclude(da => da.Attribute)
                .ToListAsync();
        }

        public async Task<Demand> GetDemandById(int id)
        {
            return await _dbContext.Demands.Where(d => d.Id == id)
                .Include(d => d.Category)
                .Include(d => d.DemandAttributes).ThenInclude(da => da.Attribute)
                .SingleOrDefaultAsync();
        }
    }
}
