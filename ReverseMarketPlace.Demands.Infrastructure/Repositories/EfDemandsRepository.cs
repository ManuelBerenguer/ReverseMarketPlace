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
    public class EfDemandsRepository : EfRepository<Demand>, IDemandsRepository
    {
        public EfDemandsRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<IEnumerable<Demand>> GetBuyerDemands(string buyerReference)
        {
            return await _dbContext.Demands.Include(d => d.Category)/*.Where(d => d.BuyerReference.Equals(buyerReference))*/.ToListAsync();
        }
    }
}
