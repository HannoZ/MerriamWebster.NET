using System;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class VariantParserTests
    {
        [TestMethod]
        public void VariantParser_Parse_Happyflow()
        {
            string source = @"[
  {
    ""vl"":""or less commonly"",
    ""va"":""kab*ba*la""
  },{
    ""vl"":""l"",
    ""va"":""text"",
     ""vac"":""cb"",
    ""spl"":""spl"",
""prs"":[
    {
      ""mw"":""k\u0259-\u02c8b\u00e4-l\u0259"",
      ""sound"":{""audio"":""cabala02"",""ref"":""c"",""stat"":""1""}
    },{
      ""mw"":""\u02c8ka-b\u0259-l\u0259"",
      ""sound"":{""audio"":""cabala01"",""ref"":""c"",""stat"":""1""}
    }
  ]
 },{
    ""vl"":""or"",
    ""va"":""ca*ba*la""
  },{
    ""vl"":""or"",
    ""va"":""cab*ba*la""
  },{
    ""vl"":""or"",
    ""va"":""cab*ba*lah""
  }
]";
            var doc = JsonDocument.Parse(source);
            
            // ACT
            var result = VariantParser.Parse(doc.RootElement).ToList();

            // ASSERT
            result.Count.ShouldBe(5);
            var variant = result[1];
            variant.Text.ShouldBe("text");
            variant.Cutback.ShouldBe("cb");
            variant.Label.ShouldBe("l");
            variant.SenseSpecificInflectionPluralLabel.Text.ShouldBe("spl");
            variant.Pronunciations.Count.ShouldBe(2);
        }

        [TestMethod]
        public void VariantParser_Parse_SourceIsNotArray()
        {
            string source = @"{
    ""t"": ""distinto de/a"",
    ""tr"": ""different from/than""
}";

            var doc = JsonDocument.Parse(source);

            Should.Throw<ArgumentException>(() => VariantParser.Parse(doc.RootElement).ToList());
        }
    }
}
