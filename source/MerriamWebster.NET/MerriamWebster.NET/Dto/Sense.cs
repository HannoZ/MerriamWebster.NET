using System.Collections.Generic;
using MerriamWebster.NET.Parsing;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// The sense gathers together all content relevant to a particular meaning of a headword or defined run-on phrase.
    /// The <see cref="Sense"/> is a key organizational unit of the <see cref="Entry"/>, and gathers together all content relevant to a particular meaning of a headword.
    /// </summary>
    public class Sense
    {
        /// <summary>
        /// The text as it comes from the source.
        /// </summary>
        public string RawText { get; set; }
        /// <summary>
        /// If <see cref="ParseOptions"/> is configured to remove markup, this contains the formatted text. The <see cref="RawText"/> still contains the unformmated text. 
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// A collection of <see cref="Example"/>s. Optional.
        /// </summary>
        public ICollection<Example> Examples { get; set; } = new List<Example>();
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
    }
}