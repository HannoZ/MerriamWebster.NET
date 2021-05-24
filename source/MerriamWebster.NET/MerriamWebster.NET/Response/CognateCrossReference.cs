using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// When a headword is a less common spelling of another word with the same meaning, there will be a cognate cross-reference pointing to the headword with the more common spelling.
    /// </summary>
    public class CognateCrossReference
    {
        /// <summary>
        /// Cognate cross-reference label.
        /// </summary>
        [JsonProperty("cxl")]
        public string Label { get; set; }
        /// <summary>
        /// Gets or sets the cross-reference target.
        /// </summary>
        [JsonProperty("cxtis")] 
        public CrossReferenceTarget[] CrossReferenceTargets { get; set; } = { };
    }
}