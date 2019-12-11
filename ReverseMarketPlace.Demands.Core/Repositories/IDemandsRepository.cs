using ReverseMarketPlace.Common.Types.Repositories;
using ReverseMarketPlace.Demands.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface IDemandsRepository
    {
        Task<IEnumerable<Demand>> GetBuyerDemands(Guid buyerId);
        Task AddAsync(Demand demand);
    }
}
