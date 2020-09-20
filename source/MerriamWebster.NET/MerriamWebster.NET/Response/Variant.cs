using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A variant is a different spelling or styling of a headword, defined run-on phrase, or undefined entry word. A set of one or more variants is contained in a vrs.
    /// </summary>
    public class Variant
    {
        /// <summary>
        /// Variant label, such as “or” (optional).
        /// </summary>
        [JsonProperty("vl")]
        public string VariantLabel { get; set; }

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
    }
}