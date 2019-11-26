using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Infrastructure.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private IDemandsRepository _demandsRepository;
        private ICategoriesRepository _categoriesRepository;
        private readonly AppDbContext _appDbContext;

        public EfUnitOfWork(AppDbContext appDbContext) {
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

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
