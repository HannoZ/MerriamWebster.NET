using System;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing.Content;
using MerriamWebster.NET.Results.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class AlternateHeadwordInformationJsonContentParserTests
    {
        [TestMethod]
        public void AlternateHeadwordInformationJsonContentParser_Parse()
        {
            var target = new Entry();
            string source = @"{
""hwi"":{""hw"":""ag*o*nise""},
""ahws"":[
  {
    ""hw"":""agonised"",
    ""hwc"":""hwc"",
  ""psl"":""psl"",
  ""prs"":[{
    ""mw"":""\u02c8test"",
    ""sound"":{""audio"":""test0001"",""ref"":""c"",""stat"":""1""}
  }]
  },{
    ""hw"":""agonising""
  }
]
}";

            var doc = JsonDocument.Parse(source);
            var enumerator = doc.RootElement.EnumerateObject();
            JsonProperty hwi = new JsonProperty();
            foreach (var prop in enumerator)
            {
                if (prop.Name == "ahws")
                {
                    hwi = prop;
                    break;
                }                
            }
            var parser = new AlternateHeadwordInformationDictionaryEntryMemberParser();

            // ACT
            parser.Parse(hwi, target);

            // ASSERT
            target.AlternateHeadwords.Count.ShouldBe(2);
            var first = target.AlternateHeadwords.First();
            first.HeadwordCutback.ShouldBe("hwc");
            first.Text.ShouldBe("agonised");
            first.ParenthesizedSubjectStatusLabel.Text.ShouldBe("psl");
        }

        [TestMethod]
        public void AlternateHeadwordInformationJsonContentParser_Parse_TargetIsNull()
        {
            string source = @"{
""ahws"":[
  {
    ""hw"":""agonised""
  },{
    ""hw"":""agonising""
  }
]
}";

            var doc = JsonDocument.Parse(source);
            var enumerator = doc.RootElement.EnumerateObject();
            JsonProperty hwi = new JsonProperty();
            foreach (var prop in enumerator)
            {
                if (prop.Name == "ahws")
                {
                    hwi = prop;
                    break;
                }                
            }
            var parser = new AlternateHeadwordInformationDictionaryEntryMemberParser();
            
            Should.Throw<ArgumentNullException>(() => parser.Parse(hwi, null));
        }

        [TestMethod]
        public void AlternateHeadwordInformationJsonContentParser_Parse_SourceIsNotHwi()
        {
            string source = @"{
""hwi"":{""hw"":""ag*o*nise""}
}";

            var doc = JsonDocument.Parse(source);
            var enumerator = doc.RootElement.EnumerateObject();
            JsonProperty hwi = new JsonProperty();
            foreach (var prop in enumerator)
            {
                if (prop.Name == "hwi")
                {
                    hwi = prop;
                    break;
                }                
            }
            var parser = new AlternateHeadwordInformationDictionaryEntryMemberParser();
            
            Should.Throw<ArgumentException>(() => parser.Parse(hwi, new Entry()));
        }
    }
}