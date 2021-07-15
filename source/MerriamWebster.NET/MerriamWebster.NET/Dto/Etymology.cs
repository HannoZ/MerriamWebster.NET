using System;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// An explanation of the historical origin of a word.
    /// An etymology might supply, for instance, the French origin of a headword, then further give the Latin origin of that French word.
    /// Also called: word origin.
    /// </summary>
    /// <remarks>
    /// <para>
    /// While the etymology most typically relates to the headword, it may also explain the origin of a defined run-on phrase or a particular sense.
    /// </para>
    /// <b>Display Guidance:</b>
    /// Typically displayed inline within square brackets or in its own block with a heading such as "Word Origin".
    /// </remarks>
    public class Etymology
    {
        /// <summary>
        /// Contains the etymology content.
        /// </summary>
        public FormattedText Text { get; set; } = new FormattedText();

        /// <summary>
        /// <i>Optional.</i> Contains a supplemental information note for the etymology.
        /// </summary>
        public FormattedText Note { get; set; } 
    }
}
