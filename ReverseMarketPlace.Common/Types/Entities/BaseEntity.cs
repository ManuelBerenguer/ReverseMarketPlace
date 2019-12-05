using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.Entities
{
    public abstract class BaseEntity : IIdentifiable
    {
        public Guid Id { get; protected set; }
    }
}
