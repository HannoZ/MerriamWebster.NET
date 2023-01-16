using MerriamWebster.NET.Parsing;
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
        /// Gets or set the defining texts.
        /// </summary>
        public ICollection<IDefiningText> DefiningTexts { get; set; } = new List<IDefiningText>();

        /// <inheritdoc />}
        public FormattedText MainText => "⟶ " + DefiningTexts.Build();
    }
}