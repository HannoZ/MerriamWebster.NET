using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Example
    {
        [JsonProperty("t")]
        public string Text { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}