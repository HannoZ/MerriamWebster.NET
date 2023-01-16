using System;
using System.Text.Json;
using MerriamWebster.NET.Parsing.Content;
using MerriamWebster.NET.Results.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class VariantsJsonContentParserTests
    {
        [TestMethod]
        public void VariantsJsonContentParser_Parse()
        {
            string source = @"{""vrs"":[
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
]}";
            var target = new Entry();

            var doc = JsonDocument.Parse(source);
            var enumerator = doc.RootElement.EnumerateObject();
            var vrs = new JsonProperty();
            foreach (var prop in enumerator)
            {
                if (prop.Name == "vrs")
                {
                    vrs = prop;
                    break;
                }                
            }

            var parser = new VariantsDictionaryEntryMemberParser();

            // ACT
            parser.Parse(vrs, target);
            target.Variants.Count.ShouldBe(5);
        }

        [TestMethod]
        public void VariantsJsonContentParser_Parse_TargetIsNull()
        {
            string source = @"{""vrs"":[
  {
    ""vl"":""or less commonly"",
    ""va"":""kab*ba*la""
  }
]}";

            var doc = JsonDocument.Parse(source);
            var enumerator = doc.RootElement.EnumerateObject();
            var vrs = new JsonProperty();
            foreach (var prop in enumerator)
            {
                if (prop.Name == "vrs")
                {
                    vrs = prop;
                    break;
                }                
            }

            var parser = new VariantsDictionaryEntryMemberParser();

            Should.Throw<ArgumentNullException>(() => parser.Parse(vrs, null));
        }

        [TestMethod]
        public void VariantsJsonContentParser_Parse_SourceIsNotVrs()
        {
            string source = @"{""abc"":[
  {
    ""vl"":""or less commonly"",
    ""va"":""kab*ba*la""
  }
]}";

            var doc = JsonDocument.Parse(source);
            var enumerator = doc.RootElement.EnumerateObject();
            var vrs = new JsonProperty();
            foreach (var prop in enumerator)
            {
                if (prop.Name == "abc")
                {
                    vrs = prop;
                    break;
                }                
            }

            var parser = new VariantsDictionaryEntryMemberParser();

            Should.Throw<ArgumentException>(() => parser.Parse(vrs, new Entry()));
        }
    }
}