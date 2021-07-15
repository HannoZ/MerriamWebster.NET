using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    /// <summary>
    /// A defined run-on consists of a defined run-on phrase, a definition section, and optional other information such as pronunciations, labels, variants, and an etymology.
    /// A set of defined run-ons can follow (or "run on" from) the entry's main definition section.
    /// </summary>
    public class DefinedRunOn
    {
        /// <summary>
        /// A defined run-on phrase is an expression or phrasal verb that is formed from the entry's headword and has its own definition section.
        /// </summary>
        [JsonProperty("drp")]
        public string Phrase { get; set; }
        
        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = { };

        [JsonProperty("def")]
        public Definition[] Definitions { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// A parenthesized subject/status label describes the subject area or regional/usage status (eg, "British") of a headword or other defined term, and is displayed in parentheses.<br/>
        /// The parenthesized subject/status label is contained in a <see cref="ParenthesizedSubjectStatusLabel"/>.
        /// </summary>
        [JsonProperty("psl")]
        public string ParenthesizedSubjectStatusLabel { get; set; }

        /// <summary>
        /// General labels provide information such as whether a headword is typically capitalized, used as an attributive noun, etc.
        /// </summary>
        [JsonProperty("lbs", NullValueHandling = NullValueHandling.Ignore)]
        public string[] GeneralLabels { get; set; } = { };

        /// <summary>
        /// Gets or sets the subject/status labels.
        /// </summary>
        [JsonProperty("sls", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Sls { get; set; }

        /// <summary>
        /// Gets or sets variants.
        /// </summary>
        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Vrs { get; set; } = { };

        /// <summary>
        /// Gets or sets etymologies.
        /// </summary>
        [JsonProperty("et", NullValueHandling = NullValueHandling.Ignore)]
        public Etymology[][] Et { get; set; } = { };
    }
}