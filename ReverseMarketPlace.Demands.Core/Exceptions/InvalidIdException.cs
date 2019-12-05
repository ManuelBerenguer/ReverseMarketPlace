using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Exceptions
{
    public class InvalidIdException : ApplicationException
    {
        internal InvalidIdException(string message) : base(message)
        { }
    }
}
