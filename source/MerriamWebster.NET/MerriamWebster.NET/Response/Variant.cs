using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A variant is a different spelling or styling of a headword, defined run-on phrase, or undefined entry word.
    /// </summary>
    public class Variant
    {
        /// <summary>
        /// Variant label, such as “or” (optional).
        /// </summary>
        [JsonProperty("vl")]
        public string VariantLabel { get; set; }

        /// <summary>
        /// Gets or sets the variant text.
        /// </summary>
        [JsonProperty("va")]
        public string Text { get; set; }
        
        /// <summary>
        /// Contains a cutback form of the preceding variant
        /// </summary>
        /// <remarks>
        /// A variant is often a sense-specific idiom or phrase containing the headword. In space-constrained environments, such variants may be presented in a shortened cutback form that omits the headword itself. A variant cutback is contained in a <see cref="Cutback"/>.
        /// </remarks>
        [JsonProperty("vac", NullValueHandling = NullValueHandling.Ignore)]
        public string Cutback { get; set; }
        
        /// <summary>
        /// Gets or sets pronunciations (optional).
        /// </summary>
        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = { };

        /// <summary>
        /// This label provides information on the grammatical number (eg, singular, plural) of an inflection in a particular sense.
        /// </summary>
        [JsonProperty("spl")]
        public string SenseSpecificInflectionPluralLabel { get; set; }
    }
}