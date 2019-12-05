using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using ReverseMarketPlace.Common.Types.Entities;
using ReverseMarketPlace.Common.Types.Pagination;
using ReverseMarketPlace.Common.Types.Repositories;

namespace ReversemarketPlace.Demands.Infrastructure.Data.Mongo.Repositories
{
    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : IIdentifiable
    {
        protected IMongoCollection<TEntity> Collection { get; }

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            Collection = database.GetCollection<TEntity>(collectionName);
        }

        /// <summary>
        /// To get an entity by it's id
        /// </summary>
        /// <param name="id">Id of the entity to retirve</param>
        /// <returns>The unique entity with that id</returns>
        public async Task<TEntity> GetAsync(Guid id)
            => await GetAsync(e => e.Id == id);

        public Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate, TQuery query) where TQuery : PagedQueryBase
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
