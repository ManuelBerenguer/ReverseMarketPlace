using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.Entities
{
    public abstract class BaseEntity : IIdentifiable
    {
        public Guid Id { get; protected set; }

        protected void SetId(Guid id)
        {
            if (id == null || id == Guid.Empty)
                throw new ArgumentException(nameof(id));

            Id = id;
        }
    }
}
