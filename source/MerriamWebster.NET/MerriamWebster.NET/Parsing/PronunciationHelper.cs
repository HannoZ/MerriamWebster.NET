using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    internal class PronunciationHelper
    {
        /// <summary>
        /// Converts <see cref="Response.Pronunciation"/> to <see cref="Pronunciation"/>
        /// </summary>
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
                AudioLink = AudioLinkCreator.CreateLink(language, source.Sound, audioFormat),
                Ipa = source.Ipa,
                LabelAfterPronunciation = source.LabelAfterPronunciation,
                LabelBeforePronunciation = source.LabelBeforePronunciation,
                Punctuation = source.Punctuation,
                Wod = source.Wod
            };
        }
    }
}