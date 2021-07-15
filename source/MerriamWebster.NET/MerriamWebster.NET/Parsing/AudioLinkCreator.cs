using System;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Can be used to generate a link to an audio file. 
    /// </summary>
    public class AudioLinkCreator
    {
        /// <summary>
        /// Creates a link (<see cref="Uri"/>) to an audio file.
        /// </summary>
        /// <param name="language">The language. Only for Spanish-English dictionary.</param>
        /// <param name="sound">The sound object.</param>
        /// <param name="format">Specifies the audio format</param>
        /// <returns>A <see cref="Uri"/> that points to the audio file, or <c>null</c> if no Audio string is provided.</returns>
        public static Uri CreateLink(Language language, Sound sound, AudioFormat format)
        {
            if (sound == null || string.IsNullOrEmpty(sound.Audio))
            {
                return null;
            }

            var baseAddress = Configuration.MediaBaseAddres;
            string subDir = sound.Audio[0].ToString();
            if (sound.Audio.StartsWith("bix"))
            {
                subDir = "bix";
            }
            else if (sound.Audio.StartsWith("gg"))
            {
                subDir = "gg";
            }
            else if (char.IsDigit(sound.Audio[0]) || sound.Audio[0] == '_')
            {
                subDir = "number";
            }

            string relative = $"{(language == Language.Es ? "es" : "en")}/{(language == Language.Es ? "me" : "us")}/{format}/{subDir}/{sound.Audio}.{format}".ToLower();

            return new Uri(baseAddress, relative);
        }
    }
}
