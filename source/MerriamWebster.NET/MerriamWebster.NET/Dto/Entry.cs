using System.Collections.Generic;
using System.Linq;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// An <see cref="Entry"/> is the main object of a search result. <br/>
    /// The organizational unit of a dictionary. An entry consists of at minimum a headword, along with content defining or translating the headword
    /// </summary>
    /// <remarks>An <see cref="Entry"/> has many properties, but many appear only in specific apis. (eg. <see cref="Conjugations"/> only appear in the Spanish-English dictionary)</remarks>
    public class Entry
    {
        /// <summary>
        /// Gets or sets the entry id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the text (headword, phrase). 
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets the language
        /// </summary>
        /// <remarks>Spanish-English dictionary only.</remarks>
        public Language Language { get; set; }
        /// <summary>
        /// Gets or sets the part of speech.
        /// </summary>
        public string Pos { get; set; }
        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        public string SubCategory { get; set; }
        /// <summary>
        /// Gets or sets a collection of pronunciations.
        /// </summary>
        /// <remarks>Usually there is only 1 pronunciation</remarks>
        public ICollection<Pronunciation> Pronunciations { get; set; } = new List<Pronunciation>();
        /// <summary>
        /// Lists all of the entry's headwords, variants, inflections, undefined entry words, and defined run-on phrases
        /// </summary>
        public ICollection<string> Stems { get; set; } = new List<string>();
        /// <summary>
        /// Gets or sets the language
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="Sense"/>s.
        /// </summary>
        public ICollection<Sense> Senses { get; set; } = new List<Sense>();
        /// <summary>
        /// Gets or sets the <see cref="Dto.Conjugations"/>
        /// </summary>
        public Conjugations Conjugations { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="CrossReference"/>s.
        /// </summary>
        public ICollection<CrossReference> CrossReferences { get; set; } = new List<CrossReference>();
        /// <summary>
        /// Gets or sets a collection of short definitions.
        /// </summary>
        public ICollection<string> ShortDefs { get; set; } = new List<string>();
        /// <summary>
        /// Gets or sets a collection of synonyms.
        /// </summary>
        public ICollection<string> Synonyms { get; set; } = new List<string>();
        /// <summary>
        /// Gets or sets a collection of antonyms.
        /// </summary>
        public ICollection<string> Antonyms { get; set; } = new List<string>();

        /// <summary>
        /// The summary is the content of all <see cref="Senses"/> with non-empty Text properties.
        /// </summary>
        public string Summary => string.Join(", ", Senses.Where(s => !string.IsNullOrEmpty(s.Text)).Select(s => s.Text));
    }
}