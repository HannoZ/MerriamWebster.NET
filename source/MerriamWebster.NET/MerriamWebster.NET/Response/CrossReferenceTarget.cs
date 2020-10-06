using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class CrossReferenceTarget
    {
        /// <summary>
        /// Cognate cross-reference label.
        /// </summary>
        [JsonProperty("cxl")]
        public string Label { get; set; }

        /// <summary>
        ///  When present, use as cross-reference target ID for immediately preceding <see cref="Target"/>.
        /// </summary>
        [JsonProperty("cxr")]
        public string TargetId { get; set; }

        /// <summary>
        /// Provides hyperlink text in all cases, and cross-reference target ID when no immediately following <see cref="TargetId"/>.
        /// </summary>
        [JsonProperty("cxt")]
        public string Target { get; set; }

        /// <summary>
        /// Sense number of cross-reference target.
        /// </summary>
        [JsonProperty("cxn")]
        public string SenseNumber { get; set; }

    }
}