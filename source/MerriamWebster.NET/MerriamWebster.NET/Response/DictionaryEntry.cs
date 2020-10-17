using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class DictionaryEntry
    {
        [JsonProperty("meta")]
        public Metadata Metadata { get; set; }

        [JsonProperty("hom", NullValueHandling = NullValueHandling.Ignore)]
        public int? Homograph { get; set; }

        [JsonProperty("hwi")]
        public HeadwordInformation HeadwordInformation { get; set; }

        [JsonProperty("fl")]
        public string FunctionalLabel { get; set; }

        [JsonProperty("cxs", NullValueHandling = NullValueHandling.Ignore)]
        public CognateCrossReference[] CognateCrossReferences { get; set; } = { };

        [JsonProperty("def")]
        public Definition[] Definitions { get; set; } = { };

        /// <summary>
        /// An etymology is an explanation of the historical origin of a word.
        /// While the etymology contained in an et most typically relates to the headword, it may also explain the origin of a defined run-on phrase or a particular sense.
        /// </summary>
        [JsonProperty("et", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] Etymologies { get; set; }

        [JsonProperty("uros")]
        public UndefinedRunOn[] UndefinedRunOns { get; set; } = { };

        [JsonProperty("dros", NullValueHandling = NullValueHandling.Ignore)]
        public DefinedRunOn[] DefinedRunOns { get; set; } = { };
        
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

        [JsonProperty("ins", NullValueHandling = NullValueHandling.Ignore)]
        public Inflection[] Inflections { get; set; } = { };

        [JsonProperty("xrs", NullValueHandling = NullValueHandling.Ignore)]
        public CrossReference[][] CrossReferences { get; set; } = { };

        [JsonProperty("date")]
        public string Date { get; set; }

        /// <summary>
        /// Undocumented field.
        /// </summary>
        [JsonProperty("ld_link")]
        public LdLink LdLink { get; set; }

        [JsonProperty("suppl", NullValueHandling = NullValueHandling.Ignore)]
        public Supplemental Supplemental { get; set; }

        [JsonProperty("history")]
        public History History { get; set; }

        [JsonProperty("shortdef")]
        public string[] Shortdefs { get; set; } = { };
    }

    /// <summary>
    /// A word history paragraph provides historical background for a headword. 
    /// </summary>
    public class History
    {
        /// <summary>
        /// Heading to display at top of section.
        /// </summary>
        [JsonProperty("pl")]
        public string ParagraphLabel { get; set; }
        
        [JsonProperty("pt")]
        public string[][] ParagraphText { get; set; }
    }
}
