using System.Collections.Generic;
using MerriamWebster.NET.Parsing;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// In addition to <see cref="UsageNote"/> within definitions, a more extensive usage discussion may be included in the entry.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    /// Typically displayed in a separate paragraph, using the <see cref="ParagraphLabel"/> contents as a heading.
    /// </para>
    /// <para>
    /// A <see cref="InAdditionReference"/> element is preceded by "usage " in bold, then "see in addition " in normal font,
    /// followed by one or more <see cref="InAdditionReference"/> members rendered as hyperlinks to other usage sections.
    /// </para>
    /// </remarks>
    public class Usage
    {
        /// <summary>
        /// paragraph label: heading to display at top of section
        /// </summary>
        public FormattedText ParagraphLabel { get; set; }

        /// <summary>
        /// paragraph text containing the elements <see cref="DefiningText"/>, <see cref="VerbalIllustration"/>, <see cref="InAdditionReference"/> (not yet implemented)
        /// </summary>
        public ICollection<IDefiningText> ParagraphTexts { get; set; } = new List<IDefiningText>();

        /// <summary>
        /// Experimental feature! A summary of the <see cref="ParagraphTexts"/> content.
        /// </summary>
        [JsonIgnore]
        public FormattedText Summary => ParagraphTexts.Build();
    }
}