using System;
using System.Linq;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class QuotesDictionaryEntryMemberParserTests
    {
        [TestMethod]
        public void QuotesDictionaryEntryMemberParser_Parse()
        {
            string source = @"{ ""quotes"": [
            {
                ""t"": ""Another of their assignments was to slow-fly any plane that had a new engine to break it in; that meant flying the aircraft for a {qword}tedious{/qword} hour-and-a-half as slowly as it would possibly go without falling out of the sky."",
                ""aq"": {
                    ""auth"": ""Doris Weatherford"",
                    ""source"": ""{it}American Women and World War II{/it}"",
                    ""aqdate"": ""1990""
                }
            },
            {
                ""t"": ""Writing a new spreadsheet or word-processing program these days is a {qword}tedious{/qword} process, like building a skyscraper out of toothpicks."",
                ""aq"": {
                    ""auth"": ""Jeff Goodell"",
                    ""source"": ""{it}Rolling Stone{/it}"",
                    ""aqdate"": ""16 June 1994""
                }
            },
            {
                ""t"": ""From there, it became clear that the deposition was going to be neither as undramatic nor as quotidian, and even {qword}tedious{/qword}, as it at first appeared."",
                ""aq"": {
                    ""auth"": ""Renata Adler"",
                    ""source"": ""{it}New Yorker{/it}"",
                    ""aqdate"": ""June 23, 1986""
                }
            }
        ]}";

            var target = new Entry();
            var parser = new QuotesDictionaryEntryMemberParser();
            var quotes = EntryMemberParserTestsHelper.GetJsonProperty(source, "quotes");

            // ACT
            parser.Parse(quotes, target);

            // ASSERT
            target.Quotes.ShouldNotBeEmpty();
            var quote = target.Quotes.FirstOrDefault();
            quote.Text.Text.ShouldStartWith("Another of their assignments was to");
            quote.AttributionOfQuote.ShouldNotBe(null);
        }

         [TestMethod]
        public void QuotesDictionaryEntryMemberParser_Parse_TargetIsNull()
        {
            string source = @"{ ""quotes"": [
            {
                ""t"": ""Another of their assignments was to slow-fly any plane that had a new engine to break it in; that meant flying the aircraft for a {qword}tedious{/qword} hour-and-a-half as slowly as it would possibly go without falling out of the sky."",
                ""aq"": {
                    ""auth"": ""Doris Weatherford"",
                    ""source"": ""{it}American Women and World War II{/it}"",
                    ""aqdate"": ""1990""
                }
            }            
        ]}";

            var parser = new QuotesDictionaryEntryMemberParser();
            var quotes = EntryMemberParserTestsHelper.GetJsonProperty(source, "quotes");

            // ACT/ ASSERT
            Should.Throw<ArgumentNullException>(()=> parser.Parse(quotes, null));
        }

        [TestMethod]
        public void QuotesDictionaryEntryMemberParser_Parse_SourceIsNotQuotes()
        {
            string source = @"{ ""abc"": [
            {
                ""t"": ""Another of their assignments was to slow-fly any plane that had a new engine to break it in; that meant flying the aircraft for a {qword}tedious{/qword} hour-and-a-half as slowly as it would possibly go without falling out of the sky."",
                ""aq"": {
                    ""auth"": ""Doris Weatherford"",
                    ""source"": ""{it}American Women and World War II{/it}"",
                    ""aqdate"": ""1990""
                }
            }            
        ]}";

            var parser = new QuotesDictionaryEntryMemberParser();
            var quotes = EntryMemberParserTestsHelper.GetJsonProperty(source, "abc");

            // ACT/ ASSERT
            Should.Throw<ArgumentException>(()=> parser.Parse(quotes, new Entry()));
        }
    }
}