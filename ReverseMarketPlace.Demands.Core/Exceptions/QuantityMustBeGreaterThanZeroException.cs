using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Exceptions
{
    public class QuantityMustBeGreaterThanZeroException : ApplicationException
    {
        internal QuantityMustBeGreaterThanZeroException(string message) : base(message)
        { }
    }
}
