using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface IDemandsRepository : IRepository<Demand>
    {
        Task<IEnumerable<Demand>> GetBuyerDemandsWithCategoryAndAttributes(string buyerReference);
    }
}
