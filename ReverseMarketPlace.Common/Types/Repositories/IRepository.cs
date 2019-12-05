using ReverseMarketPlace.Common.Types.Entities;
using ReverseMarketPlace.Common.Types.Pagination;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Common.Types.Repositories
{
    public interface IRepository<TEntity> where TEntity : IIdentifiable
    {
        /// <summary>
        /// To get an entity by it's id
        /// </summary>
        /// <param name="id">Id of the entity to retirve</param>
        /// <returns>The unique entity with that id</returns>
        Task<TEntity> GetAsync(Guid id);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<PagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate,
               TQuery query) where TQuery : PagedQueryBase;
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
