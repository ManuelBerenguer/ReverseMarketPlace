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
    public class EfDemandGroupsRepository : EfRepository<DemandsGroup>, IDemandGroupsRepository
    {
        public EfDemandGroupsRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<IEnumerable<DemandsGroup>> GetGroupsByCategoryId(int categoryId)
        {
            return await _dbContext.DemandsGroups.Where(dg => dg.Category.Id == categoryId).ToListAsync();
        }
    }
}
