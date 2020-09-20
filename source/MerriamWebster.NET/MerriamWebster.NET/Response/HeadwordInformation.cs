using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The headword is the word being defined or translated in a dictionary entry. Key headword information is grouped in an hwi object. This includes the headword itself in the <see cref="Headword"/> member, and may include one or more pronunciations in <see cref="Pronunciations"/>.
    /// </summary>
    public class HeadwordInformation
    {
        [JsonProperty("hw")]
        public string Headword { get; set; }

        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; }
    }
}