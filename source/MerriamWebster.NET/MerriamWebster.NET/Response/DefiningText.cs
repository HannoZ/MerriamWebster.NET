using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class DefiningText
    {
        [JsonProperty("t")]
        public string Text { get; set; }

        [JsonProperty("tr")]
        public string Translation { get; set; }
    }
}