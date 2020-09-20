using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class TranslationClass
    {
        [JsonProperty("t")]
        public string Text { get; set; }

        [JsonProperty("tr")]
        public string Translation { get; set; }
    }
}