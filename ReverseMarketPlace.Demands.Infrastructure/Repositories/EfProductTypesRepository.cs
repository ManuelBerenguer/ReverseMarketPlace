using ReverseMarketPlace.Demands.Core.Domain;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Data;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Repositories
{
    public class EfProductTypesRepository : IProductTypesRepository
    {
        protected readonly DemandsDbContext _dbContext;

        public EfProductTypesRepository(DemandsDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<ProductType> GetByIdAsync(Guid id)
        {
            var productType = await _dbContext.ProductTypes.FindAsync(id);

            return ProductTypeMapper.MapFrom(productType);
        }                                
    }
}
