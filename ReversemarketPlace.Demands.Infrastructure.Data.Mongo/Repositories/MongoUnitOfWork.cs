using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Demands.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReversemarketPlace.Demands.Infrastructure.Data.Mongo.Repositories
{
    public class MongoUnitOfWork : IUnitOfWork
    {
        private IDemandsRepository _demandsRepository;

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
    }
}
