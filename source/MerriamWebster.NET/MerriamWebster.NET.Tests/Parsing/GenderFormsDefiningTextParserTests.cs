using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class GenderFormsDefiningTextParserTests
    {
        [TestMethod]
        public void GenderFormsDefiningTextParser_Parse()
        {
            string source = @"{
""gwc"" : ""cutback"",
""gwd"" : ""word""
}
";

            var doc = JsonDocument.Parse(source);
            var parser = new GenderFormsDefiningTextParser();

            // ACT
            var result = parser.Parse(doc.RootElement) as GenderForms;

            // ASSERT
            result.ShouldNotBe(null);
            result.GenderWordCutback.ShouldBe("cutback");
            result.GenderWordSpelledOut.ShouldBe("word");
        }
    }
}