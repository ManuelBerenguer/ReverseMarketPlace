using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Mappers
{
    public class DemandMapper
    {
        public static Core.Domain.Demand MapFrom(EF.Persistance_Models.Demand demand)
        {
            return new Core.Domain.Demand(demand.Id, demand.BuyerId, demand.ProductTypeId, demand.Quantity, 
                demand.DemandAttributeValues.Select(dav => AttributeMapper.MapFrom(dav)).ToList());
        }
    }
}
