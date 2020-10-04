using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class Inflection
    {
        [JsonProperty("il")]
        public string Label { get; set; }

        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = { };

        [JsonProperty("ifc")]
        public string Cutback { get; set; }

        [JsonProperty("if")]
        public string Value { get; set; }

        [JsonProperty("aif")]
        public AlternateInflection Alternate { get; set; }

        [JsonProperty("spl")]
        public string Spl { get; set; }
    }
}
