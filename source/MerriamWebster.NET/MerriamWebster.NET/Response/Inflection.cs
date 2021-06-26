using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Inflection is the change of form that words undergo in different grammatical contexts, such as tense or number.
    /// </summary>
    public class Inflection
    {
        /// <summary>
        /// Gets or sets the inflection label
        /// </summary>
        [JsonProperty("il")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the pronunciations.
        /// </summary>
        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = { };

        /// <summary>
        /// Gets or sets the inflection cutback.
        /// </summary>
        [JsonProperty("ifc")]
        public string Cutback { get; set; }

        /// <summary>
        /// Gets or sets the inflection value.
        /// </summary>
        [JsonProperty("if")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="AlternateInflection"/>.
        /// </summary>
        [JsonProperty("aif", NullValueHandling = NullValueHandling.Ignore)]
        public AlternateInflection Alternate { get; set; }

        /// <summary>
        /// This label provides information on the grammatical number (eg, singular, plural) of an inflection in a particular sense.
        /// </summary>
        [JsonProperty("spl")]
        public string SenseSpecificInflectionPluralLabel { get; set; }
    }
}
