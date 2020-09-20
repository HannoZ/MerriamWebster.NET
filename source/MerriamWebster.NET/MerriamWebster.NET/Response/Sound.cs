using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class Sound
    {
        [JsonProperty("audio")]
        public string Audio { get; set; }
    }
}