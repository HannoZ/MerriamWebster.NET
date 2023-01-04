using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// <i>Optional.</i> This note provides explanatory or historical information that supplements the definition text.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Typically displayed after a newline and in normal font. May be preceded with introductory text such as "Note: ".
    /// </remarks>
    public class SupplementalInformationNote : IDefiningText
    {
        /// <summary>
        /// The supplemental information note text
        /// </summary>
        public FormattedText Text { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the run-in word.
        /// </summary>
        public RunInWord RunIn { get; set; }

        /// <summary>
        /// <i>Optional.</i>A collection of verbal illustrations (examples).
        /// </summary>
        public ICollection<VerbalIllustration> VerbalIllustrations { get; set; }

        /// <inheritdoc />
        public FormattedText MainText => Text;
    }
}