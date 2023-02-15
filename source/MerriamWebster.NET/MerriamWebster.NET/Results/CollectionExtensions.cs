using System.Collections.Generic;
using System.Linq;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Container class for Collection extensions methods
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Safely checks if source collection has a value, even if source is null. 
        /// </summary>
        /// <returns><c>true</c> if collection contains at least one element, otherwise <c>false</c></returns>
        public static bool HasValue<T>(this ICollection<T>? source)
        {
            return source?.Any() == true;
        }
    }
}
