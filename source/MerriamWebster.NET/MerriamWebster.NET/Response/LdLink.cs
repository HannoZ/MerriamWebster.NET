using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class LdLink
    {
        [JsonProperty("link_hw")]
        public string LinkHw { get; set; }

        [JsonProperty("link_fl")]
        public string LinkFl { get; set; }
    }
}