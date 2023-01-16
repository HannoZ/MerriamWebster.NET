using System;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class PronuncationParserTests
    {
        [TestMethod]
        public void PronuncationParser_Parse_DocExample()
        {
            string source = @"[
    {
      ""mw"":""k\u0259-\u02c8b\u00e4-l\u0259"",
      ""sound"":{""audio"":""cabala02"",""ref"":""c"",""stat"":""1""}
    },{
      ""mw"":""\u02c8ka-b\u0259-l\u0259"",
      ""sound"":{""audio"":""cabala01"",""ref"":""c"",""stat"":""1""}
    }
  ]";
            var doc = JsonDocument.Parse(source);

            // ACT
            var prs = PronuncationParser.Parse(doc.RootElement).ToList();

            // ASSERT
            prs.Count.ShouldBe(2);
            var pr = prs[0];
            pr.AudioLink.ShouldNotBeNull();
            pr.WrittenPronunciation.ShouldBe("kə-ˈbä-lə");
            pr.LabelAfterPronunciation.ShouldBe(null);
            pr.LabelBeforePronunciation.ShouldBe(null);
            pr.Ipa.ShouldBe(null);
            pr.Punctuation.ShouldBe(null);
            pr.Wod.ShouldBe(null);
        }

        [TestMethod]
        public void PronuncationParser_Parse_AllProperties()
        {
            string source = @"[
    {
      ""mw"":""mw"",
      ""l"":""before"",
      ""l2"":""after"",
      ""pun"":""pun"",
      ""ipa"":""ipa"",
      ""wod"":""wod"",
      ""sound"":{""audio"":""cabala02"",""ref"":""c"",""stat"":""1""}
    }  ]";
            var doc = JsonDocument.Parse(source);

            // ACT
            var prs = PronuncationParser.Parse(doc.RootElement).ToList();

            // ASSERT
            var pr = prs[0];
            pr.AudioLink.ShouldNotBeNull();
            pr.WrittenPronunciation.ShouldBe("mw");
            pr.LabelAfterPronunciation.ShouldBe("after");
            pr.LabelBeforePronunciation.ShouldBe("before");
            pr.Ipa.ShouldBe("ipa");
            pr.Punctuation.ShouldBe("pun");
            pr.Wod.ShouldBe("wod");
        }

        [TestMethod]
        public void PronuncationParser_Parse_InvalidObject()
        {
            string source = @"{
    ""vl"":""or less commonly"",
    ""va"":""kab*ba*la""
  }";
            var doc = JsonDocument.Parse(source);

            Should.Throw<ArgumentException>(() => PronuncationParser.Parse(doc.RootElement).ToList());
        }
    }
}