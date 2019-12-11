using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Exceptions
{
    public class AttributeValueNotValidException : ApplicationException
    {
        internal AttributeValueNotValidException(string message) : base(message) { }

        internal AttributeValueNotValidException(string message, Exception ex) : base(message, ex) { }
    }
}
