using System;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class AudioLinkCreatorTests
    {
        [TestMethod]
        public void AudioLinkCreator_NoSound_NoLink()
        {
            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, null, AudioFormat.Mp3);

            // ASSERT
            link.ShouldBeNull();
        }

        [TestMethod]
        public void AudioLinkCreator_Es_DefaultSubdir_Mp3()
        {
            var sound = new Sound
            {
                Audio = "hola001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/mp3/h/hola001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_DefaultSubdir_Mp3()
        {
            var sound = new Sound
            {
                Audio = "hello001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/h/hello001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Undefined_DefaultSubdir_Mp3()
        {
            var sound = new Sound
            {
                Audio = "hello001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Undefined, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/h/hello001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Bix_Mp3()
        {
            var sound = new Sound
            {
                Audio = "bix001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/mp3/bix/bix001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Bix_Mp3()
        {
            var sound = new Sound
            {
                Audio = "bix001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/bix/bix001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_gg_Mp3()
        {
            var sound = new Sound
            {
                Audio = "gg001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/mp3/gg/gg001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_gg_Mp3()
        {
            var sound = new Sound
            {
                Audio = "gg001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/gg/gg001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Digit_Mp3()
        {
            var sound = new Sound
            {
                Audio = "3d001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/mp3/number/3d001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Digit_Mp3()
        {
            var sound = new Sound
            {
                Audio = "3d001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/number/3d001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Punctuation_Mp3()
        {
            var sound = new Sound
            {
                Audio = "_001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/mp3/number/_001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Punctuation_Mp3()
        {
            var sound = new Sound
            {
                Audio = "_001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Mp3);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/number/_001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_DefaultSubdir_Ogg()
        {
            var sound = new Sound
            {
                Audio = "hola001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Ogg);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/ogg/h/hola001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_DefaultSubdir_Ogg()
        {
            var sound = new Sound
            {
                Audio = "hello001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Ogg);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/ogg/h/hello001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Bix_Ogg()
        {
            var sound = new Sound
            {
                Audio = "bix001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Ogg);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/ogg/bix/bix001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Bix_Ogg()
        {
            var sound = new Sound
            {
                Audio = "bix001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Ogg);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/ogg/bix/bix001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_gg_Ogg()
        {
            var sound = new Sound
            {
                Audio = "gg001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Ogg);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/ogg/gg/gg001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_gg_Ogg()
        {
            var sound = new Sound
            {
                Audio = "gg001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Ogg);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/ogg/gg/gg001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Digit_Ogg()
        {
            var sound = new Sound
            {
                Audio = "3d001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Ogg);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/ogg/number/3d001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Digit_Ogg()
        {
            var sound = new Sound
            {
                Audio = "3d001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Ogg);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/ogg/number/3d001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Punctuation_Ogg()
        {
            var sound = new Sound
            {
                Audio = "_001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Ogg);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/ogg/number/_001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Punctuation_Ogg()
        {
            var sound = new Sound
            {
                Audio = "_001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Ogg);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/ogg/number/_001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_DefaultSubdir_Wav()
        {
            var sound = new Sound
            {
                Audio = "hola001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Wav);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/wav/h/hola001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_DefaultSubdir_Wav()
        {
            var sound = new Sound
            {
                Audio = "hello001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Wav);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/wav/h/hello001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Bix_Wav()
        {
            var sound = new Sound
            {
                Audio = "bix001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Wav);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/wav/bix/bix001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Bix_Wav()
        {
            var sound = new Sound
            {
                Audio = "bix001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Wav);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/wav/bix/bix001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_gg_Wav()
        {
            var sound = new Sound
            {
                Audio = "gg001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Wav);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/wav/gg/gg001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_gg_Wav()
        {
            var sound = new Sound
            {
                Audio = "gg001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Wav);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/wav/gg/gg001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Digit_Wav()
        {
            var sound = new Sound
            {
                Audio = "3d001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Wav);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/wav/number/3d001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Digit_Wav()
        {
            var sound = new Sound
            {
                Audio = "3d001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Wav);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/wav/number/3d001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Punctuation_Wav()
        {
            var sound = new Sound
            {
                Audio = "_001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.Es, sound, AudioFormat.Wav);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/wav/number/_001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Punctuation_Wav()
        {
            var sound = new Sound
            {
                Audio = "_001"
            };

            // ACT
            var link = AudioLinkCreator.CreateLink(Lang.En, sound, AudioFormat.Wav);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/wav/number/_001.wav");

            link.ShouldBe(expected);
        }
    }
}
