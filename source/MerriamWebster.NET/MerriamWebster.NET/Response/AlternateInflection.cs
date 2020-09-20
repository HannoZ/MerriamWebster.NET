using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class AlternateInflection
    {
        [JsonProperty("ifc")]
        public string Cutback { get; set; }

        [JsonProperty("if")]
        public string Inflection { get; set; }
    }
}