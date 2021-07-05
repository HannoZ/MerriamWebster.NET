using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// In addition to usage notes ("uns") within definitions, a more extensive usage discussion may be included in the entry. A set of usage discussions makes up a usage section
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// paragraph label: heading to display at top of section
        /// </summary>
        [JsonProperty("pl")]
        public string ParagraphLabel { get; set; }

        /// <summary>
        /// paragraph text.
        /// </summary>
        [JsonProperty("pt")]
        public DefiningTextComplexTypeWrapper[][] ParagraphText { get; set; }
    }
}