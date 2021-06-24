using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class CalledAlsoTarget
    {
        [JsonProperty("cat")]
        public string Text { get; set; }
    }
}