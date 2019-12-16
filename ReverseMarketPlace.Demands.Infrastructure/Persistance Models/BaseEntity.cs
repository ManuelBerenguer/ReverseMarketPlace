using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
