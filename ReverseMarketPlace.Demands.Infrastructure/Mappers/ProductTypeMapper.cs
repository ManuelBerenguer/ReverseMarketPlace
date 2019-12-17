using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Mappers
{
    public class ProductTypeMapper
    {
        public static Core.Domain.ProductType MapFrom(EF.Persistance_Models.ProductType productType)
        {
            return new Core.Domain.ProductType(productType.Id, productType.Name, productType.CategoryId, 
                productType.ProductTypeAttributes.Select(pta => AttributeMapper.MapFrom(pta.Attribute)).ToList());
        }
    }
}
