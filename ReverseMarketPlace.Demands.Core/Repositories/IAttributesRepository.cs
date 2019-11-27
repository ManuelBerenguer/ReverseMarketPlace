using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Attribute = ReverseMarketPlace.Demands.Core.Entities.Attribute;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface IAttributesRepository : IRepository<Attribute>
    {
        Task<IEnumerable<Attribute>> GetAttributesByIds(IEnumerable<int> ids);
    }
}
