using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The <see cref="DefiningText"/> is the text of the definition or translation for a particular <see cref="Sense"/>.
    /// </summary>
    public class DefiningText
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        [JsonProperty("t")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the translation.
        /// </summary>
        [JsonProperty("tr")]
        public string Translation { get; set; }

        /// <summary>
        /// Gets or sets the quote.
        /// </summary>
        [JsonProperty("aq")]
        public AtributionOfQuote Quote { get; set; }
    }
}