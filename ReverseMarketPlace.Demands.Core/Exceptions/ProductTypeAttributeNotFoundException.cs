using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Exceptions
{
    public class ProductTypeAttributeNotFoundException : ApplicationException
    {
        internal ProductTypeAttributeNotFoundException(string message) : base(message)
        { }
    }
}
