using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A supplemental verb conjugation section is included in some bilingual dictionary entries. A set of verb conjugations is contained in a cjts.
    /// </summary>
    public class Conjugation
    {
        /// <summary>
        /// An ID identifying the verb tense of the following conjugation fields.
        /// </summary>
        [JsonProperty("cjid")]
        public string Id { get; set; }

        /// <summary>
        /// Array  of one or more conjugation fields, each representing a particular verb form in the tense indicated by <see cref="Id"/>.
        /// </summary>
        [JsonProperty("cjfs")]
        public string[] Fields { get; set; }
    }
}