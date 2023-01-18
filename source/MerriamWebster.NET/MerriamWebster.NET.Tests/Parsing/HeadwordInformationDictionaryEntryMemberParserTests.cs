using System;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class HeadwordInformationDictionaryEntryMemberParserTests
    {
        [TestMethod]
        public void HeadwordInformationDictionaryEntryMemberParser_Parse()
        {
            var target = new Entry();
            string source = @"{
""hwi"":{
  ""hw"":""test"",
  ""prs"":[{
    ""mw"":""\u02c8test"",
    ""sound"":{""audio"":""test0001"",""ref"":""c"",""stat"":""1""}
  }]
}
}";

            var hwi = EntryMemberParserTestsHelper.GetJsonProperty(source, "hwi");
            var parser = new HeadwordInformationDictionaryEntryMemberParser();

            // ACT
            parser.Parse(hwi, target);

            // ASSERT
            target.Headword.Pronunciations.ShouldNotBeEmpty();
            target.Headword.Text.ShouldBe("test");
        }

        [TestMethod]
        public void HeadwordInformationDictionaryEntryMemberParser_Parse_TargetIsNull()
        {
            string source = @"{
""hwi"":{
  ""hw"":""test""
}
}";

            var hwi = EntryMemberParserTestsHelper.GetJsonProperty(source, "hwi");
            var parser = new HeadwordInformationDictionaryEntryMemberParser();
            
            Should.Throw<ArgumentNullException>(() => parser.Parse(hwi, null));
        }

        [TestMethod]
        public void HeadwordInformationDictionaryEntryMemberParser_Parse_SourceIsNotHwi()
        {
            string source = @"{
""abc"":{
  ""hw"":""test""
}
}";

            var hwi = EntryMemberParserTestsHelper.GetJsonProperty(source, "abc");
            var parser = new HeadwordInformationDictionaryEntryMemberParser();
            
            Should.Throw<ArgumentException>(() => parser.Parse(hwi, null));
        }
    }
}