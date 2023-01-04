using System;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Parsing.Content;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class ArtworkParserTests
    {
        [TestMethod]
        public void ArtworkParser_Parse()
        {
            var source = new MwDictionaryEntry
            {
                Artwork = new Response.Artwork
                {
                    Caption = "caption",
                    Id = "id"
                }
            };

            var target = new Entry();
            var parser = new ArtworkParser();

            // ACT
            var result = parser.Parse(source, target, ParseOptions.Default);

            // ASSERT
            result.ShouldBe(target);
            var artwork = result.Artwork;
            artwork.ShouldNotBe(null);
            artwork.Caption.ShouldBe("caption");
            artwork.HtmlLocation.ToString().ShouldContain("id");
            artwork.ImageLocation.ToString().ShouldContain("id");
        }

        [TestMethod]
        public void ArtworkParser_Parse_SourceIsNull()
        {
            var parser = new ArtworkParser();

            // ACT, ASSERT
            Should.Throw<ArgumentNullException>(() => parser.Parse(null, new Entry(), ParseOptions.Default));
        }

        [TestMethod]
        public void ArtworkParser_Parse_TargetIsNull()
        {
            var parser = new ArtworkParser();

            // ACT, ASSERT
            Should.Throw<ArgumentNullException>(() => parser.Parse(new MwDictionaryEntry(), null, ParseOptions.Default));
        }

        [TestMethod]
        public void ArtworkParser_Parse_ArtworkIsNull()
        {
            var parser = new ArtworkParser();

            // ACT
            var result = parser.Parse(new MwDictionaryEntry(), new Entry(), ParseOptions.Default);

            // ASSERT
            result.Artwork.ShouldBe(null);
        }
    }
}