using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The <see cref="Pronunciation"/> class contains information about how to pronounce a word.
    /// </summary>
    public class Pronunciation
    {
        /// <summary>
        /// International Phonetic Alphabet pronunciation.
        /// </summary>
        [JsonProperty("ipa")]
        public string Ipa { get; set; }

        /// <summary>
        /// Word-of-the-day pronunciation format.
        /// </summary>
        [JsonProperty("wod")]
        public string Wod { get; set; }

        /// <summary>
        /// Audio playback information.
        /// </summary>
        [JsonProperty("sound", NullValueHandling = NullValueHandling.Ignore)]
        public Sound Sound { get; set; }

        /// <summary>
        /// Written pronunciation in Merriam-Webster format.
        /// </summary>
        [JsonProperty("mw", NullValueHandling = NullValueHandling.Ignore)]
        public string WrittenPronunciation { get; set; }
    }
}