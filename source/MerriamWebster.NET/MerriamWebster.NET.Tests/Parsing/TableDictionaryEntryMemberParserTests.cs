using System;
using System.Linq;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class TableDictionaryEntryMemberParserTests
    {
        [TestMethod]
        public void TableDictionaryEntryMemberParser_Parse()
        {
            string source = @"{ ""table"":{
  ""tableid"":""alphabet"",
  ""displayname"":""Alphabet Table""
}}";

            var target = new Entry();
            var parser = new TableDictionaryEntryMemberParser();
            var table = EntryMemberParserTestsHelper.GetJsonProperty(source, "table");

            // ACT
            parser.Parse(table, target);

            // ASSERT
            target.Table.ShouldNotBe(null);
            target.Table.Displayname.ShouldBe("Alphabet Table");
            target.Table.TableId.ShouldBe("alphabet");
            target.Table.TableLocation.ToString().ShouldBe("https://www.merriam-webster.com/table/collegiate/alphabet.htm");
        }

        [TestMethod]
        public void TableDictionaryEntryMemberParser_Parse_TargetIsNull()
        {
            string source = @"{ ""table"":{
  ""tableid"":""alphabet"",
  ""displayname"":""Alphabet Table""
}}";

            var parser = new TableDictionaryEntryMemberParser();
            var table = EntryMemberParserTestsHelper.GetJsonProperty(source, "table");

            // ACT/ ASSERT
            Should.Throw<ArgumentNullException>(() => parser.Parse(table, null));
        }

        [TestMethod]
        public void TableDictionaryEntryMemberParser_Parse_SourceIsNotTable()
        {
            string source = @"{ ""abc"":{
  ""tableid"":""alphabet"",
  ""displayname"":""Alphabet Table""
}}";

            var parser = new TableDictionaryEntryMemberParser();
            var table = EntryMemberParserTestsHelper.GetJsonProperty(source, "abc");

            // ACT/ ASSERT
            Should.Throw<ArgumentException>(() => parser.Parse(table, new Entry()));
        }
    }
}