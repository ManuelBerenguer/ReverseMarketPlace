﻿using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = ReverseMarketPlace.Demands.Core.Entities.Attribute;

namespace ReverseMarketPlace.Demands.Infrastructure.Repositories
{
    public class EfAttributesRepository : EfRepository<Attribute>, IAttributesRepository
    {
        public EfAttributesRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<IEnumerable<Core.Entities.Attribute>> GetAttributesByIds(IEnumerable<int> ids)
        {
            return await _dbContext.Attributes.Where(att => ids.Contains(att.Id)).ToListAsync();
        }
    }
}
