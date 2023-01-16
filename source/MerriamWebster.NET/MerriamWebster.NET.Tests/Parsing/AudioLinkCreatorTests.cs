using System;
using System.Text.Json;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Results;
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
            string source = @"{
    ""vl"":""or less commonly"",
    ""va"":""kab*ba*la""
  }";
            var doc = JsonDocument.Parse(source);
            
            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            link.ShouldBeNull();
        }

        [TestMethod]
        public void AudioLinkCreator_Es_DefaultSubdir_Mp3()
        {
            string source = @"{""audio"":""hola001"",""ref"":""c"",""stat"":""1""}";
            
            Configuration.Language = Language.Es;
            var doc = JsonDocument.Parse(source);
            
            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/mp3/h/hola001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_DefaultSubdir_Mp3()
        {
            string source = @"{""audio"":""hello001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);
            
            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/h/hello001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Undefined_DefaultSubdir_Mp3()
        {
            string source = @"{""audio"":""hello001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            
            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/h/hello001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Bix_Mp3()
        {
            string source = @"{""audio"":""bix001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/mp3/bix/bix001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Bix_Mp3()
        {
            string source = @"{""audio"":""bix001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/bix/bix001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_gg_Mp3()
        {
            string source = @"{""audio"":""gg001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/mp3/gg/gg001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_gg_Mp3()
        {
            string source = @"{""audio"":""gg001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/gg/gg001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Digit_Mp3()
        {
            string source = @"{""audio"":""3d001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/mp3/number/3d001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Digit_Mp3()
        {
            string source = @"{""audio"":""3d001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/number/3d001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Punctuation_Mp3()
        {
            string source = @"{""audio"":""_001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/mp3/number/_001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Punctuation_Mp3()
        {
            string source = @"{""audio"":""_001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/mp3/number/_001.mp3");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_DefaultSubdir_Ogg()
        {
            string source = @"{""audio"":""hola001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Ogg;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/ogg/h/hola001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_DefaultSubdir_Ogg()
        {
            string source = @"{""audio"":""hello001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Ogg;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/ogg/h/hello001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Bix_Ogg()
        {
            string source = @"{""audio"":""bix001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Ogg;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/ogg/bix/bix001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Bix_Ogg()
        {
            string source = @"{""audio"":""bix001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Ogg;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/ogg/bix/bix001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_gg_Ogg()
        {
            string source = @"{""audio"":""gg001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Ogg;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/ogg/gg/gg001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_gg_Ogg()
        {
            string source = @"{""audio"":""gg001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Ogg;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/ogg/gg/gg001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Digit_Ogg()
        {
            string source = @"{""audio"":""3d001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Ogg;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/ogg/number/3d001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Digit_Ogg()
        {
            string source = @"{""audio"":""3d001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Ogg;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/ogg/number/3d001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Punctuation_Ogg()
        {
            string source = @"{""audio"":""_001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Ogg;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/ogg/number/_001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Punctuation_Ogg()
        {
            string source = @"{""audio"":""_001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Ogg;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/ogg/number/_001.ogg");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_DefaultSubdir_Wav()
        {
            string source = @"{""audio"":""hola001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Wav;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/wav/h/hola001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_DefaultSubdir_Wav()
        {
            string source = @"{""audio"":""hello001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Wav;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/wav/h/hello001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Bix_Wav()
        {
            string source = @"{""audio"":""bix001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Wav;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/wav/bix/bix001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Bix_Wav()
        {
            string source = @"{""audio"":""bix001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Wav;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/wav/bix/bix001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_gg_Wav()
        {
            string source = @"{""audio"":""gg001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Wav;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/wav/gg/gg001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_gg_Wav()
        {
            string source = @"{""audio"":""gg001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Wav;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/wav/gg/gg001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Digit_Wav()
        {
            string source = @"{""audio"":""3d001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Wav;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/wav/number/3d001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Digit_Wav()
        {
            string source = @"{""audio"":""3d001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Wav;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/wav/number/3d001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_Es_Punctuation_Wav()
        {
            string source = @"{""audio"":""_001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.Es;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Wav;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "es/me/wav/number/_001.wav");

            link.ShouldBe(expected);
        }

        [TestMethod]
        public void AudioLinkCreator_En_Punctuation_Wav()
        {
            string source = @"{""audio"":""_001"",""ref"":""c"",""stat"":""1""}";
            
            var doc = JsonDocument.Parse(source);
            Configuration.Language = Language.En;
            Configuration.ParseOptions.AudioFormat = AudioFormat.Wav;

            // ACT
            var link = AudioLinkCreator.CreateLink(doc.RootElement);

            // ASSERT
            var expected = new Uri(Configuration.MediaBaseAddres, "en/us/wav/number/_001.wav");

            link.ShouldBe(expected);
        }
    }
}
