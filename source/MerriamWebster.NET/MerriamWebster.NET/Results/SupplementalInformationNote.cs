using MerriamWebster.NET.Parsing;
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
        /// Gets or set the defining texts.
        /// </summary>
        public ICollection<IDefiningText> DefiningTexts { get; set; } = new List<IDefiningText>();
     
        /// <inheritdoc />
        public FormattedText MainText => "Note: " + DefiningTexts.Build();
    }
}