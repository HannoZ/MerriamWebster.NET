using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A <see cref="Sense"/> may be divided into two parts to show a particular relationship between two closely related meanings.
    /// The second part of the sense is contained in a <see cref="DividedSense"/>, consisting of a <see cref="SenseDivider"/> along with a second <see cref="DefiningTexts"/>.
    /// </summary>
    public class DividedSense
    {
        [JsonProperty("sd")]
        public string SenseDivider { get; set; }

        [JsonProperty("dt")]
        public DefiningTextObjectWrapper[][] DefiningTexts { get; set; } = { };
       
        /// <summary>
        /// An etymology is an explanation of the historical origin of a word.
        /// While the etymology contained in an et most typically relates to the headword, it may also explain the origin of a defined run-on phrase or a particular sense.
        /// </summary>
        [JsonProperty("et", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] Etymologies { get; set; }

        [JsonProperty("vrs", NullValueHandling = NullValueHandling.Ignore)]
        public Variant[] Variants { get; set; } = { };

        /// <summary>
        /// A subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a headword or a particular sense of a headword.
        /// </summary>
        [JsonProperty("sls", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SubjectStatusLabels { get; set; } = { };

        /// <summary>
        /// General labels provide information such as whether a headword is typically capitalized, used as an attributive noun, etc.
        /// </summary>
        [JsonProperty("lbs", NullValueHandling = NullValueHandling.Ignore)]
        public string[] GeneralLabels { get; set; } = { };

        [JsonProperty("ins", NullValueHandling = NullValueHandling.Ignore)]
        public Inflection[] Inflections { get; set; } = { };
    }
}