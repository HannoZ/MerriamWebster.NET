using System;
using System.Linq;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class SynonymsDictionaryEntryMemberParserTests
    {
        [TestMethod]
        public void SynonymsDictionaryEntryMemberParser_Parse()
        {
            string source = @"{""syns"": [
            {
                ""pl"": ""synonyms"",
                ""pt"": [
                    [
                        ""text"",
                        ""{sc}agree{/sc} {sc}concur{/sc} {sc}coincide{/sc} mean to come into or be in harmony regarding a matter of opinion. {sc}agree{/sc} implies complete accord usually attained by discussion and adjustment of differences. ""
                    ],
                    [
                        ""vis"",
                        [
                            {
                                ""t"": ""on some points we all can {it}agree{/it}""
                            }
                        ]
                    ],
                    [
                        ""text"",
                        "" {sc}concur{/sc} often implies approval of someone else's statement or decision. ""
                    ],
                    [
                        ""vis"",
                        [
                            {
                                ""t"": ""if my wife {it}concurs{/it}, it's a deal""
                            }
                        ]
                    ],
                    [
                        ""text"",
                        "" {sc}coincide{/sc}, used more often of opinions, judgments, wishes, or interests than of people, implies total agreement. ""
                    ],
                    [
                        ""vis"",
                        [
                            {
                                ""t"": ""their wishes {it}coincide{/it} exactly with my desire""
                            }
                        ]
                    ]
                ],
                ""sarefs"": [
                    ""assent""
                ]
            }
        ]
}";

            var target = new Entry();
            var parser = new SynonymsDictionaryEntryMemberParser();
            var syns = EntryMemberParserTestsHelper.GetJsonProperty(source, "syns");

            // ACT
            parser.Parse(syns, target);

            // ASSERT
            target.Synonyms.ShouldNotBeEmpty();
            var syn = target.Synonyms.First();
            syn.ParagraphLabel.Text.ShouldBe("synonyms");
            syn.ParagraphTexts.ShouldNotBeEmpty();
            syn.SeeInAdditionReference.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void SynonymsDictionaryEntryMemberParser_Parse_TargetIsNull()
        {
            string source = @"{""syns"": [
            {
                ""pl"": ""synonyms"",
                ""pt"": [
                    [
                        ""text"",
                        ""{sc}agree{/sc} {sc}concur{/sc} {sc}coincide{/sc} mean to come into or be in harmony regarding a matter of opinion. {sc}agree{/sc} implies complete accord usually attained by discussion and adjustment of differences. ""
                    ]
                ],
                ""sarefs"": [
                    ""assent""
                ]
            }
        ]
}";

            var parser = new SynonymsDictionaryEntryMemberParser();
            var syns = EntryMemberParserTestsHelper.GetJsonProperty(source, "syns");

            // ACT / ASSERT
            Should.Throw<ArgumentNullException>(() => parser.Parse(syns, null));
        }

        [TestMethod]
        public void SynonymsDictionaryEntryMemberParser_Parse_SourceIsNotSyns()
        {
            string source = @"{""abc"": [
            {
                ""pl"": ""synonyms"",
                ""pt"": [
                    [
                        ""text"",
                        ""{sc}agree{/sc} {sc}concur{/sc} {sc}coincide{/sc} mean to come into or be in harmony regarding a matter of opinion. {sc}agree{/sc} implies complete accord usually attained by discussion and adjustment of differences. ""
                    ]
                ],
                ""sarefs"": [
                    ""assent""
                ]
            }
        ]
}";

            var parser = new SynonymsDictionaryEntryMemberParser();
            var syns = EntryMemberParserTestsHelper.GetJsonProperty(source, "abc");

            // ACT / ASSERT
            Should.Throw<ArgumentException>(() => parser.Parse(syns, new Entry()));
        }
    }
}