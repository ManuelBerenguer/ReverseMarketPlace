using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Attribute = ReverseMarketPlace.Demands.Core.Domain.Attribute;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface IAttributesRepository
    {
        Task<IEnumerable<Attribute>> GetAttributesByIds(IEnumerable<Guid> ids);
    }
}
