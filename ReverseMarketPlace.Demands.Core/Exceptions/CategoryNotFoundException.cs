using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Exceptions
{
    public class CategoryNotFoundException : ApplicationException
    {
        internal CategoryNotFoundException(string message) : base(message)
        { }
    }
}
