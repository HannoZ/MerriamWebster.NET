using System.Collections.Generic;

namespace MerriamWebster.NET.Results.Base
{
    /// <summary>
    /// The organizational unit of a dictionary. An entry consists of at minimum a headword, along with content defining or translating the headword.
    /// </summary>
    /// <remarks>
    /// A dictionary entry has many properties, but many appear only in specific APIs. (eg. <see cref="Conjugations"/> only appear in the Spanish-English dictionary)
    /// </remarks>
    public class Entry : EntryBase
    {
        /// <summary>
        /// <i>Optional.</i> Gets or sets the quotes.
        /// </summary>
        public ICollection<Quote> Quotes { get; internal set; }
        
        /// <summary>
        /// <i>Optional.</i> Gets or sets the etymology.
        /// </summary>
        public Etymology Etymology { get; internal set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the artwork.
        /// </summary>
        public Artwork Artwork { get; internal set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets synonyms.
        /// </summary>
        public ICollection<Synonym> Synonyms { get; internal set; }

        /// <summary>
        /// <i>Optional.</i> Directional cross-references to other entries may be presented after the main definition section.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Display in a separate paragraph.
        /// </remarks>
        public ICollection<FormattedText> DirectionalCrossReferences { get; internal set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the usages. 
        /// </summary>
        public ICollection<Usage> Usages { get; internal set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets a table.
        /// </summary>
        public Table Table { get; internal set; }

        /// <summary>
        /// <i>Optional, medical dictionary only.</i> Gets or sets biographical notes.
        /// </summary>
        public BiographicalNote BiographicalNote { get; internal set; }


    }
}