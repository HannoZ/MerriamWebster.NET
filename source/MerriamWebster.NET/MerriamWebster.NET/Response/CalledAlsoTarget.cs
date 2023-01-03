using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The called-also target.
    /// </summary>
    public class CalledAlsoTarget
    {
        /// <summary>
        /// Called-also target text
        /// </summary>
        [JsonProperty("cat")]
        public string Text { get; set; }
        /// <summary>
        /// Called-also reference containing target ID
        /// </summary>
        [JsonProperty("catref")]
        public string Reference { get; set; }
        /// <summary>
        /// Gets or sets parenthesized number
        /// </summary>
        [JsonProperty("pn")]
        public string ParenthesizedNumber { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Pronunciation"/>s.
        /// </summary>
        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = System.Array.Empty<Pronunciation>();

        /// <summary>
        /// A parenthesized subject/status label describes the subject area or regional/usage status (eg, "British") of a headword or other defined term, and is displayed in parentheses.<br/>
        /// The parenthesized subject/status label is contained in a <see cref="ParenthesizedSubjectStatusLabel"/>.
        /// </summary>
        [JsonProperty("psl")]
        public string ParenthesizedSubjectStatusLabel { get; set; }
    }
}