using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class Ldq
    {
        [JsonProperty("ldhw")]
        public string Ldhw { get; set; }

        [JsonProperty("fl")]
        public string Fl { get; set; }

        [JsonProperty("def")]
        public LdqDef[] Def { get; set; }
    }
}