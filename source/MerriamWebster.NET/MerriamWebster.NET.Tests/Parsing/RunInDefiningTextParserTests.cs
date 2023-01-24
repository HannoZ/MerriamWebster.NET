using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class RunInDefiningTextParserTests
    {
        [TestMethod]
        public void RunInDefiningTextParser_Parse()
        {
            string source = @"[
                  [
                    ""riw"",
                    {""rie"":""Great Abaco""}
                  ],[
                    ""text"","" and ""
                  ],[
                    ""riw"",
                    {""rie"":""Little Abaco""}
                  ]
                ]
";

            var doc = JsonDocument.Parse(source);
            var parser = new RunInDefiningTextParser();

            // ACT
            var dt = parser.Parse(doc.RootElement);

            // ASSERT
            dt.ShouldNotBe(null);
            dt.MainText.Text.ShouldBe("Great Abaco and Little Abaco");
        }
    }
}