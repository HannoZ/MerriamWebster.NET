using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The headword is the word being defined or translated in a dictionary entry. Key headword information is grouped in an hwi object. This includes the headword itself in the <see cref="Headword"/> member, and may include one or more pronunciations in <see cref="Pronunciations"/>.
    /// </summary>
    public class HeadwordInformation
    {
        /// <summary>
        /// Gets or sets the headword.
        /// </summary>
        [JsonProperty("hw")]
        public string Headword { get; set; }

        /// <summary>
        /// Gets or sets the pronunciations.
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