using System;
using System.Linq;
using System.Text.RegularExpressions;
using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class SynonymsParserTests
    {
        [TestMethod]
        public void SynonymsParser_NullInput()
        {
            // ACT / ASSERT
            Should.Throw<ArgumentNullException>(() => SynonymsParser.ExtractSynonyms(null));
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
        public void SynonymsParser_MultipleSynonyms1()
        {
            string input = "{sx|aldea||} {sx|poblado||} {bc}{a_link|town}, {a_link|village} {sx|nación||} {bc}{a_link|people}";

            // ACT
            var result = SynonymsParser.ExtractSynonyms(input);

            // ASSERT
            result.Count().ShouldBe(3);
        }
      
        [TestMethod]
        public void SynonymsParser_MultipleSynonyms2()
        {
            string input = "{bc}{sx|sly||}, {sx|treacherous||}";

            // ACT
            var result = SynonymsParser.ExtractSynonyms(input);

            // ASSERT
            result.Count().ShouldBe(2);
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

        [TestMethod]
        public void SynonymsParser_CommaSeparated()
        {
            string input = "{sx|bite||}, {sx|gnaw||}";

            // ACT
            var result = SynonymsParser.ExtractSynonyms(input);

            // ASSERT
            result.Count().ShouldBe(2);
        }
    }
}
