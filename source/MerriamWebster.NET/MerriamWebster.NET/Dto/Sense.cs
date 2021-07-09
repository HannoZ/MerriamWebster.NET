using System.Collections.Generic;

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
    public class Sense : SenseBase
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
        /// <i>Optional.</i> The divided sense contains at least a new <see cref="SenseBase.Text"/> but can also contain other properties that can also be present on regular senses.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// The divided sense should be inline with the preceding <see cref="SenseBase.Text"/>.
        /// The <see cref="DividedSense.SenseDivider"/> is displayed in italics, preceded by a semicolon and space, and followed by a space.
        /// </remarks>
        public DividedSense DividedSense { get; set; }

        /// <summary>
        /// A truncated sense is a sense without a definition, and is used almost exclusively when two sense numbers are separated by a non-definition element.
        /// For instance, if a pronunciation occurs in between a main sense number and a subsense containing a definition, the truncated sense consists of the main sense number and the pronunciation.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Handle the same as regular senses.
        /// </remarks>
        public bool IsTruncatedSense { get; set; }

        /// <summary>
        /// A broad, general sense introducing a series of senses that give more contextual and specific meanings.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Inline in normal font
        /// </remarks>
        /// <example>
        /// This sense of "feline" provides an example:
        /// The sense sequence contains 4 elements, first the binding substitute (sn 2), followed by three regular senses (sn a,b,c)
        /// 2 : resembling a cat: such as a : sleekly graceful b : sly, treacherous c : stealthy
        ///  
        /// The text "resembling a cat: such as " is the binding substitute for the senses that follow.
        /// </example>
        public bool IsBindingSubstitute { get; set; }

        /// <summary>
        /// <i>Optional.</i> Getsd or sets a collection of synonyms.
        /// </summary>
        /// <remarks>
        /// A thesaurus entry typically contains a list of synonyms for the headword.
        /// </remarks>
        public ICollection<string> Synonyms { get; set; } = new List<string>();
     
        /// <summary>
        /// <i>Optional.</i> Getsd or sets a collection of cross references.
        /// </summary>
        public ICollection<CrossReference> CrossReferences { get; set; }

    }
}