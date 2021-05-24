using System;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// The <see cref="Pronunciation"/> class contains the written pronunciation and an (optional) link to an audio file.
    /// </summary>
    public class Pronunciation
    {
        /// <summary>
        /// Gets or sets the written pronunciation.
        /// </summary>
        public string WrittenPronunciation { get; set; }
        /// <summary>
        /// Gets or sets the audio link.
        /// </summary>
        public Uri AudioLink { get; set; }
    }
}