using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Contains audio playback information.
    /// </summary>
    /// <remarks>
    /// Note: according to documentation "ref" and "stat" members can be ignored and are therefore not deserialized.
    /// </remarks>
    public class Sound
    {
        /// <summary>
        /// Contains the base filename for audio playback.
        /// </summary>
        [JsonProperty("audio")]
        public string Audio { get; set; }
    }
}