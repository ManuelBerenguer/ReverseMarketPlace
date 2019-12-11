using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Common.Types;
using ReverseMarketPlace.Common.Types.Entities;
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
    public class EfRepository<T> //: IRepositoryOld<T> where T : IIdentifiable
    {
        //protected readonly AppDbContext _dbContext;
        //protected DbSet<T> DbSet;

        //public EfRepository(AppDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    DbSet = _dbContext.Set<T>();
        //}
                

        //public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeExpressions)
        //{
        //    DbSet<T> dbSet = _dbContext.Set<T>();

        //    IQueryable<T> query = null;
        //    foreach (var includeExpression in includeExpressions)
        //    {
        //        query = dbSet.Include(includeExpression);
        //    }

        //    return query != null ? await query.SingleOrDefaultAsync(e => e.Id == id) : await dbSet.SingleOrDefaultAsync(e => e.Id == id);
        //}                

        //public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids, params Expression<Func<T, object>>[] includeExpressions)
        //{
        //    DbSet<T> dbSet = _dbContext.Set<T>();

        //    IQueryable<T> query = null;
        //    foreach (var includeExpression in includeExpressions)
        //    {
        //        query = dbSet.Include(includeExpression);
        //    }

        //    return query != null ? await query.Where(e => ids.Contains(e.Id)).ToListAsync() : await dbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
        //}

        //public async Task AddAsync(T entity)
        //{
        //    await _dbContext.AddAsync<T>(entity);
        //}

        //protected IQueryable<T> GetQueryable(params Expression<Func<T, object>>[] includeExpressions)
        //{
        //    IQueryable<T> query = null;
        //    foreach (var includeExpression in includeExpressions)
        //    {
        //        query = DbSet.Include(includeExpression);
        //    }

        //    return query;
        //}
    }
}
