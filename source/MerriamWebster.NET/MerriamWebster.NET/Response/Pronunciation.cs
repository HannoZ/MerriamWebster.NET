using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class Pronunciation
    {
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