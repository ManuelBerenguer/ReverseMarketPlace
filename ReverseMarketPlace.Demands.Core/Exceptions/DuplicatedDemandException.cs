using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Exceptions
{
    public class DuplicatedDemandException : ApplicationException
    {
        internal DuplicatedDemandException(string message) : base(message) { }
    }
}
