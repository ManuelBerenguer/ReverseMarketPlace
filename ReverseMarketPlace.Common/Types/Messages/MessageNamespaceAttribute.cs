using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.Messages
{
    /// <summary>
    /// Attribute that can be used in the command types to specify a custom namespace for them in the message broker
    /// </summary>
    public class MessageNamespaceAttribute : Attribute
    {
        public string Namespace { get; }

        public MessageNamespaceAttribute(string @namespace)
        {
            Namespace = @namespace?.ToLowerInvariant();
        }
    }
}
