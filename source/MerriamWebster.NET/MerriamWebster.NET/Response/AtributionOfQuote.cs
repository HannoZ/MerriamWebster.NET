using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Direct quotes are used in both verbal illustrations and end-of-entry quotation sections.
    /// Information about the attribution (the author, publication, date, etc.) of a particular quote is contained in this class.
    /// </summary>
    public class AtributionOfQuote
    {
        /// <summary>
        /// Name of author.
        /// </summary>
        [JsonProperty("auth")]
        public string Author { get; set; }
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
        /// <summary>
        /// Gets or sets the <see cref="Subsource"/>.
        /// </summary>
        [JsonProperty("subsource")]
        public Subsource Subsource { get; set; }
    }
}