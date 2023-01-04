using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Provide usage information on a headword, <see cref="DefinedRunOn"/> phrase, or <see cref="UndefinedRunOn"/> word.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// A usage note is typically displayed inline in normal font, preceded by a space and an em-dash.
    /// </remarks>
    public class UsageNote : IDefiningText
    {
        /// <summary>
        /// contains the usage note text.
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