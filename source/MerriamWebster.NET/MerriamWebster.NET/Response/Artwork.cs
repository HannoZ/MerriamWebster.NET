using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Entries may have illustrations to provide a visual depiction of the headword.
    /// </summary>
    public class Artwork
    {
        /// <summary>
        /// filename of target image
        /// </summary>
        [JsonProperty("artid")]
        public string Id { get; set; }
        /// <summary>
        /// image caption text
        /// </summary>
        [JsonProperty("capt")]
        public string Caption { get; set; }
    }
}