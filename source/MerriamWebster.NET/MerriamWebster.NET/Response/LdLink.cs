using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Todo - unknown link type
    /// </summary>
    public class LdLink
    {
        /// <summary>
        /// Link headword
        /// </summary>
        [JsonProperty("link_hw")]
        public string LinkHw { get; set; }

        /// <summary>
        /// Link functional label
        /// </summary>
        [JsonProperty("link_fl")]
        public string LinkFl { get; set; }
    }
}