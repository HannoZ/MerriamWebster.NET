using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class SenseSequence
    {
        [JsonProperty("sn", NullValueHandling = NullValueHandling.Ignore)]
        public string SenseNumber { get; set; }

        [JsonProperty("dt")] public DefiningTextObject[][] DefiningTexts { get; set; } = { };

        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Variants { get; set; } = { };

        [JsonProperty("xrs", NullValueHandling = NullValueHandling.Ignore)]
        public CrossReference[][] CrossReferences { get; set; } = { };
        /// <summary>
        /// A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        [JsonProperty("sls", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SubjectStatusLabels { get; set; } = { };

        [JsonProperty("ins", NullValueHandling = NullValueHandling.Ignore)]
        public Inflection[] Inflections { get; set; } = { };
    }
}