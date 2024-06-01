using System;
using System.Collections.Generic;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Entry metadata is information about the entry, as opposed to the actual content of the entry.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Not intended for display.
    /// </remarks>
    public class Metadata
    {
        /// <summary>
        /// Creates a new instance of <see cref="Metadata"/>.
        /// </summary>
        public Metadata()
        {
            Id = string.Empty;
            Sort = string.Empty;
            Source = string.Empty;
            Section = string.Empty;
        }

        /// <summary>
        /// Unique entry identifier within a particular dictionary data set, used in cross-references pointing to the entry. It consists of the headword, and in homograph entries, an appended colon and homograph number.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Universally unique identifier
        /// </summary>
        public Guid UniqueIdentifier { get; set; }

        /// <summary>
        /// A 9-digit code which may be used to sort entries in the proper dictionary order if alphabetical display is needed.
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Source data set for entry — ignore
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Indicates the section the entry belongs to in print.
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Lists all of the entry's headwords, variants, inflections, undefined entry words, and defined run-on phrases.
        /// Each stem string is a valid search term that should match this entry.
        /// </summary>
        public ICollection<string>? Stems { get; set; } = [];

        /// <summary>
        /// <c>True</c> if there is a label containing "offensive" in the entry; otherwise, <c>False</c>.
        /// </summary>
        public bool Offensive { get; set; }

        /// <summary>
        /// <i>Optional.</i> Lists all synonyms given in the entry's <i>syn_list</i>; may be used for matching synonym search terms to the entry.        
        /// </summary>
        /// <remarks>
        /// <i>Note</i>: this is a distinct usage from that described in <see cref="Synonym"/>
        /// </remarks>
        public ICollection<string>? Synonyms { get; set; } = [];

        /// <summary>
        /// <i>Optional.</i> Lists all antonyms given in the entry's <i>ant_list</i>; may be used for matching antonym search terms to the entry.        
        /// </summary>
        public ICollection<string>? Antonyms { get; set; } = [];

        /// <summary>
        /// <i>Optional.</i> Gets or sets the target entry.
        /// </summary>
        public Target? Target { get; set; }

        /// <summary>
        /// <i>Spanish-English only.</i> Bilingual dictionaries contain two distinct dictionaries within one work.
        /// In order to distinguish the two language directions for search and display purposes, an entry metadata item identifying the language of the entry's headword—or the language of word lookup as opposed to translation—is provided. 
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Not intended for display as such, but may be useful if different rendering is desired for Spanish-English entries than for English-Spanish.
        /// <para>
        /// Contains an ISO 639-1 language code corresponding to the language of the entry's headword, ie, the language in which the user wishes to look up a word in order to get a translation to another language.
        /// </para>
        /// </remarks>
        public Language? Language { get; set; }
    }
}