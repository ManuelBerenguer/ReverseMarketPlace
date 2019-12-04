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
    public class EfDemandGroupsRepository : EfRepository<GroupDemands>, IDemandGroupsRepository
    {
        public EfDemandGroupsRepository(AppDbContext appDbContext) : base(appDbContext) { }

        //public async Task<IEnumerable<DemandsGroup>> GetGroupsByCategoryIdWithDemands(int categoryId)
        //{
        //    return await _dbContext.DemandsGroups.Where(dg => dg.Group.Category.Id == categoryId)
        //        .Include(dg => dg.Demands).ToListAsync();
        //}
    }
}
