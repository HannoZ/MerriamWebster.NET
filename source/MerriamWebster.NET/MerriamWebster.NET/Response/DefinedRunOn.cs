using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class DefinedRunOn
    {
        [JsonProperty("drp")]
        public string Drp { get; set; }

        [JsonProperty("fl")]
        public string Fl { get; set; }

        [JsonProperty("def")]
        public Definition[] Def { get; set; }
    }
}