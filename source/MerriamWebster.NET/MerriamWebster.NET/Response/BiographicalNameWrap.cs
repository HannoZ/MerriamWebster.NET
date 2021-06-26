using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A biographical name wrap groups together personal name, surname, and alternate name information within a biographical entry
    /// </summary>
    public class BiographicalNameWrap
    {
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
        public Pronunciation[] Pronunciations { get; set; } = { };

        /// <summary>
        /// Gets or sets an alternate name such as pen name, nickname, title, etc.
        /// </summary>
        [JsonProperty("altname", NullValueHandling = NullValueHandling.Ignore)]
        public string Altname { get; set; }
    }
}