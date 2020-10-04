using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// An undefined entry word is derived from or related to the headword, carries a functional label and possibly other information, but does not have any definitions.<br/>
    /// A set of undefined run-ons uros can follow (or "run on" from) the entry's main def definition section, with each such run-on containing a ure undefined entry word.
    /// </summary>
    public class UndefinedRunOn
    {
        /// <summary>
        /// Undefined entry word
        /// </summary>
        [JsonProperty("ure")]
        public string Ure { get; set; }

        [JsonProperty("prs", NullValueHandling = NullValueHandling.Ignore)]
        public Pronunciation[] Pronunciations { get; set; } = { };

        [JsonProperty("fl")]
        public string FunctionalLabel { get; set; }

        [JsonProperty("aure", NullValueHandling = NullValueHandling.Ignore)]
        public AlternateUndefinedEntryWord AlternateEntry { get; set; }
    }
}