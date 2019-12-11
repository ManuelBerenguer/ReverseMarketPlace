using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Exceptions
{
    public class ProductTypeNotFoundException : ApplicationException
    {
        internal ProductTypeNotFoundException(string message) : base(message) { }
    }
}
