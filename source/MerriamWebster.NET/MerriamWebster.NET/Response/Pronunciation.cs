﻿using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A pronunciation specifies how a written word is pronounced aloud.
    /// It can contain a written representation of the word's pronunciation, sound file information for audio playback, and various labels and punctuation.
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