using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The definition section groups together all the sense sequences and verb dividers for a headword or defined run-on phrase
    /// </summary>
    public class Definition
    {
        /// <summary>
        /// The sense sequence contains a series of senses and subsenses, ordered by sense numbers beginning at Arabic numeral "1".
        /// </summary>
        [JsonProperty("sseq")]
        public SenseSequence[][][] SenseSequences { get; set; }

        /// <summary>
        /// Gets or sets the subject/status labels.
        /// </summary>
        [JsonProperty("sls", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Sls { get; set; } = System.Array.Empty<string>();

        /// <summary>
        /// The verb divider acts as a functional label in verb entries, introducing the separate sense sequences for transitive and intransitive meanings of the verb.
        /// </summary>
        [JsonProperty("vd", NullValueHandling = NullValueHandling.Ignore)]
        public string VerbDivider { get; set; }
    }
}