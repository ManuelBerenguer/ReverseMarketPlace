using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Data;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Repositories;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private IDemandsRepository _demandsRepository;
        private ICategoriesRepository _categoriesRepository;        
        private IProductTypesRepository _productTypesRepository;
        private readonly DemandsDbContext _appDbContext;

        public EfUnitOfWork(DemandsDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public IDemandsRepository DemandsRepository {
            get
            {
                if( _demandsRepository.IsNull())
                {
                    _demandsRepository = new EfDemandsRepository(_appDbContext);
                }

                return _demandsRepository;
            }
        }
                
        public ICategoriesRepository CategoriesRepository
        {
            get
            {
                if( _categoriesRepository.IsNull())
                {
                    _categoriesRepository = new EfCategoriesRepository(_appDbContext);
                }

                return _categoriesRepository;
            }
        }
                
        public IProductTypesRepository ProductTypesRepository
        {
            get
            {
                if(_productTypesRepository.IsNull())
                {
                    _productTypesRepository = new EfProductTypesRepository(_appDbContext);
                }

                return _productTypesRepository;
            }
        }
    }
}
