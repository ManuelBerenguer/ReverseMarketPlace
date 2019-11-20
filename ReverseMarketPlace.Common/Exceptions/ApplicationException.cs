using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Exceptions
{
    public abstract class ApplicationException : Exception
    {
        internal ApplicationException(string businessMessage) : base(businessMessage) { }
    }
}
