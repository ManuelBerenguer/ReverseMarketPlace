using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Constants
{
    public static class ExceptionConstants
    {
        /* Demands */
        public const string QuantityMustBeGreaterThanZero = "Quantity Must Be Grater Than Zero";
        public const string DemandNotFound = "Demand Not Found";
        public const string DuplicatedDemand = "Duplicated Demand";

        /* Categories */
        public const string CategoryNotFound = "Category Not Found";

        /* Product Types */
        public const string ProductTypeNotFound = "Product Type Not Found";

        /* Product Types Attributes */
        public const string ProductTypeAttributeNotFound = "Product Type Attribute Not Found";

        /* Attributes */
        public const string AttributeValueNotValid = "Attribute Value Not Valid";        
    }
}
