using System.Collections.Generic;
using MerriamWebster.NET.Parsing;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// The sense gathers together all content relevant to a particular meaning of a headword or defined run-on phrase.
    /// The <see cref="Sense"/> is a key organizational unit of the <see cref="Definition"/>, and gathers together all content relevant to a particular meaning of a headword.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// A typical implementation might generate a newline at a top-level numbered sense, while keeping further nested subsenses inline.
    /// </remarks>
    public class Sense
    {
        /// <summary>
        /// The sense number identifies a sense or subsense within the entry.
        /// A sense number may contain bold Arabic numerals, bold lowercase letters, or parenthesized Arabic numerals.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// The sense number is typically displayed in bold.
        /// </remarks>
        public string SenseNumber { get; set; }

        /// <summary>
        /// The text as it comes from the source.
        /// </summary>
        public string RawText { get; set; }
        /// <summary>
        /// The defining text is the text of the definition or translation for a particular sense.
        /// </summary>
        /// <remarks>
        /// <para>
        /// <b>Display Guidance:</b>
        /// Inline in normal font
        /// </para>
        /// <para>
        /// If <see cref="ParseOptions"/> is configured to remove markup, this contains the formatted text. The <see cref="RawText"/> still contains the unformatted text. 
        /// </para>
        /// </remarks>
        public string Text { get; set; }
        /// <summary>
        /// If <see cref="ParseOptions"/> is configured to replace markup, this contains the text with MW-specific markup replace by HTML markup. The <see cref="RawText"/> still contains the unformmated text. 
        /// </summary>
        public string HtmlText { get; set; }

        /// <summary>
        /// A sense may be divided into two parts to show a particular relationship between two closely related meanings.
        /// The second part of the sense is contained in an <see cref="DividedSense"/>.
        /// </summary>
        public string SenseDivider { get; set; }

        /// <summary>
        /// The divided sense contains at least a new <see cref="Text"/> but can also contain other properties that can also be present on regular senses.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// The divided sense should be inline with the preceding <see cref="Text"/>.
        /// The <see cref="SenseDivider"/> is displayed in italics, preceded by a semicolon and space, and followed by a space.
        /// </remarks>
        public Sense DividedSense { get; set; }

        /// <summary>
        /// A truncated sense is a sense without a definition, and is used almost exclusively when two sense numbers are separated by a non-definition element.
        /// For instance, if a pronunciation occurs in between a main sense number and a subsense containing a definition, the truncated sense consists of the main sense number and the pronunciation.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Handle the same as regular senses.
        /// </remarks>
        public Sense TruncatedSense { get; set; }

        /// <summary>
        /// A collection of <see cref="VerbalIllustration"/>s. Optional.
        /// If <see cref="ParseOptions"/> is configured to replace markup, this contains the formatted text with markup being replaced by HTML tags.
        /// The <see cref="RawText"/> still contains the unformatted text. 
        /// </summary>
        public ICollection<VerbalIllustration> Examples { get; set; } = new List<VerbalIllustration>();
        /// <summary>
        /// A collection of synonyms. Optional.
        /// </summary>
        /// <remarks>
        /// A thesaurus entry typically contains a list of synonyms for the headword.
        /// </remarks>
        public ICollection<string> Synonyms { get; set; } = new List<string>(); 
        /// <summary>
        /// A collection of cross references.
        /// </summary>
        public ICollection<CrossReference> CrossReferences { get; set; } = new List<CrossReference>();
        /// <summary>
        /// This property contains additional information that describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        public ICollection<string> AdditionalInformation { get; set; } = new List<string>();

        /// <summary>
        /// General labels provide information such as whether a headword is typically capitalized, used as an attributive noun, etc.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Typically rendered in italics. If there is a more than one element in the array, separate them with a comma and space.
        /// </remarks>
        public ICollection<Label> GeneralLabels { get; set; }

        /// <summary>
        /// A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Typically rendered in italics. If there is a more than one element in the array, separate them with a comma and space.
        /// </remarks>
        public ICollection<Label> SubjectStatusLabels { get; set; }
    }
}