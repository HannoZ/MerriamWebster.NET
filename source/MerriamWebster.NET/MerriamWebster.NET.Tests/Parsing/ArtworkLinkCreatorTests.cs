using System;
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
            var link = ArtworkLinkCreator.CreatePageLink(null);

            // ASSERT
            link.ShouldBeNull();
        }

        [TestMethod]
        public void ArtworkLinkCreator_CreatePageLink()
        {
            // ACT
            var link = ArtworkLinkCreator.CreatePageLink("heart");
            
            // ASSERT
            var expected = new Uri("https://www.merriam-webster.com/art/dict/heart.htm");
            link.ShouldBe(expected);
        }

        [TestMethod]
        public void ArtworkLinkCreator_CreateDirectLink_Null()
        {
            // ACT
            var link = ArtworkLinkCreator.CreateDirectLink(null);

            // ASSERT
            link.ShouldBeNull();
        }

        [TestMethod]
        public void ArtworkLinkCreator_CreateDirectLink()
        {
            // ACT
            var link = ArtworkLinkCreator.CreateDirectLink("heart");

            // ASSERT
            var expected = new Uri("https://www.merriam-webster.com/assets/mw/static/art/dict/heart.gif");
            link.ShouldBe(expected);
        }
    }
}