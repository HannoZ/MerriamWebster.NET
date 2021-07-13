using System.Collections.Generic;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// A run-in entry word is a defined word that occurs in the running text of an entry.
    /// The run-in ri groups together one or more run-in entry words rie and any accompanying pronunciations or variants.
    /// Run-ins occur most frequently in geographical entries.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Inline in normal font, except for <see cref="RunInEntry"/> which is typically displayed in bold.
    /// </remarks>
    public class RunInWord : IDefiningText
    {
        /// <summary>
        /// run-in entry word
        /// </summary>
        public string RunInEntry { get; set; }

        /// <summary>
        /// intervening text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets a collection of pronunciations.
        /// </summary>
        /// <remarks>Usually there is only 1 pronunciation</remarks>
        public ICollection<Pronunciation> Pronunciations { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the variants.
        /// </summary>
        public ICollection<Variant> Variants { get; set; }


        /// <inheritdoc />
        public FormattedText MainText => Text;
    }
}