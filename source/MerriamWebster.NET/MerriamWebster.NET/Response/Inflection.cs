using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Inflection is the change of form that words undergo in different grammatical contexts, such as tense or number.
    /// </summary>
    public class Inflection
    {
        [JsonProperty("il")]
        public string Label { get; set; }

        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = { };

        [JsonProperty("ifc")]
        public string Cutback { get; set; }

        [JsonProperty("if")]
        public string Value { get; set; }

        [JsonProperty("aif", NullValueHandling = NullValueHandling.Ignore)]
        public AlternateInflection Alternate { get; set; }

        /// <summary>
        /// This label provides information on the grammatical number (eg, singular, plural) of an inflection in a particular sense.<br/>
        /// A sense-specific inflection plural label is contained in an <see cref="SenseSpecificInflectionPluralLabel"/>.
        /// </summary>
        [JsonProperty("spl")]
        public string SenseSpecificInflectionPluralLabel { get; set; }
    }
}
