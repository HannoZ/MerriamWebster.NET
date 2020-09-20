using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// When a headword or one of its senses represents a less common spelling or inflected form of another word, the definition is omitted and replaced by a cross-reference pointing to the entry containing detailed definition information.
    /// A set of cross-references is contained in an xrs.
    /// </summary>
    public class CrossReference
    {
        /// <summary>
        /// Contains cross-reference text
        /// </summary>
        [JsonProperty("xrt")]
        public string Text { get; set; }

        /// <summary>
        /// Contains ID of cross-reference target
        /// </summary>
        [JsonProperty("xref")]
        public string Target { get; set; }
    }
}