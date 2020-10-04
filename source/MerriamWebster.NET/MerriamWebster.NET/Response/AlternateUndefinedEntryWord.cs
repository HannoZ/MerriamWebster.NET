using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// In bilingual dictionaries, an undefined entry word may have multiple forms according to grammatical gender and number. <br/>
    /// In digital formats such forms are spelled out, while in space-constrained environments they may be presented in shortened cutback form.<br/>
    /// An alternate undefined entry is marked up by aure, and contains an undefined entry word cutback in a urec as well as a spelled-out undefined entry word in a ure.
    /// </summary>
    public class AlternateUndefinedEntryWord
    {
        /// <summary>
        /// Text of undefined entry word cutback form
        /// </summary>
        [JsonProperty("urec")]
        public string Urec { get; set; }

        /// <summary>
        /// Text of undefined entry word spelled-out form
        /// </summary>
        [JsonProperty("ure")]
        public string Ure { get; set; }
    }
}