using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A very abbreviated version of the entry that could be used in specialized contexts where a preview or shortened entry view is needed.
    /// </summary>
    public class AppShortdef
    {
        [JsonProperty("hw")]
        public string Headword { get; set; }

        [JsonProperty("fl")]
        public string FunctionalLabel { get; set; }

        [JsonProperty("def")] 
        public string[] Definitions { get; set; } = { };
    }
}