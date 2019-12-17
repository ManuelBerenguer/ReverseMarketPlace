using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Domain;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Data;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Repositories
{
    public class EfDemandsRepository : IDemandsRepository
    {
        protected readonly DemandsDbContext _dbContext;

        public EfDemandsRepository(DemandsDbContext appDbContext) {
            _dbContext = appDbContext;
        }

        public async Task AddAsync(Core.Domain.Demand demand)
        {                        
            List<EF.Persistance_Models.DemandAttributeValue> demandAttributeValues = 
                demand.Attributes.Select(att => new EF.Persistance_Models.DemandAttributeValue(att, demand.Id)).ToList();

            EF.Persistance_Models.Demand newDemand = new EF.Persistance_Models.Demand(demand, demandAttributeValues);

            await _dbContext.Demands.AddAsync(newDemand);
            await _dbContext.SaveChangesAsync(); // We save with transaction because is an aggregate root
        }

        public async Task<IEnumerable<Demand>> GetBuyerDemands(Guid buyerId)
        {
            var buyerDemands = await _dbContext.Demands.Where(d => d.BuyerId.Equals(buyerId)).Include(d => d.DemandAttributeValues).ThenInclude(dav => dav.Attribute).ToListAsync();
                        
            return buyerDemands.Select(d => DemandMapper.MapFrom(d));
        }
                        
    }
}
