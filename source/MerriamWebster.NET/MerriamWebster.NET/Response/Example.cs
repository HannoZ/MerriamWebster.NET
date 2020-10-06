using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class Example
    {
        [JsonProperty("t")]
        public string Text { get; set; }
    }
}