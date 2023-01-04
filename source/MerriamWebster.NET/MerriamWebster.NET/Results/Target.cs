using System;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Matching target entry in other Merriam-Webster data set.
    /// </summary>
    public class Target
    {
        /// <summary>
        ///  Target entry universally unique identifier.
        /// </summary>
        public Guid Identifier { get; set; }

        /// <summary>
        /// Target entry source data set.
        /// </summary>
        public string Source { get; set; }
    }
}
