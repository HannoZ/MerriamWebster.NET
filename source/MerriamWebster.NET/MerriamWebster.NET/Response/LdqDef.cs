using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class LdqDef
    {
        [JsonProperty("sls")]
        public string[] Sls { get; set; }

        [JsonProperty("sseq")]
        public SenseSequence[][][] Sseq { get; set; }
    }
}