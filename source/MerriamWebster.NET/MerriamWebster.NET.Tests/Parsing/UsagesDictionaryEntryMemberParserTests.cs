using System;
using System.Linq;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class UsagesDictionaryEntryMemberParserTests
    {
        [TestMethod]
        public void UsagesDictionaryEntryMemberParser_Parse()
        {
            string source = @"{ ""usages"": [
            {
                ""pl"": ""Using {parahw}above{/parahw} as an Adjective or Noun"",
                ""pt"": [
                    [
                        ""text"",
                        ""Although still objected to by some, the use of {it}above{/it} as a noun to mean \""something that is above\"" ""
                    ],
                    [
                        ""vis"",
                        [
                            {
                                ""t"": ""none of the {it}above{/it}""
                            },
                            {
                                ""t"": ""the {it}above{/it} is Theseus's opinion"",
                                ""aq"": {
                                    ""auth"": ""William Blake""
                                }
                            }
                        ]
                    ],
                    [
                        ""text"",
                        "" and as an adjective ""
                    ],
                    [
                        ""vis"",
                        [
                            {
                                ""t"": ""without the {it}above{/it} reserve"",
                                ""aq"": {
                                    ""auth"": ""O. W. Holmes †1935""
                                }
                            },
                            {
                                ""t"": ""I was brought up on the {it}above{/it} words"",
                                ""aq"": {
                                    ""auth"": ""Viscount Montgomery""
                                }
                            }
                        ]
                    ],
                    [
                        ""text"",
                        "" has been long established as standard.""
                    ]
                ]
            }
        ]}";

            var target = new Entry();
            var parser = new UsagesDictionaryEntryMemberParser();
            var usages = EntryMemberParserTestsHelper.GetJsonProperty(source, "usages");

            // ACT
            parser.Parse(usages, target);

            // ASSERT
            target.Usages.ShouldNotBeEmpty();
            var usage = target.Usages.First();
            usage.ParagraphLabel.Text.ShouldStartWith("Using above as an Adjective or Noun");
        }

        [TestMethod]
        public void UsagesDictionaryEntryMemberParser_Parse_TargetIsNull()
        {
            string source = @"{ ""usages"": [
            {
                ""pl"": ""Using {parahw}above{/parahw} as an Adjective or Noun"",
                ""pt"": [
                    [
                        ""text"",
                        ""Although still objected to by some, the use of {it}above{/it} as a noun to mean \""something that is above\"" ""
                    ]
                ]
            }
        ]}";

            var parser = new UsagesDictionaryEntryMemberParser();
            var usages = EntryMemberParserTestsHelper.GetJsonProperty(source, "usages");

            Should.Throw<ArgumentNullException>(() => parser.Parse(usages, null));
        }

        [TestMethod]
        public void UsagesDictionaryEntryMemberParser_Parse_SourceIsNotUsages()
        {
            string source = @"{ ""abc"": [
            {
                ""pl"": ""Using {parahw}above{/parahw} as an Adjective or Noun"",
                ""pt"": [
                    [
                        ""text"",
                        ""Although still objected to by some, the use of {it}above{/it} as a noun to mean \""something that is above\"" ""
                    ]
                ]
            }
        ]}";

            var parser = new UsagesDictionaryEntryMemberParser();
            var usages = EntryMemberParserTestsHelper.GetJsonProperty(source, "abc");

            Should.Throw<ArgumentException>(() => parser.Parse(usages, new Entry()));
        }
    }
}