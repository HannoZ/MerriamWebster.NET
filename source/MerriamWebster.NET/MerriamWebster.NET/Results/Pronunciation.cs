using System;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// Contains the written pronunciation and an (optional) link to an audio file. <br/>
    /// A pronunciation specifies how a written word is pronounced aloud. <br/>
    /// </summary>
    /// <remarks>
    /// <para>Usually there is only pronuncation record, but there can be multiple elements.
    /// Each element represents a distinct pronunciation of a headword or other term. </para>
    /// <b>Display Guidance:</b>
    /// <para>
    /// The entire set of pronunciations is typically surrounded by backslash characters.</para>
    /// <para>
    /// If there are multiple pronunciation objects and an object contains a punctuation member <see cref="Punctuation"/> (pun), use its contents plus a space to separate the two objects (for example, "\pronunciation 1; pronunciation 2" where pun contains ";").
    /// </para>
    /// <para>
    /// If <see cref="Punctuation"/> is not present, use a comma and space to separate the two objects(for example, "\pronunciation 1, pronunciation 2\").
    /// </para>
    /// The <see cref="LabelBeforePronunciation"/> and <see cref="LabelAfterPronunciation"/> pronunciation labels are typically displayed in italics.
    /// </remarks>
    public class Pronunciation
    {
        /// <summary>
        /// Written pronunciation in Merriam-Webster format.
        /// </summary>
        public string WrittenPronunciation { get; set; }

        /// <summary>
        /// Gets or sets the audio link.
        /// </summary>
        public Uri AudioLink { get; set; }

        /// <summary>
        /// <i>Optional. Not used in Collegiate dictionary.</i> International Phonetic Alphabet pronunciation.
        /// </summary>
        public string Ipa { get; set; }

        /// <summary>
        /// <i>Optional. Not used in Collegiate dictionary.</i>  Word-of-the-day pronunciation format.
        /// </summary>
        public string Wod { get; set; }
        
        /// <summary>
        /// pronunciation label <i>before</i> pronunciation
        /// </summary>
        public string LabelBeforePronunciation { get; set; }

        /// <summary>
        /// pronunciation label <i>after</i> pronunciation
        /// </summary>
        public string LabelAfterPronunciation { get; set; }
       
        /// <summary>
        /// punctuation to separate pronunciation objects.
        /// </summary>
        public string Punctuation { get; set; }
    }
}