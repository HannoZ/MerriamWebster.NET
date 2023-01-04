using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// The headword is the word being defined or translated in a dictionary entry. Key headword information is grouped in an hwi object.
    /// This includes the headword itself in the hw member, and may include one or more pronunciations in prs.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// The headword is prominently highlighted to the user; this is typically achieved through the use of bold, large point size, distinctive font, etc.
    /// </remarks>
    public class HeadwordInformation
    {
        /// <summary>
        /// Gets or sets the text (headword, phrase). 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a collection of pronunciations.
        /// </summary>
        /// <remarks>Usually there is only 1 pronunciation</remarks>
        public ICollection<Pronunciation> Pronunciations { get; set; } = new List<Pronunciation>();

        /// <summary>
        /// <i>Optional.</i> A parenthesized subject/status label describes the subject area or regional/usage status (eg, "British") of a headword or other defined term, and is displayed in parentheses.<br/>
        /// The parenthesized subject/status label is contained in a <see cref="ParenthesizedSubjectStatusLabel"/>.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Display within parentheses and in italics.
        /// </remarks>
        public Label ParenthesizedSubjectStatusLabel { get; set; }
    }
}