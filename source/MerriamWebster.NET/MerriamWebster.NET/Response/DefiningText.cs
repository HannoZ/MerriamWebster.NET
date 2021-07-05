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

    /// <summary>
    /// A run-in entry word is a defined word that occurs in the running text of an entry.
    /// The run-in ri groups together one or more run-in entry words rie and any accompanying pronunciations or variants.
    /// Run-ins occur most frequently in geographical entries.
    /// </summary>
    public class RunInWrap
    {
        /// <summary>
        /// Run-in entry word
        /// </summary>
        [JsonProperty("rie")]
        public string Rie { get; set; }
    }
}