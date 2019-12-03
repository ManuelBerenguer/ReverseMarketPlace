using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseMarketPlace.Demands.Core.Entities;

namespace ReverseMarketPlace.Demands.Core.UseCases.Category
{
    public class AttributesBelongToCategoryUseCase : IAttributesBelongToCategoryUseCase
    {
        public async Task<bool> ExecuteAsync(Entities.Category category, ICollection<int> attributeIds)
        {
            _ = category ?? throw new ArgumentNullException(nameof(category));
            _ = attributeIds ?? throw new ArgumentNullException(nameof(attributeIds));

            var categoryAttributesId = category.CategoryAttributes.Select(catAttr => catAttr.Attribute.Id);
            foreach (var attributeId in attributeIds)
            {
                if (!categoryAttributesId.Contains(attributeId)) // If the attribute is not allowed for that category
                    return false;
            }

            return true;
        }
    }
}
