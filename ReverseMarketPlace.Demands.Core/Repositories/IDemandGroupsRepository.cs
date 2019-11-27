using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface IDemandGroupsRepository : IRepository<DemandsGroup>
    {
        Task<IEnumerable<DemandsGroup>> GetGroupsByCategoryId(int categoryId);
    }
}
