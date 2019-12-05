﻿using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.Repositories
{
    public class EfUnitOfWork : IUnitOfWorkOld
    {
        private IDemandsRepositoryOld _demandsRepository;
        private ICategoriesRepository _categoriesRepository;
        private IAttributesRepository _attributesRepository;
        private ICategoryAttributesRepository _categoryAttributesRepository;
        private IDemandGroupsRepository _demandGroupsRepository;
        private IGroupRepository _groupRepository;
        private readonly AppDbContext _appDbContext;

        public EfUnitOfWork(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public IDemandsRepositoryOld DemandsRepository {
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

        public IAttributesRepository AttributesRepository
        {
            get
            {
                if( _attributesRepository.IsNull() )
                {
                    _attributesRepository = new EfAttributesRepository(_appDbContext);
                }

                return _attributesRepository;
            }
        }

        public ICategoryAttributesRepository CategoryAttributesRepository
        {
            get
            {
                if (_categoryAttributesRepository.IsNull())
                {
                    _categoryAttributesRepository = new EfCategoryAttributesRepository(_appDbContext);
                }

                return _categoryAttributesRepository;
            }
        }

        public IDemandGroupsRepository DemandGroupsRepository
        {
            get
            {
                if (_demandGroupsRepository.IsNull())
                {
                    _demandGroupsRepository = new EfDemandGroupsRepository(_appDbContext);
                }

                return _demandGroupsRepository;
            }
        }

        public IGroupRepository GroupRepository
        {
            get
            {
                if (_groupRepository.IsNull())
                {
                    _groupRepository = new EfGroupRepository(_appDbContext);
                }

                return _groupRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
