using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models
{
    public abstract class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
