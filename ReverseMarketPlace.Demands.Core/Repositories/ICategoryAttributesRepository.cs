using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface ICategoryAttributesRepository : IRepository<CategoryAttributes>
    {
        Task<IEnumerable<CategoryAttributes>> GetCategoryAttributes(int categoryId, params Expression<Func<CategoryAttributes, object>>[] includeExpressions);
    }
}
