using System;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class InflectionParserTests
    {
        [TestMethod]
        public void InflectionParser_Parse()
        {
            string source = @"[
  {
    ""ifc"":""-seled"",
    ""if"":""tas*seled"",
     ""il"":""label"",
     ""spl"":""spl"",
    ""aif"":{
          ""ifc"":""-tas"",
          ""if"":""distintas""
        }
},{
    ""il"":""or"",
    ""ifc"":""-sel*ling"",
    ""if"":""tas*sel*ling"",
    ""prs"":[
      {
        ""mw"":""\u02c8ta-s(\u0259-)li\u014b"",
        ""sound"":{""audio"":""tassel02"",""ref"":""c"",""stat"":""1""}
      }
    ]
  }
]";

            var doc = JsonDocument.Parse(source);

            // ACT
            var result = InflectionsParser.Parse(doc.RootElement).ToList();

            // ASSERT
            result.Count.ShouldBe(2);
            var inf0 = result[0];
            inf0.Value.ShouldBe("tas*seled");
            inf0.Cutback.ShouldBe("-seled");
            inf0.Label.ShouldBe("label");
            inf0.SenseSpecificInflectionPluralLabel.ShouldBe("spl");
            var alt = inf0.Alternate;
            alt.Cutback.ShouldBe("-tas");
            alt.Inflection.ShouldBe("distintas");

            var inf1 = result[1];
            inf1.Pronunciations.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void InflectionParser_Parse_SourceIsNotArray()
        {
            string source = @"{
    ""t"": ""distinto de/a"",
    ""tr"": ""different from/than""
}";

            var doc = JsonDocument.Parse(source);

            Should.Throw<ArgumentException>(() => InflectionsParser.Parse(doc.RootElement).ToList());
        }
    }
}