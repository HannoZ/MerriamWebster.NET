using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Extensive discussions of synonyms for the headword may be included in the entry.
    /// A set of such synonym discussions makes up a synonym section, which is contained in this class
    /// </summary>
    public class Synonym
    {
        /// <summary>
        /// paragraph label: heading to display at top of section
        /// </summary>
        [JsonProperty("pl")]
        public string Pl { get; set; }
        /// <summary>
        /// paragraph text 
        /// </summary>
        [JsonProperty("pt")]
        public DefiningTextComplexTypeWrapper[][] Pt { get; set; }
        /// <summary>
        /// see in addition reference: contains one or more elements, each of which is the text and ID of a "see in addition" reference to another synonym section.
        /// </summary>
        [JsonProperty("sarefs", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Sarefs { get; set; }
    }
}