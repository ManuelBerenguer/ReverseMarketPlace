using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.Repositories
{
    public class EfGroupRepository : EfRepository<Group>, IGroupRepository
    {
        public EfGroupRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<IEnumerable<Group>> GetGroupsByCategoryWithDemands(int categoryId)
        {
            return await _dbContext.Groups.Where(g => g.Category.Id == categoryId).Include(g => g.GroupDemands).ThenInclude(gd => gd.Demand).ToListAsync();
        }
    }
}
