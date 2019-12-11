using ReverseMarketPlace.Demands.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.UseCases.ProductTypes
{
    public interface IAttributesBelongToProductTypeUseCase
    {
        Task<bool> ExecuteAsync(ProductType productType, ICollection<Guid> attributeIds);
    }
}
