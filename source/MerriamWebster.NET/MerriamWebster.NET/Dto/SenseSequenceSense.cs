using System.Collections.Generic;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// We need this class to be able to group parenthesized sense sequences together with regular senses in the same collection.
    /// This is important, because order is important (for example in 'color' we first have a senses, followed by a parenthesized sense sequence, followed by more regular senses
    /// </summary>
    public class SenseSequenceSense
    {
        /// <summary>
        /// Flag that indicates if this is a parenthesized sense sequence
        /// </summary>
        public bool IsParenthesizedSenseSequence { get; set; }

        /// <summary>
        /// Gets or sets the senses. This property only has content if <see cref="IsParenthesizedSenseSequence"/> is <c>true</c>.
        /// </summary>
        public ICollection<SenseSequenceSense> Senses { get; set; }
    }
}