using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Ldq
    {
        [JsonProperty("ldhw")]
        public string Headword { get; set; }

        [JsonProperty("fl")]
        public string FunctionalLabel { get; set; }

        [JsonProperty("def")]
        public LdqDef[] Definition { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}