using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseMarketPlace.Demands.Core.Domain;
using ReverseMarketPlace.Demands.Core.Entities;

namespace ReverseMarketPlace.Demands.Core.UseCases.ProductTypes
{
    public class AttributesBelongToProductTypeUseCase : IAttributesBelongToProductTypeUseCase
    {
        public async Task<bool> ExecuteAsync(ProductType productType, ICollection<Guid> attributeIds)
        {
            _ = productType ?? throw new ArgumentNullException(nameof(productType));
            _ = attributeIds ?? throw new ArgumentNullException(nameof(attributeIds));

            var productTypeAttributeIds = productType.Attributes.Select(ptAttr => ptAttr.Id);
            foreach (var attributeId in attributeIds)
            {
                if (!productTypeAttributeIds.Contains(attributeId)) // If the attribute is not allowed for that productType
                    return false;
            }

            return true;
        }
    }
}
