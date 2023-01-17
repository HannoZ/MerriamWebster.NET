using System;
using System.Linq;
using MerriamWebster.NET.Parsing.Content;
using MerriamWebster.NET.Results.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class AlternateHeadwordInformationDictionaryEntryMemberParserTests
    {
        [TestMethod]
        public void AlternateHeadwordInformationDictionaryEntryMemberParser_Parse()
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

            var ahws = EntryMemberParserTestsHelper.GetJsonProperty(source, "ahws");
            var parser = new AlternateHeadwordInformationDictionaryEntryMemberParser();

            // ACT
            parser.Parse(ahws, target);

            // ASSERT
            target.AlternateHeadwords.Count.ShouldBe(2);
            var first = target.AlternateHeadwords.First();
            first.HeadwordCutback.ShouldBe("hwc");
            first.Text.ShouldBe("agonised");
            first.ParenthesizedSubjectStatusLabel.Text.ShouldBe("psl");
        }

        [TestMethod]
        public void AlternateHeadwordInformationDictionaryEntryMemberParser_Parse_TargetIsNull()
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

            var ahws = EntryMemberParserTestsHelper.GetJsonProperty(source, "ahws");
            var parser = new AlternateHeadwordInformationDictionaryEntryMemberParser();
            
            Should.Throw<ArgumentNullException>(() => parser.Parse(ahws, null));
        }

        [TestMethod]
        public void AlternateHeadwordInformationDictionaryEntryMemberParser_Parse_SourceIsNotHwi()
        {
            string source = @"{
""hwi"":{""hw"":""ag*o*nise""}
}";

            var ahws = EntryMemberParserTestsHelper.GetJsonProperty(source, "hwi");
            var parser = new AlternateHeadwordInformationDictionaryEntryMemberParser();
            
            Should.Throw<ArgumentException>(() => parser.Parse(ahws, new Entry()));
        }
    }
}