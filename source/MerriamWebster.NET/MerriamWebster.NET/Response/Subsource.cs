using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Further detail on quote source (eg, name of larger work in which an essay is found)
    /// </summary>
    public class Subsource
    {
        /// <summary>
        /// Source work for quote.
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }
       
        /// <summary>
        /// Publication date of quote.
        /// </summary>
        [JsonProperty("aqdate")]
        public string PublicationDate { get; set; }
    }
}