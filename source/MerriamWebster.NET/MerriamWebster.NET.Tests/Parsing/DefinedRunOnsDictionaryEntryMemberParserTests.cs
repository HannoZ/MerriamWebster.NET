using System;
using System.Linq;
using MerriamWebster.NET.Parsing.Content;
using MerriamWebster.NET.Results.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class DefinedRunOnsDictionaryEntryMemberParserTests
    {
        [TestMethod]
        public void DefinedRunOnsDictionaryEntryMemberParser_Parse()
        {
            string source = @"{
        ""dros"": [
            {
                ""drp"": ""at heart"",
                ""et"":[
                  [
                    ""text"",
                    ""Some text""
                  ]
                ],
            ""prs"":[
                {
                  ""mw"":""p\u0259-\u02c8j\u00e4-m\u0259"",
                  ""sound"":{
                    ""audio"":""pajama02"",
                    ""ref"":""c"",
                    ""stat"":""1""
                  }
                }],
                ""fl"": ""func label"",
                ""lbs"":[
                  ""label 1"",
                  ""label 2""
                ],
                ""psl"":""chiefly US"",
                ""sls"":[
                  ""chiefly British"",
                  ""sometimes offensive""
                ],
                ""vrs"":[
              {
                ""vl"":""or less commonly"",
                ""va"":""kab*ba*la""
              }],
                ""def"": [
                    {
                        ""sseq"": [
                            [
                                [
                                    ""sense"",
                                    {
                                        ""dt"": [
                                            [
                                                ""text"",
                                                ""{bc}in essence {bc}{sx|basically||}, {sx|essentially||} ""
                                            ],
                                            [
                                                ""vis"",
                                                [
                                                    {
                                                        ""t"": ""a romantic {it}at heart{/it}""
                                                    }
                                                ]
                                            ]
                                        ]
                                    }
                                ]
                            ]
                        ]
                    }
                ]
            },
            {
                ""drp"": ""by heart"",
                ""def"": [
                    {
                        ""sseq"": [
                            [
                                [
                                    ""sense"",
                                    {
                                        ""dt"": [
                                            [
                                                ""text"",
                                                ""{bc}by rote or from memory ""
                                            ],
                                            [
                                                ""vis"",
                                                [
                                                    {
                                                        ""t"": ""knows the poem {it}by heart{/it}""
                                                    }
                                                ]
                                            ]
                                        ]
                                    }
                                ]
                            ]
                        ]
                    }
                ]
            },
            {
                ""drp"": ""to heart"",
                ""def"": [
                    {
                        ""sseq"": [
                            [
                                [
                                    ""sense"",
                                    {
                                        ""dt"": [
                                            [
                                                ""text"",
                                                ""{bc}with deep concern ""
                                            ],
                                            [
                                                ""vis"",
                                                [
                                                    {
                                                        ""t"": ""took the criticism {it}to heart{/it}""
                                                    }
                                                ]
                                            ]
                                        ]
                                    }
                                ]
                            ]
                        ]
                    }
                ]
            }
        ]

}";

            var target = new Entry();
            var parser = new DefinedRunOnsDictionaryEntryMemberParser();
            var dros = EntryMemberParserTestsHelper.GetJsonProperty(source, "dros");

            // ACT
            parser.Parse(dros, target);

            // ASSERT
            target.DefinedRunOns.Count.ShouldBe(3);

            var dro = target.DefinedRunOns.First();
            dro.Phrase.ShouldBe("at heart");
            dro.FunctionalLabel.Text.ShouldBe("func label");
            // TODO ET
            dro.Definitions.ShouldNotBeEmpty();
            dro.Pronunciations.ShouldNotBeEmpty();
            dro.Variants.ShouldNotBeEmpty();
            dro.GeneralLabels.Count.ShouldBe(2);
            dro.ParenthesizedSubjectStatusLabel.Text.ShouldBe("chiefly US");
            dro.SubjectStatusLabels.Count.ShouldBe(2);
        }

        [TestMethod]
        public void DefinedRunOnsDictionaryEntryMemberParser_Parse_TargetIsNull()
        {
            string source = @"{
        ""dros"": [
            {
                ""drp"": ""at heart"",
                ""def"": [
                    {
                        ""sseq"": [
                            [
                                [
                                    ""sense"",
                                    {
                                        ""dt"": [
                                            [
                                                ""text"",
                                                ""{bc}in essence {bc}{sx|basically||}, {sx|essentially||} ""
                                            ],
                                            [
                                                ""vis"",
                                                [
                                                    {
                                                        ""t"": ""a romantic {it}at heart{/it}""
                                                    }
                                                ]
                                            ]
                                        ]
                                    }
                                ]
                            ]
                        ]
                    }
                ]
            }           
        ]

}";

            var parser = new DefinedRunOnsDictionaryEntryMemberParser();
            var dros = EntryMemberParserTestsHelper.GetJsonProperty(source, "dros");

            // ACT / ASSERT
            Should.Throw<ArgumentNullException>(() => parser.Parse(dros, null));
        }

        [TestMethod]
        public void DefinedRunOnsDictionaryEntryMemberParser_Parse_SourceIsNotDros()
        {
            string source = @"{
        ""abc"": [
            {
                ""drp"": ""at heart"",
                ""def"": [
                    {
                        ""sseq"": [
                            [
                                [
                                    ""sense"",
                                    {
                                        ""dt"": [
                                            [
                                                ""text"",
                                                ""{bc}in essence {bc}{sx|basically||}, {sx|essentially||} ""
                                            ],
                                            [
                                                ""vis"",
                                                [
                                                    {
                                                        ""t"": ""a romantic {it}at heart{/it}""
                                                    }
                                                ]
                                            ]
                                        ]
                                    }
                                ]
                            ]
                        ]
                    }
                ]
            }           
        ]

}";

            var parser = new DefinedRunOnsDictionaryEntryMemberParser();
            var dros = EntryMemberParserTestsHelper.GetJsonProperty(source, "abc");

            // ACT / ASSERT
            Should.Throw<ArgumentException>(() => parser.Parse(dros, null));
        }
    }
}