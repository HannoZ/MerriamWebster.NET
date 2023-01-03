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

        /// <summary>
        /// Text of gender word cutback form.
        /// </summary>
        /// <remarks>Spanish-English dict only</remarks>
        [JsonProperty("gwc", NullValueHandling = NullValueHandling.Ignore)]
        public string GenderWordCutback { get; set; }

        /// <summary>
        /// Text of gender word spelled-out form
        /// </summary>
        /// <remarks>Spanish-English dict only</remarks>
        [JsonProperty("gwd", NullValueHandling = NullValueHandling.Ignore)]
        public string GenderWordSpelledOut { get; set; }

        /// <summary>
        /// Contains introductory text "called also"
        /// </summary>
        [JsonProperty("intro", NullValueHandling = NullValueHandling.Ignore)]
        public string Intro { get; set; }

        /// <summary>
        /// One or more called-also targets
        /// </summary>
        /// [JsonProperty("cats", NullValueHandling = NullValueHandling.Ignore)]
        public CalledAlsoTarget[] Cats { get; set; }

        /// <summary>
        /// Gets or sets the personal or first name.
        /// </summary>
        [JsonProperty("pname", NullValueHandling = NullValueHandling.Ignore)]
        public string Pname { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        [JsonProperty("sname", NullValueHandling = NullValueHandling.Ignore)]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Pronunciation"/>s.
        /// </summary>
        [JsonProperty("prs")]
        public Pronunciation[] Pronunciations { get; set; } = System.Array.Empty<Pronunciation>();

        /// <summary>
        /// Gets or sets an alternate name such as pen name, nickname, title, etc.
        /// </summary>
        [JsonProperty("altname", NullValueHandling = NullValueHandling.Ignore)]
        public string Altname { get; set; }
    }
}