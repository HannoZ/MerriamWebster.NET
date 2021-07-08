using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse the <see cref="Response.Pronunciation"/>
    /// </summary>
    public class PronunciationHelper
    {
        /// <summary>
        /// Converts <see cref="Response.Pronunciation"/> to <see cref="Pronunciation"/>
        /// </summary>
        /// <param name="source">The source pronunciation object</param>
        /// <param name="language">Language is used to create an audio link.</param>
        /// <param name="audioFormat">Specifies the audio format for the audio link.</param>
        /// <returns>A new <see cref="Pronunciation"/> object (empty if source was null).</returns>
        public static Pronunciation Parse(Response.Pronunciation source, Language language, AudioFormat audioFormat)
        {
            if (source == null)
            {
                return new Pronunciation();
            }

            return new Pronunciation
            {
                WrittenPronunciation = source.WrittenPronunciation,
                AudioLink = AudioLinkCreator.CreateLink(language, source.Sound, audioFormat)
                // Todo other properties
            };
        }
    }
}