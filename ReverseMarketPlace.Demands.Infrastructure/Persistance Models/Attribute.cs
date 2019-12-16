using ReverseMarketPlace.Demands.Core.Enums.Demands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Persistance_Models
{
    public class Attribute : BaseEntity
    {
        /// <summary>
        /// Attribute name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Data type of the value 
        /// </summary>
        [Required]
        public AttributeDataTypeEnum DataType { get; set; }

        private Attribute() { }
    }
}
