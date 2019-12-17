using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Domain;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Data;
using ReverseMarketPlace.Demands.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Category = ReverseMarketPlace.Demands.Core.Domain.Category;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Repositories
{
    public class EfCategoriesRepository : ICategoriesRepository
    {
        protected readonly DemandsDbContext _dbContext;

        public EfCategoriesRepository(DemandsDbContext appDbContext) {
            _dbContext = appDbContext;
        }

        public async Task<Category> GetByIdAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
