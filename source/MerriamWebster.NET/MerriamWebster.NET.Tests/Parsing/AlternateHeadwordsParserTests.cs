using System;
using System.Linq;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Parsing.Content;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class AlternateHeadwordsParserTests
    {
        [TestMethod]
        public void AlternateHeadwordsParser_Parse()
        {
            var source = new MwDictionaryEntry
            {
                AlternateHeadwords = new[]
                {
                    new AlternateHeadword
                    {
                        Headword = "hw",
                        HeadwordCutback = "hwc",
                        ParenthesizedSubjectStatusLabel = "pssl",
                        Pronunciations = new[]
                        {
                            new Response.Pronunciation()
                        }
                    }
                }
            };
            var target = new Entry();

            var parser = new AlternateHeadwordsParser();

            // ACT
            var result = parser.Parse(source, target, ParseOptions.Default);

            // ASSERT
            result.ShouldBe(target);

            target.AlternateHeadwords.ShouldNotBeEmpty();
            var ahw = target.AlternateHeadwords.First();
            ahw.Text.ShouldBe("hw");
            ahw.HeadwordCutback.ShouldBe("hwc");
            ahw.ParenthesizedSubjectStatusLabel.Text.ShouldBe("pssl");
            ahw.Pronunciations.Count.ShouldBe(1);
        }

        [TestMethod]
        public void AlternateHeadwordsParser_Parse_SourceIsNull()
        {
            var parser = new AlternateHeadwordsParser();

            Should.Throw<ArgumentNullException>(() => parser.Parse(null, new Entry(), ParseOptions.Default));
        }

        [TestMethod]
        public void AlternateHeadwordsParser_Parse_TargetIsNull()
        {
            var parser = new AlternateHeadwordsParser();

            Should.Throw<ArgumentNullException>(() => parser.Parse(new MwDictionaryEntry(), null, ParseOptions.Default));
        }

        [TestMethod]
        public void AlternateHeadwordsParser_Parse_AlternateHeadwordsIsNull()
        {
            var parser = new AlternateHeadwordsParser();

            // ACT
            var result = parser.Parse(new MwDictionaryEntry(), new Entry(), ParseOptions.Default);

            result.AlternateHeadwords.ShouldBe(null);
        }
    }
}