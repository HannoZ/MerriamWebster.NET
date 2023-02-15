using System.Text.Json;
using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class AttributionOfQuoteParserTests
    {
        [TestMethod]
        public void AttributionOfQuoteParser_Parse()
        {
            string source = @" {
        ""auth"": ""Peter Pouncey"",
        ""source"": ""{it}Rules for Old Men Waiting{/it}"",
        ""aqdate"": ""2005""
    }
";

            var doc = JsonDocument.Parse(source);

            // ACT
            var aq = AttributionOfQuoteParser.Parse(doc.RootElement);
            
            // ASSERT
            aq.Author.ShouldBe("Peter Pouncey");
            aq.Source.Text.ShouldBe("Rules for Old Men Waiting");
            aq.PublicationDate.ShouldBe("2005");

        }

        [TestMethod]
        public void AttributionOfQuoteParser_Parse_WithSubSource()
        {
            string source = @"{
      ""auth"":""Maxine Kumin"",
      ""source"":""\u0022A Questionnaire\u0022"",
      ""aqdate"":""1977"",
      ""subsource"":{
        ""source"":""in {it}To Make a Prairie{\/it}"",
        ""aqdate"":""1979""
      }
    }
  ";

            var doc = JsonDocument.Parse(source);

            // ACT
            var aq = AttributionOfQuoteParser.Parse(doc.RootElement);
            
            // ASSERT
            var sub = aq.Subsource;
            sub.PublicationDate.ShouldBe("1979");
            sub.Source.Text.ShouldBe("in To Make a Prairie");
        }
    }
}