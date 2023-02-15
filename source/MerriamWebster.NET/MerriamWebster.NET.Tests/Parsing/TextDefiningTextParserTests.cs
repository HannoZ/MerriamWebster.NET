using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class TextDefiningTextParserTests
    {
        [TestMethod]
        public void TextDefiningTextParser_Parse()
        {
            string source = @"
""{bc}a set of letters or other characters with which one or more languages are written especially if arranged in a customary order""
";

            var doc = JsonDocument.Parse(source);
            var parser = new TextDefiningTextParser();

            // ACT
            var result = parser.Parse(doc.RootElement);

            // ASSERT
            result.MainText.RawText.ShouldBe("{bc}a set of letters or other characters with which one or more languages are written especially if arranged in a customary order");

        }
    }
}