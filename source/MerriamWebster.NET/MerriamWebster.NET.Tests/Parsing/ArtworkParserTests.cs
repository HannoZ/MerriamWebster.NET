using System;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Parsing.Content;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
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
            //var source = new MwDictionaryEntry
            //{
            //    Artwork = new Response.Artwork
            //    {
            //        Caption = "caption",
            //        Id = "id"
            //    }
            //};

            var target = new Entry();
            //var parser = new ArtworkParser();

            // ACT
            //parser.Parse(source, target, ParseOptions.Default);

            //// ASSERT
            //var artwork = target.Artwork;
            //artwork.ShouldNotBe(null);
            //artwork.Caption.ShouldBe("caption");
            //artwork.HtmlLocation.ToString().ShouldContain("id");
            //artwork.ImageLocation.ToString().ShouldContain("id");
        }

        //[TestMethod]
        //public void ArtworkParser_Parse_SourceIsNull()
        //{
        //    var parser = new ArtworkParser();

        //    // ACT, ASSERT
        //    Should.Throw<ArgumentNullException>(() => parser.Parse(null, new Entry(), ParseOptions.Default));
        //}

        //[TestMethod]
        //public void ArtworkParser_Parse_TargetIsNull()
        //{
        //    var parser = new ArtworkParser();

        //    // ACT, ASSERT
        //    Should.Throw<ArgumentNullException>(() => parser.Parse(new MwDictionaryEntry(), null, ParseOptions.Default));
        //}

        //[TestMethod]
        //public void ArtworkParser_Parse_ArtworkIsNull()
        //{
        //    var parser = new ArtworkParser();
        //    var target = new Entry();

        //    // ACT
        //    parser.Parse(new MwDictionaryEntry(), target, ParseOptions.Default);

        //    // ASSERT
        //    target.Artwork.ShouldBe(null);
        //}
    }
}