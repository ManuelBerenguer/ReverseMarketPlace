using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseMarketPlace.Common.Extensions
{
    /// <summary>
    /// Extensions for IEnumerable
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Returns an empty IEnumerable of type T if the collection is null 
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="source">Collection to evaluate if is null</param>
        /// <returns>The collection if is not null, otherwise an empty collection</returns>
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Checks if a collection is empty or null
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="source">Collection to evaluate if is empty or null</param>
        /// <returns>true if is empty or null, false otherwise</returns>
        public static bool EmptyOrNull<T>(this IEnumerable<T> source)
        {
            return ((source == null || source.Count() == 0) ? true : false);
        }

        /// <summary>
        /// Checks if a collection is null
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="source">Collection to evaluate if is null</param>
        /// <returns>True if the collection is null, false otherwise</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return (source == null);
        }
    }
}
