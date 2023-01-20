using System;
using System.Text.Json;
using MerriamWebster.NET.Parsing;
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

    [TestClass]
    public class VisParserTests
    {
        [TestMethod]
        public void VisParser_TextWithTranslation()
        {
            string source = @"{
    ""t"": ""distinto de/a"",
    ""tr"": ""different from/than""
}";
            var doc = JsonDocument.Parse(source);

            // ACT
            var vis = VisParser.Parse(doc.RootElement);

            // ASSERT
            vis.Sentence.RawText.ShouldBe("distinto de/a");
            vis.Translation.ShouldBe("different from/than");
        }

        [TestMethod]
        public void VisParser_AttributionOfQuote()
        {
            string source = @"{
    ""t"": ""Now his anger had poisoned all relationships, no one could be put in the two empty beds in the room, and not even his long-suffering sister could {qword}abide{/qword} him in her house."",
    ""aq"": {
        ""auth"": ""Peter Pouncey"",
        ""source"": ""{it}Rules for Old Men Waiting{/it}"",
        ""aqdate"": ""2005""
    }
}";
            var doc = JsonDocument.Parse(source);

            // ACT
            var vis = VisParser.Parse(doc.RootElement);

            // ASSERT
            vis.AttributionOfQuote.ShouldNotBe(null);
        }

    }
}