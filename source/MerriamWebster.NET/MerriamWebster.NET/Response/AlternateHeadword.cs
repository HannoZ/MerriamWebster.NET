using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// An alternate headword is a regional or less common spelling of a headword. 
    /// </summary>
    public class AlternateHeadword
    {
        [JsonProperty("hw")]
        public string Headword { get; set; }

        [JsonProperty("hwc", NullValueHandling = NullValueHandling.Ignore)]
        public string HeadwordCutback { get; set; }

        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = { };

        /// <summary>
        /// A parenthesized subject/status label describes the subject area or regional/usage status (eg, "British") of a headword or other defined term, and is displayed in parentheses.<br/>
        /// The parenthesized subject/status label is contained in a <see cref="ParenthesizedSubjectStatusLabel"/>.
        /// </summary>
        [JsonProperty("psl")]
        public string ParenthesizedSubjectStatusLabel { get; set; }

    }
}