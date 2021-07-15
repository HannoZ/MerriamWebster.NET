using System.Collections.Generic;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// The organizational unit of a dictionary. An entry consists of at minimum a headword, along with content defining or translating the headword.
    /// </summary>
    /// <remarks>
    /// A dictionary entry has many properties, but many appear only in specific apis. (eg. <see cref="Conjugations"/> only appear in the Spanish-English dictionary)
    /// </remarks>
    public class Entry
    {
        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// <i>Optional.</i> Homographs are headwords with identical spellings but distinct meanings and origins.
        /// The hom member contains a homograph number used to mark and distinguish the identically-spelled headwords.
        /// When homograph is present, the immediately following and/or preceding entry will have an hwi/hw member with an identical value.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// In superscript immediately preceding the hw.
        /// </remarks>
        public int Homograph { get; set; }

        /// <summary>
        /// Gets or sets the headword.
        /// </summary>
        public HeadwordInformation Headword { get; set; } = new HeadwordInformation();

        /// <summary>
        /// Gets or sets the defintions.
        /// </summary>
        public ICollection<Definition> Definitions { get; set; } = new List<Definition>();

        /// <summary>
        /// The date of the earliest recorded use of a headword in English.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Typically displayed inline within parentheses or in its own block with a heading such as "First Known Use".
        /// </remarks>
        public FormattedText Date { get; set; }

        /// <summary>
        /// <i>Optional.</i> An alternate headword is a regional or less common spelling of a headword.
        /// </summary>
        public ICollection<AlternateHeadwordInformation> AlternateHeadwords { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets undefined run-ons.
        /// </summary>
        public ICollection<UndefinedRunOn> UndefinedRunOns { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets defined run-ons.
        /// </summary>
        public ICollection<DefinedRunOn> DefinedRunOns { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the variants.
        /// </summary>
        public ICollection<Variant> Variants { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the inflections.
        /// </summary>
        public ICollection<Inflection> Inflections { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the cross-references.
        /// </summary>
        public ICollection<CrossReference> CrossReferences { get; set; }
        
        /// <summary>
        /// Gets or sets the <i>cognate</i> cross-references.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// If the collection has more than one element, separate them by a comma and space.
        /// </remarks>
        public ICollection<CognateCrossReference> CognateCrossReferences { get; set; }
        
        /// <summary>
        /// Describes the grammatical function of a headword or undefined entry word. It indicates the role the word plays in a sentence, such as "noun", "verb", "adjective", etc.<br/>
        /// It may also categorize the word in other ways, such as "trademark" or "abbreviation". 
        /// </summary>
        /// <remarks>
        /// Also called 'functional label'.<br/>
        /// <b>Display Guidance:</b>
        /// Typically rendered in italics
        /// </remarks>
        public Label PartOfSpeech { get; set; }

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

        /// <summary>
        /// <i>Optional, Spanish-English only.</i> 
        /// </summary>
        public Conjugations Conjugations { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the quotes.
        /// /// </summary>
        public ICollection<Quote> Quotes { get; set; }
        
        /// <summary>
        /// <i>Optional.</i> Gets or sets the etymology.
        /// </summary>
        public Etymology Etymology { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the artwork.
        /// </summary>
        public Artwork Artwork { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets synonyms.
        /// </summary>
        public ICollection<Synonym> Synonyms { get; set; }

        /// <summary>
        /// <i>Optional.</i> Directional cross-references to other entries may be presented after the main definition section.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// Display in a separate paragraph.
        /// </remarks>
        public ICollection<FormattedText> DirectionalCrossReferences { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets the usages. 
        /// </summary>
        public ICollection<Usage> Usages { get; set; }

        /// <summary>
        /// <i>Optional.</i> Gets or sets a table.
        /// </summary>
        public Table Table { get; set; }

        /// <summary>
        /// <i>Optional, medical dictionary only.</i> Gets or sets biographical notes.
        /// </summary>
        public BiographicalNote BiographicalNote { get; set; }

        /// <summary>
        /// A short definition provides a highly abridged version of the main definition section, consisting of just the definition text for the first three senses.
        /// It is not meant to be displayed along with the full entry, but instead as an alternative, shortened preview of the entry content.
        /// </summary>
        /// <remarks>
        /// <b>Display Guidance:</b>
        /// <para>
        /// Each element in the collection represents a distinct definition, and needs to be separated from the next element by a newline, sense number, or the like.
        /// </para>
        /// <para>
        /// Note this section should not be displayed alongside the main definition section content, but only in specialized contexts where a preview or shortened entry view is needed.
        /// </para>
        /// </remarks>
        public ICollection<string> ShortDefs { get; set; } = new List<string>();

        /// <summary>
        /// Displays the contents of the <see cref="ShortDefs"/> collection, separated by commas. 
        /// </summary>
        [JsonIgnore]
        public string Summary => string.Join(",", ShortDefs);
    }
}