using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A supplemental verb conjugation section is included in some bilingual dictionary entries. A set of verb conjugations is contained in a <see cref="Conjugations"/>.
    /// </summary>
    public class Supplemental
    {
        /// <summary>
        /// Array  of one or more <see cref="Conjugation"/> objects.
        /// </summary>
        [JsonProperty("cjts")]
        public Conjugation[] Conjugations { get; set; }
    }
}