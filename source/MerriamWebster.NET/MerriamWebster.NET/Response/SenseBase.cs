using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Class that contains properties that are shared between <see cref="Sense"/> and <see cref="DividedSense"/>.
    /// </summary>
    public abstract class SenseBase
    {
        /// <summary>
        /// Gets or sets the definition text.
        /// </summary>
        [JsonProperty("dt")]
        public DefiningTextObjectWrapper[][] DefiningTexts { get; set; } = System.Array.Empty<DefiningTextObjectWrapper[]>();

        /// <summary>
        /// An etymology is an explanation of the historical origin of a word.
        /// While the etymology contained in an et most typically relates to the headword, it may also explain the origin of a defined run-on phrase or a particular sense.
        /// </summary>
        [JsonProperty("et", NullValueHandling = NullValueHandling.Ignore)]
        public Etymology[][] Etymologies { get; set; } = System.Array.Empty<Etymology[]>();

        /// <summary>
        /// This label notes whether a particular sense of a verb is transitive (T) or intransitive (I).<br/>
        /// The sense-specific grammatical label is contained in an <see cref="SenseSpecificGrammaticalLabel"/>.
        /// </summary>
        [JsonProperty("sgram")]
        public string SenseSpecificGrammaticalLabel { get; set; }
        
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
        /// Gets or sets pronunciations (optional).
        /// </summary>
        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = System.Array.Empty<Pronunciation>();

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Variants { get; set; } = System.Array.Empty<Variant>();

        [JsonProperty("ins", NullValueHandling = NullValueHandling.Ignore)]
        public Inflection[] Inflections { get; set; } = System.Array.Empty<Inflection>();

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    }
}