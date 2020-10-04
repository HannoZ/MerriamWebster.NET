using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class DefinedRunOn
    {
        [JsonProperty("drp")]
        public string Phrase { get; set; }

        [JsonProperty("fl")]
        public string FunctionalLabel { get; set; }

        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = { };

        [JsonProperty("def")]
        public Definition[] Definitions { get; set; }
    }
}