using ReverseMarketPlace.Common.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Entities
{
    public class Offer : BaseEntity
    {
        [Required]
        public float Price { get; private set; }

        
    }
}
