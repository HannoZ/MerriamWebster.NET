using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class UsageNoteDefiningTextParserTests
    {
        [TestMethod]
        public void UsageNoteDefiningTextParser_Parse()
        {
            string source = @"[
  [
    [
      ""text"",
      ""used chiefly in the phrase {phrase}in abeyance{\/phrase} ""
    ],
    [
      ""vis"",
      [
        {
          ""t"": ""new contracts on all but one existing mine.."",
          ""aq"": { ""auth"": ""Vimala Sarma"" }
        },
        {
          ""t"": ""a plan that is currently being held {wi}in abeyance{\/wi}""
        }
      ]
    ]
  ]
]";
            var doc = JsonDocument.Parse(source);
            var parser = new UsageNoteDefiningTextParser();

            // ACT
            var result = parser.Parse(doc.RootElement) as UsageNote;

            // ASSERT
            result.ShouldNotBe(null);
            var dts = result.DefiningTexts.ToList();
            dts.Count.ShouldBe(3); // 1 text, 2 vis texts
            dts[0].MainText.Text.ShouldBe("used chiefly in the phrase in abeyance ");
            dts[1].ShouldBeOfType<VerbalIllustration>();
        }
    }
}