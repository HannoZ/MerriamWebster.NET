using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// The sense sequence contains a series of senses and subsenses, ordered by sense numbers beginning at Arabic numeral "1".
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// See <see cref="Sense"/>.
    /// </remarks>
    public class SenseSequence
    {
        /// <summary>
        /// Gets or sets the senses.
        /// </summary>
        public ICollection<SenseSequenceSense> Senses { get; set; } = [];
    }
}