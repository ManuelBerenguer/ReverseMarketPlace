using ReverseMarketPlace.Demands.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface IProductTypesRepository
    {
        Task<ProductType> GetByIdAsync(Guid id);
    }
}
