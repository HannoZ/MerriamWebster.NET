using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    /// <summary>
    /// The organizational unit of a dictionary. An entry consists of at minimum a headword, along with content defining or translating the headword.
    /// </summary>
    /// <remarks>
    /// Renamed to from DictionaryEntry to MwDictionaryEntry to avoid potential confusion with System.Collections.DictionaryEntry
    /// </remarks>
    public class MwDictionaryEntry
    {
        [JsonProperty("meta")]
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Homographs are headwords with identical spellings but distinct meanings and origins. For example, the noun "wind" (natural movement of air), verb "wind" (make short of breath), and verb "wind" (tighten the spring of a clock) are all homographs, each with its own dictionary entry.
        /// </summary>
        [JsonProperty("hom", NullValueHandling = NullValueHandling.Ignore)]
        public int? Homograph { get; set; }

        /// <summary>
        /// The word being defined or translated in an entry. It serves as the main organizing principle of the dictionary: the headword is presented prominently at the start of its entry, and the rest of the entry content describes its meanings, usage, etymology, etc.
        /// </summary>
        [JsonProperty("hwi")]
        public HeadwordInformation HeadwordInformation { get; set; }

        /// <summary>
        /// The functional label describes the grammatical function of a headword or undefined entry word, such as "noun" or "adjective".
        /// </summary>
        [JsonProperty("fl")]
        public string FunctionalLabel { get; set; }

        [JsonProperty("cxs", NullValueHandling = NullValueHandling.Ignore)]
        public CognateCrossReference[] CognateCrossReferences { get; set; } = System.Array.Empty<CognateCrossReference>();

        /// <summary>
        /// The definition section groups together all sense sequences and verb dividers for a headword or defined run-on phrase.
        /// </summary>
        [JsonProperty("def")]
        public Definition[] Definitions { get; set; } = System.Array.Empty<Definition>();

        [JsonProperty("uros")]
        public UndefinedRunOn[] UndefinedRunOns { get; set; } = System.Array.Empty<UndefinedRunOn>();

        /// <summary>
        /// Gets or sets the biographical notes.
        /// </summary>
        /// <remarks>Medical only</remarks>
        [JsonProperty("bios", NullValueHandling = NullValueHandling.Ignore)]
        public BioElement[][][] Bios { get; set; } = System.Array.Empty<BioElement[][]>();

        [JsonProperty("dros", NullValueHandling = NullValueHandling.Ignore)]
        public DefinedRunOn[] DefinedRunOns { get; set; } = System.Array.Empty<DefinedRunOn>();

        [JsonProperty("ins", NullValueHandling = NullValueHandling.Ignore)]
        public Inflection[] Inflections { get; set; } = System.Array.Empty<Inflection>();

        [JsonProperty("xrs", NullValueHandling = NullValueHandling.Ignore)]
        public CrossReference[][] CrossReferences { get; set; } = System.Array.Empty<CrossReference[]>();

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("suppl", NullValueHandling = NullValueHandling.Ignore)]
        public Supplemental Supplemental { get; set; }

        [JsonProperty("history")]
        public History History { get; set; }

        [JsonProperty("shortdef")]
        public string[] Shortdefs { get; set; } = System.Array.Empty<string>();

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// An etymology is an explanation of the historical origin of a word. An etymology might supply, for instance, the French origin of a headword, then further give the Latin origin of that French word. Also called: word origin.<br/>
        /// While the etymology contained in an et most typically relates to the headword, it may also explain the origin of a defined run-on phrase or a particular sense.
        /// </summary>
        [JsonProperty("et", NullValueHandling = NullValueHandling.Ignore)]
        public Etymology[][] Et { get; set; } = System.Array.Empty<Etymology[]>();


        /// <summary>
        /// Array of one or more variant objects.
        /// </summary>
        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Variants { get; set; } = System.Array.Empty<Variant>();

        /// <summary>
        /// Array of one or more alternate headword objects.
        /// </summary>
        [JsonProperty("ahws", NullValueHandling = NullValueHandling.Ignore)]
        public AlternateHeadword[] AlternateHeadwords { get; set; } = System.Array.Empty<AlternateHeadword>();

        /// <summary>
        /// A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        [JsonProperty("sls", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SubjectStatusLabels { get; set; } = System.Array.Empty<string>();

        /// <summary>
        /// General labels provide information such as whether a headword is typically capitalized, used as an attributive noun, etc.
        /// </summary>
        [JsonProperty("lbs", NullValueHandling = NullValueHandling.Ignore)]
        public string[] GeneralLabels { get; set; } = System.Array.Empty<string>();

        /// <summary>
        /// Undocumented field.
        /// </summary>
        [JsonProperty("ld_link")]
        public LdLink LdLink { get; set; }

        /// <summary>
        /// Gets or sets the artwork.
        /// </summary>
        [JsonProperty("art")]
        public Artwork Artwork { get; set; }

        /// <summary>
        /// Gets or sets the quotes.
        /// </summary>
        [JsonProperty("quotes")]
        public Quote[] Quotes { get; set; } = System.Array.Empty<Quote>();

        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        [JsonProperty("table", NullValueHandling = NullValueHandling.Ignore)]
        public Table Table { get; set; }

        /// <summary>
        /// Gets or sets synonyms.
        /// </summary>
        [JsonProperty("syns", NullValueHandling = NullValueHandling.Ignore)]
        public Synonym[] Synonyms { get; set; } = System.Array.Empty<Synonym>();

        /// <summary>
        /// Gets or sets the usages.
        /// </summary>
        [JsonProperty("usages", NullValueHandling = NullValueHandling.Ignore)]
        public Usage[] Usages { get; set; } = System.Array.Empty<Usage>();
        /// <summary>
        /// Gets or sets Directional cross-references
        /// </summary>
        [JsonProperty("dxnls", NullValueHandling = NullValueHandling.Ignore)]
        public string[] DirectionalCrossReferences { get; set; } = System.Array.Empty<string>();
    }
}
