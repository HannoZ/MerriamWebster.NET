using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class SenseParserTests
    {
        [TestMethod]
        public void SenseParser_CanParse_Jiron()
        {
            string source = @"
{
                ""sseq"": [
                    [
                        [
                            ""sense"",
                            {
                                ""sn"": ""1"",
                                ""dt"": [
                                    [
                                        ""text"",
                                        ""{bc}{a_link|shred}, {a_link|rag} ""
                                    ],
                                    [
                                        ""vis"",
                                        [
                                            {
                                                ""t"": ""hecho jirones"",
                                                ""tr"": ""in tatters""
                                            }
                                        ]
                                    ]
                                ]
                            }
                        ]
                    ],
                    [
                        [
                            ""sense"",
                            {
                                ""sn"": ""2"",
                                ""sls"": [
                                    ""Peru""
                                ],
                                ""dt"": [
                                    [
                                        ""text"",
                                        ""{bc}{a_link|street}""
                                    ]
                                ]
                            }
                        ]
                    ]
                ]
            }";

            var doc = JsonDocument.Parse(source);
            var target = new Results.Definition();
            SenseParser.Parse(doc.RootElement, target);

            var senses = GetSenses(target);
            senses.ShouldContain(s=>s.SubjectStatusLabels.HasValue());
        }


        [TestMethod]
        public void SenseParser_CanParse_Abaco()
        {
            string source = @"{""sseq"": [
                    [
                        [
                            ""sense"",
                            {
                                ""dt"": [
                                    [
                                        ""text"",
                                        ""two islands of the Bahamas (""
                                    ],
                                    [
                                        ""ri"",
                                        [
                                            [
                                                ""riw"",
                                                {
                                                    ""rie"": ""Great Abaco""
                                                }
                                            ],
                                            [
                                                ""text"",
                                                "" and ""
                                            ],
                                            [
                                                ""riw"",
                                                {
                                                    ""rie"": ""Little Abaco""
                                                }
                                            ]
                                        ]
                                    ],
                                    [
                                        ""text"",
                                        "" ) north of New Providence Island {it}area{/it} 776 square miles (2018 square kilometers), {it}population{/it} 13,170""
                                    ]
                                ]
                            }
                        ]
                    ]
                ]
}";

            var doc = JsonDocument.Parse(source);
            var target = new Results.Definition();
            SenseParser.Parse(doc.RootElement, target);

            var dts = GetDefiningTexts(target)
               .ToList();

            dts.Count.ShouldBe(3);
            dts.OfType<RunIn>().Count().ShouldBe(1);

        }

        [TestMethod]
        public void SenseParser_CanParse_Algiers()
        {
            string source = @"{
        ""sseq"": [
          [
            [
              ""sense"",
              {
                ""sn"": ""1"",
                ""dt"": [
                  [
                    ""text"",
                    ""former {d_link|Barbary State|Barbary Coast:g} in northern Africa that is now Algeria""
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sense"",
              {
                ""sn"": ""2"",
                ""dt"": [
                  [
                    ""text"",
                    ""city, port on the ""
                  ],
                  [
                    ""ri"",
                    [
                      [
                        ""riw"",
                        {
                          ""rie"": ""Bay of Algiers""
                        }
                      ],
                      [
                        ""text"",
                        "" (an inlet of Mediterranean Sea)""
                      ]
                    ]
                  ],
                  [
                    ""text"",
                    "", and capital of Algeria {it}population{/it} 1,365,400""
                  ]
                ]
              }
            ]
          ]
        ]
      }";

            var doc = JsonDocument.Parse(source);
            var target = new Results.Definition();
            SenseParser.Parse(doc.RootElement, target);

            var dts = GetDefiningTexts(target)   
                .ToList();

            dts.Count.ShouldBe(4);
            dts.OfType<RunIn>().Count().ShouldBe(1);
        }

        [TestMethod]
        public void SenseParser_CanParse_Abbey()
        {
            var content = @" 
            {
                ""sseq"": [
                    [
                        [
                            ""sense"",
                            {
                                ""dt"": [
                                    [
                                        ""text"",
                                        ""{bc}{a_link|abadía} ""
                                    ],
                                    [
                                        ""gl"",
                                        ""feminine""
                                    ]
                                ]
                            }
                        ]
                    ]
                ]
            }
        ";
            var doc = JsonDocument.Parse(content);
            var target = new Results.Definition();
            SenseParser.Parse(doc.RootElement, target);

            var gls = GetDefiningTexts(target)
                .OfType<GenderLabel>().ToList();

            gls.ShouldNotBeEmpty();
            gls.ShouldContain(g=>g.Label == "feminine");
        }

        [TestMethod]
        public void SenseParser_CanParse_Alliteration()
        {
            string source = @"{
                ""sseq"": [
                    [
                        [
                            ""sense"",
                            {
                                ""dt"": [
                                    [
                                        ""text"",
                                        ""{bc}the repetition of usually initial {d_link|consonant|consonant:2} sounds in two or more neighboring words or syllables (such as {it}w{/it}ild and {it}w{/it}oolly, {it}thr{/it}eatening {it}thr{/it}ongs) ""
                                    ],
                                    [
                                        ""ca"",
                                        {
                                            ""intro"": ""called also"",
                                            ""cats"": [
                                                {
                                                    ""cat"": ""head rhyme""
                                                },
                                                {
                                                    ""cat"": ""initial rhyme""
                                                }
                                            ]
                                        }
                                    ]
                                ]
                            }
                        ]
                    ]
                ]
            }";
            var doc = JsonDocument.Parse(source);
            var target = new Results.Definition();

            // ACT
            SenseParser.Parse(doc.RootElement, target);
            var dts = GetDefiningTexts(target);

            // ASSERT
            dts.OfType<CalledAlsoNote>().ShouldNotBeNull();
        }

        [TestMethod]
        public void SenseParser_CanParse_Reboot()
        {
            string source = @" {
        ""vd"": ""transitive + intransitive"",
        ""sseq"": [
          [
            [
              ""sense"",
              {
                ""sn"": ""1 a"",
                ""sgram"": ""T/I"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}to shut down and restart (a computer or program) ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""… the annoyance of having to {wi}reboot{/wi} the computer to switch operating systems …"",
                        ""aq"": {
                          ""auth"": ""Robert Weston""
                        }
                      },
                      {
                        ""t"": ""If anything ever happens to the original drive, you can {wi}reboot{/wi} using the cloned drive and be up and running in minutes."",
                        ""aq"": {
                          ""auth"": ""Dan Frakes""
                        }
                      }
                    ]
                  ]
                ]
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""b"",
                ""sgram"": ""I"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}to start up again after closing or shutting down {bc}to boot up again ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""waiting for a computer/program to {wi}reboot{/wi}""
                      }
                    ]
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sense"",
              {
                ""sn"": ""2 a"",
                ""sgram"": ""T"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}to start (something) anew {bc}to refresh (something) by making a new start or creating a new version ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""It's probably not an overstatement to say Sandberg is embarking on the most ambitious mission to {wi}reboot{/wi} feminism and reframe discussions of gender since the launch of Ms. magazine in 1971."",
                        ""aq"": {
                          ""auth"": ""Belinda Luscombe""
                        }
                      },
                      {
                        ""t"": ""{wi}reboot{/wi} an old TV series""
                      }
                    ]
                  ]
                ]
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""b"",
                ""sgram"": ""I"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}to start anew {bc}to make a fresh start ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""The interior designer's heart was telling her to {wi}reboot{/wi} and downsize …"",
                        ""aq"": {
                          ""auth"": ""Susan Heeger""
                        }
                      }
                    ]
                  ]
                ]
              }
            ]
          ]
        ]
      }";

            var doc = JsonDocument.Parse(source);
            var target = new Results.Definition();

            // ACT
            SenseParser.Parse(doc.RootElement, target);
            var senses = GetSenses(target).ToList();

            // ASSERT
            senses.ShouldContain(s => s.SenseSpecificGrammaticalLabel != null);
            senses.ShouldNotContain(s => s.SenseSpecificGrammaticalLabel == null);
        }



        [TestMethod]
        public void SenseParser_CanParseSense_Above()
        {
            var content = TestHelper.LoadResponseFromFile("sense_above");
            var doc = JsonDocument.Parse(content);
            var target = new Results.Definition();

            // ACT
            SenseParser.Parse(doc.RootElement, target);


            // ASSERT
            target.SenseSequence.Count.ShouldBe(1);
            target.SenseSequence.First().Senses.Count.ShouldBe(4);

            var dts = GetDefiningTexts(target).ToList();
            dts.OfType<DefiningText>().ShouldAllBe(t => !t.Text.Text.Contains("{wi}"));
            dts.OfType<VerbalIllustration>().ShouldAllBe(vis => !vis.Sentence.Text.Contains("{wi}"));
        }

        [TestMethod]
        public void SenseParser_CanParseSense_Medical_Doctor()
        {
            var content = TestHelper.LoadResponseFromFile("sense_med_doctor");
            var doc = JsonDocument.Parse(content);
            var target = new Results.Definition();

            // ACT
            SenseParser.Parse(doc.RootElement, target);

            // ASSERT
            // verify that the divided sense has been parsed 
            target.SenseSequence
                .SelectMany(ss => ss.Senses)
                .Cast<Sense>()
                .Where(s => s.DividedSense != null)
                .ShouldNotBeEmpty();
        }

        //[TestMethod]
        //public void SenseParser_CanParseSense_Learner_Apple()
        //{
        //    var content = TestHelper.LoadResponseFromFile("sense_learn_apple");
        //    var doc = JsonDocument.Parse(content);
        //    var target = new Results.Definition();

        //    // ACT
        //    SenseParser.Parse(doc.RootElement, target);

        //    // ASSERT
        //    var dts = GetDefiningTexts(target);
        //    dts.OfType<SupplementalInformationNote>().ShouldNotBeEmpty();
        //}

        [TestMethod]
        public void SenseParser_SynonymsNotInText()
        {
            string source = @"{""sseq"": [
          [
            [
              ""sense"",
              {
                ""sn"": ""1"",
                ""dt"": [
                  [
                    ""text"",
                    ""{sx|nación||} {bc}{a_link|people}""
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sense"",
              {
                ""sn"": ""2"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}common people""
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sense"",
              {
                ""sn"": ""3"",
                ""dt"": [
                  [
                    ""text"",
                    ""{sx|aldea||} {sx|poblado||} {bc}{a_link|town}, {a_link|village}""
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sense"",
              {
                ""sn"": ""4"",
                ""vrs"": [
                  {
                    ""va"": ""pueblo jóven""
                  }
                ],
                ""sls"": [
                  ""Peru""
                ],
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}{a_link|shantytown}, slums {it}plural{/it}""
                  ]
                ]
              }
            ]
          ]
        ]
      }";

            var doc = JsonDocument.Parse(source);
            var target = new Results.Definition();

            // ACT
            SenseParser.Parse(doc.RootElement, target);
            

            var dts = GetDefiningTexts(target);
            dts.OfType<DefiningText>().ShouldAllBe(t => !t.Text.Text.Contains(":"));
        }

        [TestMethod]
        public void SenseParser_AttributionOfQuote_Ginger()
        {
            string source = @"{
        ""sseq"": [
          [
            [
              ""sense"",
              {
                ""sn"": ""b"",
                ""sls"": [
                  ""chiefly British"",
                  ""sometimes offensive""
                ],
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}a person with red hair {bc}{sx|redhead||1} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""The Breda Redhead Days festival\u2014which grew out of a photo shoot by Dutch artist Bart Rouwenhorst\u2014now attracts five or six thousand {wi}gingers{/wi} from around the world."",
                        ""aq"": { ""auth"": ""Bruce Ingram"" }
                      }
                    ]
                  ]
                ]
              }
            ]
          ]
        ]
      }";

            var doc = JsonDocument.Parse(source);
            var target = new Results.Definition();

            // ACT
            SenseParser.Parse(doc.RootElement, target);

            var dts = GetDefiningTexts(target);
            var vis = dts.OfType<VerbalIllustration>();
            vis.ShouldContain(v=>v.AttributionOfQuote != null);
        }
        
        [TestMethod]
        public void SenseParser_CanParseSense_Coll_Dodgson()
        {
            var content = @" 
            {
        ""sseq"": [
          [
            [
              ""sense"",
              {
                ""dt"": [
                  [
                    ""bnw"",
                    {
                      ""pname"": ""Charles Lut*widge"",
                      ""prs"": [
                        {
                          ""mw"": ""ˈlət-wij"",
                          ""sound"": {
                            ""audio"": ""bixdod04"",
                            ""ref"": ""c"",
                            ""stat"": ""1""
                          }
                        }
                      ]
                    }
                  ],
                  [
                    ""text"",
                    ""1832–1898 pseudonym""
                  ],
                  [
                    ""bnw"",
                    {
                      ""altname"": ""Lewis Car*roll"",
                      ""prs"": [
                        {
                          ""mw"": ""ˈker-əl"",
                          ""sound"": {
                            ""audio"": ""bixdod05"",
                            ""ref"": ""c"",
                            ""stat"": ""1""
                          }
                        },
                        {
                          ""mw"": ""ˈka-rəl""
                        }
                      ]
                    }
                  ],
                  [
                    ""text"",
                    "" English mathematician and writer""
                  ]
                ]
              }
            ]
          ]
        ]
      }
        ";
            var doc = JsonDocument.Parse(content);
            var target = new Results.Definition();

            // ACT
            SenseParser.Parse(doc.RootElement, target);
            var dts = GetDefiningTexts(target);

            // ASSERT
            dts.OfType<BiographicalNameWrap>().Count().ShouldBe(2);
        }

        [TestMethod]
        public void SenseParser_CanParse_Banadera()
        {
            string source = @"{
                ""sls"": [
                    ""Argentina, Uruguay""
                ],
                ""sseq"": [
                    [
                        [
                            ""sen"",
                            {
                                ""xrs"": [
                                    [
                                        {
                                            ""xrt"": ""bañera"",
                                            ""xref"": ""ban~era""
                                        }
                                    ]
                                ]
                            }
                        ]
                    ]
                ]
            }";

            var doc = JsonDocument.Parse(source);
            var target = new Results.Definition();

            // ACT
            SenseParser.Parse(doc.RootElement, target);
            var senses = GetSenses(target);

            // ASSERT
            senses.Cast<Sense>().ShouldContain(s => s.CrossReferences != null && s.CrossReferences.Any());
        }


        private static IEnumerable<SenseBase> GetSenses(Definition definition)
            => definition.SenseSequence
                .SelectMany(ss => ss.Senses).OfType<SenseBase>();

        private IEnumerable<IDefiningText> GetDefiningTexts(Definition definition) =>
            GetSenses(definition)
                .SelectMany(s => s.DefiningTexts)
                .ToList();

    }
}