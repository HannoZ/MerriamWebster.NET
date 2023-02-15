using System;
using System.Linq;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class DirectionalCrossReferencesDictionaryEntryMemberParserTests
    {
        [TestMethod]
        public void DirectionalCrossReferencesDictionaryEntryMemberParser_Parse()
        {
            string source = @"{ ""dxnls"": [
            ""see also {dxt|acadian|Acadian|}""
        ]}";

            var target = new Entry();
            var parser = new DirectionalCrossReferencesDictionaryEntryMemberParser();
            var dxnls = EntryMemberParserTestsHelper.GetJsonProperty(source, "dxnls");

            // ACT
            parser.Parse(dxnls, target);

            // ASSERT
            target.DirectionalCrossReferences.ShouldNotBe(null);
            target.DirectionalCrossReferences.First().Text.ShouldStartWith("see also ");
        }

        [TestMethod]
        public void DirectionalCrossReferencesDictionaryEntryMemberParser_Parse_TargetIsNull()
        {
            string source = @"{ ""dxnls"": [
            ""see also {dxt|acadian|Acadian|}""
        ]}";

            var parser = new DirectionalCrossReferencesDictionaryEntryMemberParser();
            var dxnls = EntryMemberParserTestsHelper.GetJsonProperty(source, "dxnls");

            // ACT / ASSERT
            Should.Throw<ArgumentNullException>(() => parser.Parse(dxnls, null));
        }

        [TestMethod]
        public void DirectionalCrossReferencesDictionaryEntryMemberParser_Parse_SourceIsNotDxnls()
        {
            string source = @"{ ""abc"": [
            ""see also {dxt|acadian|Acadian|}""
        ]}";

            var parser = new DirectionalCrossReferencesDictionaryEntryMemberParser();
            var dxnls = EntryMemberParserTestsHelper.GetJsonProperty(source, "abc");

            // ACT / ASSERT
            Should.Throw<ArgumentException>(() => parser.Parse(dxnls, new Entry()));
        }
    }
}