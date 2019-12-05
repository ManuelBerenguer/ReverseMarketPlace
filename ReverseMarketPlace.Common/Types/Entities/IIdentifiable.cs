using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.Entities
{
    /// <summary>
    /// Defines how we identify any entity of our domain
    /// </summary>
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
