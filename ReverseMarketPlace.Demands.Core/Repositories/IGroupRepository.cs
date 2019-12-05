using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface IGroupRepository : IRepositoryOld<Group>
    {
        Task<IEnumerable<Group>> GetGroupsByCategoryWithDemands(int categoryId);
    }
}
