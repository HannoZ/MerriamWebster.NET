using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A <see cref="Sense"/> may be divided into two parts to show a particular relationship between two closely related meanings.
    /// The second part of the sense is contained in a <see cref="DividedSense"/>, consisting of a <see cref="SenseDivider"/> along with a second <see cref="DefiningTexts"/>.
    /// </summary>
    public class DividedSense
    {
        /// <summary>
        /// Gets or sets the sense divider (eg. 'also', 'especially')
        /// </summary>
        [JsonProperty("sd")]
        public string SenseDivider { get; set; }

        /// <summary>
        /// Gets or sets the definition text.
        /// </summary>
        [JsonProperty("dt")]
        public DefiningTextObjectWrapper[][] DefiningTexts { get; set; } = { };

        #region optional
        /// <summary>
        /// Gets or sets etymologies.
        /// </summary>
        [JsonProperty("et", NullValueHandling = NullValueHandling.Ignore)]
        public Etymology[][] Et { get; set; } = { };

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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Variants { get; set; } = { };

        [JsonProperty("ins", NullValueHandling = NullValueHandling.Ignore)]
        public Inflection[] Inflections { get; set; } = { };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// Gets or sets pronunciations (optional).
        /// </summary>
        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = { };

        /// <summary>
        /// This label notes whether a particular sense of a verb is transitive (T) or intransitive (I).<br/>
        /// The sense-specific grammatical label is contained in an <see cref="SenseSpecificGrammaticalLabel"/>.
        /// </summary>
        [JsonProperty("sgram")]
        public string SenseSpecificGrammaticalLabel { get; set; }
        #endregion
    }
}