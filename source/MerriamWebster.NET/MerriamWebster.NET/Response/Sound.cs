using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Contains audio playback information.
    /// </summary>
    /// <remarks>
    /// Note: according to documentation "ref" and "stat" members can be ignored. 
    /// </remarks>
    public class Sound
    {
        /// <summary>
        /// Contains the base filename for audio playback.
        /// </summary>
        [JsonProperty("audio")]
        public string Audio { get; set; }

        /// <summary>
        /// Can be ignored.
        /// </summary>
        [JsonProperty("ref", NullValueHandling = NullValueHandling.Ignore)]
        public Ref? Ref { get; set; }

        /// <summary>
        /// Can be ignored.
        /// </summary>
        [JsonProperty("stat", NullValueHandling = NullValueHandling.Ignore)]
        public string Stat { get; set; }
    }
}