using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Exceptions
{
    public class CategoryAttributeNotFoundException : ApplicationException
    {
        internal CategoryAttributeNotFoundException(string message) : base(message)
        { }
    }
}
