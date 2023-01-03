
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A biographical note provides information on a historical or mythological figure relevant to the headword
    /// </summary>
    public class BiographicalNote
    {
        /// <summary>
        /// biographical surname
        /// </summary>
        [JsonProperty("biosname", NullValueHandling = NullValueHandling.Ignore)]
        public string Biosname { get; set; }
        /// <summary>
        /// other biographical name (used for mythological figures, eg, "Atropa")
        /// </summary>
        [JsonProperty("bioname", NullValueHandling = NullValueHandling.Ignore)]
        public string Bioname { get; set; }

        /// <summary>
        /// Gets or sets the pronunciations
        /// </summary>
        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Prs { get; set; } = System.Array.Empty<Pronunciation>();
        /// <summary>
        /// biographical personal or first name
        /// </summary>
        [JsonProperty("biopname", NullValueHandling = NullValueHandling.Ignore)]
        public string Biopname { get; set; }
        ///// <summary>
        ///// contains birth and death years
        ///// </summary>
        //[JsonProperty("biodate", NullValueHandling = NullValueHandling.Ignore)]
        //public string Biodate { get; set; }
        ///// <summary>
        ///// contains text of biographical note
        ///// </summary>
        //[JsonProperty("biotx", NullValueHandling = NullValueHandling.Ignore)]
        //public string Biotx { get; set; }
    }
}