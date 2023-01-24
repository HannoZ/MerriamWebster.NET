using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class GenderLabelDefiningTextParserTests
    {
        [TestMethod]
        public void GenderLabelDefiningTextParser_Parse()
        {
            string source = @"""label""";

            var doc = JsonDocument.Parse(source);
            var parser = new GenderLabelDefiningTextParser();

            // ACT
            var result = parser.Parse(doc.RootElement) as GenderLabel;

            // ASSERT
            result.ShouldNotBe(null);
            result.Label.Text.ShouldBe("label");
        }
    }
}