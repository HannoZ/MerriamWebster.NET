using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class Definition
    {
        [JsonProperty("sseq")]
        public SenseSequenceObject[][][] SenseSequenceObjects { get; set; }

        [JsonProperty("vd", NullValueHandling = NullValueHandling.Ignore)]
        public string VerbDivider { get; set; }
    }
}