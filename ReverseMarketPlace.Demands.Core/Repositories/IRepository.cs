using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeExpressions);        
        Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids, params Expression<Func<T, object>>[] includeExpressions);
        Task AddAsync(T entity);
    }
}
