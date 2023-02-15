using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class CalledAlsoNoteDefiningTextParserTests
    {
        [TestMethod]
        public void CalledAlsoNoteDefiningTextParser_Parse()
        {
            string source = @"{
  ""intro"": ""called also"",
  ""cats"": [
    {
      ""cat"": ""Manila hemp"",
      ""catref"": ""reference"",
      ""pn"": ""1"",
      ""psl"": ""psl"",
      ""prs"": [
        {
          ""sound"": {
            ""audio"": ""abc001sp""
          }
        }
      ]
    },
    {
      ""cat"": ""Cat 2""
    }
  ]
}";

            var doc = JsonDocument.Parse(source);
            var parser = new CalledAlsoNoteDefiningTextParser();

            // ACT
            var result = parser.Parse(doc.RootElement) as CalledAlsoNote;

            // ASSERT
            result.ShouldNotBe(null);
            result.Intro.ShouldBe("called also");
            result.Targets.Count.ShouldBe(2);

            var target = result.Targets.First();
            target.TargetText.ShouldBe("Manila hemp");
            target.Reference.ShouldBe("reference");
            target.ParenthesizedNumber.ShouldBe("1");
            target.ParenthesizedSubjectStatusLabel.Text.ShouldBe("psl");
            target.Pronunciations.ShouldNotBeEmpty();
        }
    }
}