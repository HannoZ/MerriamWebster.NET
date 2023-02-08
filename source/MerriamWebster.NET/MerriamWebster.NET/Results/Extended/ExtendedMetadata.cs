using System;
using System.Collections.Generic;

namespace MerriamWebster.NET.Results.Extended
{
    public class ExtendedMetadata
    {
        /// <summary>
        /// Lists all synonyms given in the entry's <i>syn_list</i>; may be used for matching synonym search terms to the entry.        
        /// </summary>
        /// <remarks>
        /// <i>Note</i>: this is a distinct usage from that described in <see cref="Synonym"/>
        /// </remarks>
        public ICollection<string>? Synonyms { get; set; } = new List<string>();

        /// <summary>
        /// Lists all antonyms given in the entry's <i>ant_list</i>; may be used for matching antonym search terms to the entry.        
        /// </summary>
        public ICollection<string>? Antonyms { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the target entry.
        /// </summary>
        public Target? Target { get; set; }

    }
}
