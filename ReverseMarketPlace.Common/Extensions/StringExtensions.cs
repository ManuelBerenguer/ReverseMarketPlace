using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseMarketPlace.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Modifies 
        /// </summary>
        /// <param name="value">The string to modify with this extension method</param>
        /// <returns>The string modified</returns>
        public static string Underscore(this string value)
            => string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));
    }
}
