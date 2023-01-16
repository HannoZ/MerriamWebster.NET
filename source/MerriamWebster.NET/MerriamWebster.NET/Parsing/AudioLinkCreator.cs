using System;
using System.Text.Json;
using MerriamWebster.NET.Results;

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
        /// <returns>A <see cref="Uri"/> that points to the audio file, or <c>null</c> if no Audio string is provided.</returns>
        public static Uri CreateLink(JsonElement source)
        {
            if (!source.TryGetProperty("audio", out var audioElement))
            {
                return null;
            }

            var audio = audioElement.GetString().AsSpan();
            var baseAddress = Configuration.MediaBaseAddres;
            string subDir = audio[0].ToString();
            if (audio.StartsWith("bix"))
            {
                subDir = "bix";
            }
            else if (audio.StartsWith("gg"))
            {
                subDir = "gg";
            }
            else if (char.IsDigit(audio[0]) || audio[0] == '_')
            {
                subDir = "number";
            }

            string relative = $"{(Configuration.Language == Language.Es ? "es" : "en")}/{(Configuration.Language == Language.Es ? "me" : "us")}/{Configuration.ParseOptions.AudioFormat}/{subDir}/{audio}.{Configuration.ParseOptions.AudioFormat}".ToLower();

            return new Uri(baseAddress, relative);
        }
    }
}
