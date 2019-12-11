using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Demands.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReversemarketPlace.Demands.Infrastructure.Data.Mongo.Repositories
{
    public class MongoUnitOfWork : IUnitOfWork
    {
        private IDemandsRepository _demandsRepository;
        private ICategoriesRepository _categoriesRepository;

        public IDemandsRepository DemandsRepository
        {
            get
            {
                if (_demandsRepository.IsNull())
                {
                    _demandsRepository = new MongoDemandsRepository(null);
                }

                return _demandsRepository;
            }
        }

        public ICategoriesRepository CategoriesRepository
        {
            get
            {
                if (_categoriesRepository.IsNull())
                {
                    _categoriesRepository = null;
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
