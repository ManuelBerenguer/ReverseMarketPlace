using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Exceptions
{
    public class DemandNotFoundException : ApplicationException
    {
        internal DemandNotFoundException(string message) : base(message) 
        { }
    }
}
