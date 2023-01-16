using System;
using System.Text.Json;
using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class ArtworkLinkCreatorTests
    {
        [TestMethod]
        public void ArtworkLinkCreator_CreatePageLink_Null()
        {
            // ACT
            var link = ArtworkLinkCreator.CreatePageLink(new JsonElement());

            // ASSERT
            link.ShouldBeNull();
        }

        [TestMethod]
        public void ArtworkLinkCreator_CreatePageLink()
        {
            //var artwork = new Artwork
            //{
            //    Id = "heart"
            //};
            JsonElement artwork = new JsonElement();

            // ACT
            var link = ArtworkLinkCreator.CreatePageLink(artwork);
            
            // ASSERT
            var expected = new Uri("https://www.merriam-webster.com/art/dict/heart.htm");
          //  link.ShouldBe(expected);
        }

        [TestMethod]
        public void ArtworkLinkCreator_CreateDirectLink_Null()
        {
            // ACT
            var link = ArtworkLinkCreator.CreateDirectLink(new JsonElement());

            // ASSERT
            link.ShouldBeNull();
        }

        [TestMethod]
        public void ArtworkLinkCreator_CreateDirectLink()
        {
            //var artwork = new Artwork
            //{
            //    Id = "heart"
            //};
            JsonElement artwork = new JsonElement();

            // ACT
            var link = ArtworkLinkCreator.CreateDirectLink(artwork);

            // ASSERT
            var expected = new Uri("https://www.merriam-webster.com/assets/mw/static/art/dict/heart.gif");
           // link.ShouldBe(expected);
        }
    }
}