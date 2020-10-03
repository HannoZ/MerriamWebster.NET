using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class Metadata
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("lang")]
        public Lang Lang { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("stems")] public string[] Stems { get; set; } = { };

        [JsonProperty("offensive")]
        public bool Offensive { get; set; }
    }
}