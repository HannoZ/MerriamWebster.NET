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
    }
}