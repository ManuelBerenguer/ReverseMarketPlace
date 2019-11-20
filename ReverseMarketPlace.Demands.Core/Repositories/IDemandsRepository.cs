using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface IDemandsRepository : IRepository<Demand>
    {
        Task<IEnumerable<Demand>> GetBuyerDemands(string buyerReference);
    }
}
