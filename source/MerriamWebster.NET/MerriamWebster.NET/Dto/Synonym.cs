using System.Collections.Generic;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// Extensive discussions of synonyms for the headword may be included in the entry.
    /// A set of such synonym discussions makes up a synonym section, which is contained in this class
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    /// Typically displayed in a separate paragraph with a heading such as "Synonym Discussion of [headword]".
    /// </para>
    /// <para>
    /// A <see cref="SeeInAdditionReference"/> is preceded by "synonyms " in bold, then "see in addition " in normal font,
    /// then the <see cref="SeeInAdditionReference"/> elements rendered as hyperlinks to other synonym sections.
    /// </para>
    /// </remarks>
    public class Synonym
    {
        /// <summary>
        /// paragraph label: heading to display at top of section
        /// </summary>
        public Label ParagraphLabel { get; set; }

        /// <summary>
        /// paragraph text 
        /// </summary>
        public ICollection<IDefiningText> DefiningTexts { get; set; } = new List<IDefiningText>();

        /// <summary>
        /// see in addition reference: contains one or more elements, each of which is the text and ID of a "see in addition" reference to another synonym section.
        /// </summary>
        public ICollection<string> SeeInAdditionReference { get; set; }
    }
}