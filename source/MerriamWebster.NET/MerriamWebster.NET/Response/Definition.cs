using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class Definition
    {
        [JsonProperty("sseq")]
        public SenseSequence[][][] SenseSequences { get; set; }

        /// <summary>
        /// The verb divider acts as a functional label in verb entries, introducing the separate sense sequences for transitive and intransitive meanings of the verb.
        /// </summary>
        [JsonProperty("vd", NullValueHandling = NullValueHandling.Ignore)]
        public string VerbDivider { get; set; }
    }
}