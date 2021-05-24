using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class LdqDef
    {
        [JsonProperty("sls")]
        public string[] Sls { get; set; }

        [JsonProperty("sseq")]
        public SenseSequence[][][] SenseSequences { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}