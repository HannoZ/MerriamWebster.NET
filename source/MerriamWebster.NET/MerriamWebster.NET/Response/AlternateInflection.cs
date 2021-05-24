using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class AlternateInflection
    {
        [JsonProperty("ifc")]
        public string Cutback { get; set; }

        [JsonProperty("if")]
        public string Inflection { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}