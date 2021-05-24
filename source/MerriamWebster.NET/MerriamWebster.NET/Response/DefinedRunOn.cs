using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class DefinedRunOn
    {
        [JsonProperty("drp")]
        public string Phrase { get; set; }

        [JsonProperty("fl")]
        public string FunctionalLabel { get; set; }

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


    }
}