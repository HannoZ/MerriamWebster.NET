using System;
using System.Text.Json;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Parsing.Content;
using MerriamWebster.NET.Results.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class HeadwordInformationJsonContentParserTests
    {
        [TestMethod]
        public void HeadwordInformationJsonContentParser_Parse()
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
            var parser = new HeadwordInformationDictionaryEntryMemberParser();

            // ACT
            parser.Parse(hwi, target);

            // ASSERT
            target.Headword.Pronunciations.ShouldNotBeEmpty();
            target.Headword.Text.ShouldBe("test");
        }

        [TestMethod]
        public void HeadwordInformationJsonContentParser_Parse_TargetIsNull()
        {
            string source = @"{
""hwi"":{
  ""hw"":""test""
}
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
            var parser = new HeadwordInformationDictionaryEntryMemberParser();
            
            Should.Throw<ArgumentNullException>(() => parser.Parse(hwi, null));
        }

        [TestMethod]
        public void HeadwordInformationJsonContentParser_Parse_SourceIsNotHwi()
        {
            string source = @"{
""abc"":{
  ""hw"":""test""
}
}";

            var doc = JsonDocument.Parse(source);
            var enumerator = doc.RootElement.EnumerateObject();
            JsonProperty hwi = new JsonProperty();
            foreach (var prop in enumerator)
            {
                if (prop.Name == "abc")
                {
                    hwi = prop;
                    break;
                }                
            }
            var parser = new HeadwordInformationDictionaryEntryMemberParser();
            
            Should.Throw<ArgumentException>(() => parser.Parse(hwi, null));
        }
    }
}