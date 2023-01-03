using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A run-in entry word is a defined word that occurs in the running text of an entry.
    /// The run-in ri groups together one or more run-in entry words rie and any accompanying pronunciations or variants.
    /// Run-ins occur most frequently in geographical entries.
    /// </summary>
    public class RunInWrap
    {
        /// <summary>
        /// run-in entry word
        /// </summary>
        [JsonProperty("rie")]
        public string RunInEntry { get; set; }

        /// <summary>
        /// Gets or sets pronunciations (optional).
        /// </summary>
        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = System.Array.Empty<Pronunciation>();

        /// <summary>
        /// Gets or sets variants (optional).
        /// </summary>
        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Vrs { get; set; } = System.Array.Empty<Variant>();

        /// <summary>
        /// intervening text
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }
}