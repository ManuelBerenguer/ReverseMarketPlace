using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Extensions
{
    /// <summary>
    /// Extensions for Object
    /// </summary>
    public static class ObjectExtensions
    {
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
    }
}
