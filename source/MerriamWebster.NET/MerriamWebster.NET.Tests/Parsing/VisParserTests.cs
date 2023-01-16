using System;
using System.Text.Json;
using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
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
            vis.AttributionOfQuote.Author.ShouldBe("Peter Pouncey");
            vis.AttributionOfQuote.Source.Text.ShouldBe("Rules for Old Men Waiting");
            vis.AttributionOfQuote.PublicationDate.ShouldBe("2005");
        }

        [TestMethod]
        public void VisParser_AqWithSubsource()
        {
            string source = @"{""t"":""As far as sound repetition goes, ..."",
    ""aq"":{
      ""auth"":""Maxine Kumin"",
      ""source"":""\u0022A Questionnaire\u0022"",
      ""aqdate"":""1977"",
      ""subsource"":{
        ""source"":""in {it}To Make a Prairie{\/it}"",
        ""aqdate"":""1979""
      }
    }
  }";

            var doc = JsonDocument.Parse(source);

            // ACT
            var vis = VisParser.Parse(doc.RootElement);
            var sub = vis.AttributionOfQuote.Subsource;
            sub.PublicationDate.ShouldBe("1979");
            sub.Source.Text.ShouldBe("in To Make a Prairie");

        }
}
}