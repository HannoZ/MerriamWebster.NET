using System;
using System.Linq;
using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class SynonymsParserTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // ASSERT
        public void SynonymsParser_NullInput()
        {
            // ACT
            SynonymsParser.ExtractSynonyms(null);
        }

        [TestMethod]
        public void SynonymsParser_NoSynonyms()
        {
            // ACT
            var result = SynonymsParser.ExtractSynonyms("input");

            // ASSERT
            result.ShouldBeEmpty();
        }


        [TestMethod]
        public void SynonymsParser_OneSynonym()
        {
            string input = "{sx|nación||} {bc}{a_link|people}";

            // ACT
            var result = SynonymsParser.ExtractSynonyms(input);

            // ASSERT
            result.First().ShouldBe("nación");
        }

        [TestMethod]
        public void SynonymsParser_TwoSynonyms()
        {
            string input = "{sx|aldea||} {sx|poblado||} {bc}{a_link|town}, {a_link|village}";

            // ACT
            var result = SynonymsParser.ExtractSynonyms(input).ToList();

            // ASSERT
            result[0].ShouldBe("aldea");
            result[1].ShouldBe("poblado");
        }

        [TestMethod]
        public void SynonymsParser_MultipleSynonyms()
        {
            string input = "{sx|aldea||} {sx|poblado||} {bc}{a_link|town}, {a_link|village} {sx|nación||} {bc}{a_link|people}";

            // ACT
            var result = SynonymsParser.ExtractSynonyms(input);

            // ASSERT
            result.Count().ShouldBe(3);
        }

        [TestMethod]
        public void SynonymsParser_Multi_WordSynonyms()
        {
            string input = "{sx|aldea pequeña||} {sx|poblado largo||}";

            // ACT
            var result = SynonymsParser.ExtractSynonyms(input);

            // ASSERT
            result.Count().ShouldBe(2);
        }
    }
}
