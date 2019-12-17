﻿using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.Repositories
{
    public class EfGroupRepository
    {
        protected readonly AppDbContext _dbContext;

        public EfGroupRepository(AppDbContext appDbContext) {
            _dbContext = appDbContext;
        }

        
    }
}
