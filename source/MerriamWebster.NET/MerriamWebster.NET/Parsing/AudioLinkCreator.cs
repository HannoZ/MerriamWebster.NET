using System;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing
{
    public class AudioLinkCreator
    {
        public static Uri CreateLink(Lang language, Sound sound, AudioFormat format)
        {
            if (sound == null)
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

            string relative = $"{(language == Lang.Es ? "es" : "en")}/{(language == Lang.Es ? "me" : "us")}/{format}/{subDir}/{sound.Audio}.{format}".ToLower();

            return new Uri(baseAddress, relative);
        }
    }
}
