using System.Collections.Generic;

namespace MerriamWebster.NET.Results.Base
{

    public class Entry : EntryBase
    {
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
        /// <i>Optional.</i> Gets or sets synonyms.
        /// </summary>
        public ICollection<Synonym> Synonyms { get; internal set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the quotes.
        /// </summary>
        public ICollection<Quote> Quotes { get; internal set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the artwork.
        /// </summary>
        public Artwork Artwork { get; internal set; }

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