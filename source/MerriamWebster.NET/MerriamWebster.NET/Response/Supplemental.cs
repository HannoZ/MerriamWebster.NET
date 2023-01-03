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
        public Conjugation[] Conjugations { get; set; } = System.Array.Empty<Conjugation>();

        /// <summary>
        /// Gets or sets examples.
        /// </summary>
        [JsonProperty("examples")] 
        public Example[] Examples { get; set; } = System.Array.Empty<Example>();

        [JsonProperty("ldq")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public Ldq Ldq { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}