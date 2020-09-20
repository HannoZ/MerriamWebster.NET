using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class SenseSequence
    {
        [JsonProperty("sn", NullValueHandling = NullValueHandling.Ignore)]
        public string SenseNumber { get; set; }
        [JsonProperty("dt")]
        public TranslationObject[][] Definitions { get; set; }
        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Variants { get; set; }
        [JsonProperty("xrs", NullValueHandling = NullValueHandling.Ignore)]
        public CrossReference[][] CrossReferences { get; set; }
        [JsonProperty("sls", NullValueHandling = NullValueHandling.Ignore)]
        public string[] StatusLabels { get; set; }
        [JsonProperty("ins", NullValueHandling = NullValueHandling.Ignore)]
        public Inflection[] Inflections { get; set; }
    }
}