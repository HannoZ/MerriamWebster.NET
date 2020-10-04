using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class DictionaryEntry
    {
        [JsonProperty("meta")]
        public Metadata Metadata { get; set; }

        [JsonProperty("hwi")]
        public HeadwordInformation HeadwordInformation { get; set; }

        [JsonProperty("fl")]
        public string FunctionalLabel { get; set; }

        [JsonProperty("def")]
        public Definition[] Definitions { get; set; } = { };

        [JsonProperty("uros")]
        public UndefinedRunOn[] UndefinedRunOns { get; set; } = { };

        [JsonProperty("dros", NullValueHandling = NullValueHandling.Ignore)]
        public DefinedRunOn[] DefinedRunOns { get; set; } = { };

        [JsonProperty("suppl", NullValueHandling = NullValueHandling.Ignore)]
        public Supplemental Supplemental { get; set; }

        [JsonProperty("shortdef")] 
        public string[] Shortdef { get; set; } = { };

        /// <summary>
        /// Array of one or more variant objects.
        /// </summary>
        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Vrs { get; set; } = { };

        /// <summary>
        /// Array of one or more alternate headword objects.
        /// </summary>
        [JsonProperty("ahws", NullValueHandling = NullValueHandling.Ignore)]
        public AlternateHeadword[] AlternateHeadwords { get; set; }

        /// <summary>
        /// A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        [JsonProperty("sls", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SubjectStatusLabels { get; set; } = { };

        [JsonProperty("hom", NullValueHandling = NullValueHandling.Ignore)]
        public int? Homograph { get; set; }

        [JsonProperty("ins", NullValueHandling = NullValueHandling.Ignore)]
        public Inflection[] Inflections { get; set; } = { };

        [JsonProperty("xrs", NullValueHandling = NullValueHandling.Ignore)]
        public CrossReference[][] CrossReferences { get; set; } = { };
    }
}
