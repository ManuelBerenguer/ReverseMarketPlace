using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.UseCases.Category
{
    public interface IAttributesBelongToCategoryUseCase
    {
        Task<bool> ExecuteAsync(Entities.Category category, ICollection<int> attributeIds);
    }
}
