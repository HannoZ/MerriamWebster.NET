using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// In addition to the verbal illustrations provided throughout the entry, a larger section of quotations from cited sources is sometimes included.
    /// </summary>
    public class Quote
    {
        /// <summary>
        /// Gets or sets quotation text.
        /// </summary>
        [JsonProperty("t")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the attribution of quote.
        /// </summary>
        [JsonProperty("aq")]
        public AtributionOfQuote Aq { get; set; }
    }
}