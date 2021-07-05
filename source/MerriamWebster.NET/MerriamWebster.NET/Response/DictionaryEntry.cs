using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    /// <summary>
    /// The organizational unit of a dictionary. An entry consists of at minimum a headword, along with content defining or translating the headword.
    /// </summary>
    public class DictionaryEntry
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
        /// Describes the grammatical function of a headword or undefined entry word. It indicates the role the word plays in a sentence, such as "noun", "verb", "adjective", etc.<br/>
        /// It may also categorize the word in other ways, such as "trademark" or "abbreviation". Also called: part of speech.
        /// </summary>
        [JsonProperty("fl")]
        public string FunctionalLabel { get; set; }

        [JsonProperty("cxs", NullValueHandling = NullValueHandling.Ignore)]
        public CognateCrossReference[] CognateCrossReferences { get; set; } = { };

        /// <summary>
        /// The definition section groups together all sense sequences and verb dividers for a headword or defined run-on phrase.
        /// </summary>
        [JsonProperty("def")]
        public Definition[] Definitions { get; set; } = { };
        
        [JsonProperty("uros")]
        public UndefinedRunOn[] UndefinedRunOns { get; set; } = { };

        [JsonProperty("dros", NullValueHandling = NullValueHandling.Ignore)]
        public DefinedRunOn[] DefinedRunOns { get; set; } = { };

        [JsonProperty("ins", NullValueHandling = NullValueHandling.Ignore)]
        public Inflection[] Inflections { get; set; } = { };

        [JsonProperty("xrs", NullValueHandling = NullValueHandling.Ignore)]
        public CrossReference[][] CrossReferences { get; set; } = { };

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("suppl", NullValueHandling = NullValueHandling.Ignore)]
        public Supplemental Supplemental { get; set; }

        [JsonProperty("history")]
        public History History { get; set; }

        [JsonProperty("shortdef")]
        public string[] Shortdefs { get; set; } = { };

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// An etymology is an explanation of the historical origin of a word. An etymology might supply, for instance, the French origin of a headword, then further give the Latin origin of that French word. Also called: word origin.<br/>
        /// While the etymology contained in an et most typically relates to the headword, it may also explain the origin of a defined run-on phrase or a particular sense.
        /// </summary>
        [JsonProperty("et", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] Etymologies { get; set; }


        /// <summary>
        /// Array of one or more variant objects.
        /// </summary>
        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Variants { get; set; } = { };

        /// <summary>
        /// Array of one or more alternate headword objects.
        /// </summary>
        [JsonProperty("ahws", NullValueHandling = NullValueHandling.Ignore)]
        public AlternateHeadword[] AlternateHeadwords { get; set; } = { };

        /// <summary>
        /// A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        [JsonProperty("sls", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SubjectStatusLabels { get; set; } = { };

        /// <summary>
        /// General labels provide information such as whether a headword is typically capitalized, used as an attributive noun, etc.
        /// </summary>
        [JsonProperty("lbs", NullValueHandling = NullValueHandling.Ignore)]
        public string[] GeneralLabels { get; set; } = { };
        
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
        public Quote[] Quotes { get; set; } = { };
    }
}
