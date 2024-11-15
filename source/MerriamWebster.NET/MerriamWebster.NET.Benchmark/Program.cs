﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using MerriamWebster.NET;
using MerriamWebster.NET.Parsing;
using Microsoft.Extensions.Logging.Abstractions;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Benchmark>();
    }
}

[SimpleJob(runtimeMoniker: RuntimeMoniker.Net80, baseline: true)]
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net90)]
[MemoryDiagnoser]
public class Benchmark
{
    const string text = @"
[
  {
    ""meta"": {
      ""id"": ""color:1"",
      ""uuid"": ""90c66dfe-1335-4e9e-89c7-2d357d6f286b"",
      ""sort"": ""035446500"",
      ""src"": ""collegiate"",
      ""section"": ""alpha"",
      ""stems"": [
        ""color"",
        ""colors"",
        ""of color""
      ],
      ""offensive"": false
    },
    ""hom"": 1,
    ""hwi"": {
      ""hw"": ""col*or"",
      ""prs"": [
        {
          ""mw"": ""ˈkə-lər"",
          ""sound"": {
            ""audio"": ""color001"",
            ""ref"": ""c"",
            ""stat"": ""1""
          }
        }
      ]
    },
    ""fl"": ""noun"",
    ""ins"": [
      {
        ""il"": ""plural"",
        ""if"": ""col*ors""
      }
    ],
    ""lbs"": [
      ""often attributive""
    ],
    ""def"": [
      {
        ""sseq"": [
          [
            [
              ""sense"",
              {
                ""sn"": ""1 a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}a phenomenon of light (such as red, brown, pink, or gray) or visual perception that enables one to differentiate otherwise identical objects""
                  ]
                ]
              }
            ],
            [
              ""pseq"",
              [
                [
                  ""sense"",
                  {
                    ""sn"": ""b (1)"",
                    ""dt"": [
                      [
                        ""text"",
                        ""{bc}the aspect of the appearance of objects and light sources that may be described in terms of hue, lightness, and saturation {dx_def}see {dxt|saturation||4}{/dx_def} for objects and hue, brightness, and saturation for light sources ""
                      ],
                      [
                        ""vis"",
                        [
                          {
                            ""t"": ""the changing {wi}color{/wi} of the sky""
                          }
                        ]
                      ]
                    ],
                    ""sdsense"": {
                      ""sd"": ""also"",
                      ""dt"": [
                        [
                          ""text"",
                          ""{bc}a specific combination of hue, saturation, and lightness or brightness ""
                        ],
                        [
                          ""vis"",
                          [
                            {
                              ""t"": ""comes in six {wi}colors{/wi}""
                            }
                          ]
                        ]
                      ]
                    }
                  }
                ],
                [
                  ""sense"",
                  {
                    ""sn"": ""(2)"",
                    ""dt"": [
                      [
                        ""text"",
                        ""{bc}a color other than and as contrasted with black, white, or gray""
                      ]
                    ]
                  }
                ]
              ]
            ],
            [
              ""sense"",
              {
                ""sn"": ""c"",
                ""ins"": [
                  {
                    ""if"": ""colors"",
                    ""spl"": ""plural""
                  }
                ],
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}clothing of a bright {dx_def}see {dxt|bright:1||4}{/dx_def} color {bc}clothing that is neither dark nor light in color ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""Wash your {wi}colors{/wi} separately from your darks and lights.""
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
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}something used to give color {bc}{sx|pigment||}""
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sense"",
              {
                ""sn"": ""3 a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}two or more hues employed in a medium of presentation ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""movies in {wi}color{/wi}""
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
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}the use or combination of colors""
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
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}skin pigmentation other than and especially darker than what is considered characteristic of people typically defined as white {dx_def}see {dxt|white:1||2a}{/dx_def} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""The charges … allege that the social network discriminates based on {wi}color{/wi} …"",
                        ""aq"": {
                          ""auth"": ""Shawn Knight""
                        }
                      }
                    ]
                  ],
                  [
                    ""uns"",
                    [
                      [
                        [
                          ""text"",
                          ""often used with {it}of{/it} ""
                        ],
                        [
                          ""vis"",
                          [
                            {
                              ""t"": ""… the policy of treating youthful offenders as adults falls most heavily on those of {wi}color{/wi}."",
                              ""aq"": {
                                ""auth"": ""Kristin Choo""
                              }
                            }
                          ]
                        ]
                      ]
                    ]
                  ],
                  [
                    ""text"",
                    "" {dx}see also {dxt|man of color||}, {dxt|person of color||}, {dxt|woman of color||}{/dx}""
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""bs"",
              {
                ""sense"": {
                  ""sn"": ""5"",
                  ""dt"": [
                    [
                      ""text"",
                      ""{bc}complexion tint:""
                    ]
                  ]
                }
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}the tint characteristic of good health ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""… sat looking at her with wistful eyes, trying to see signs of hope in the faint {wi}color{/wi} on Beth's cheeks."",
                        ""aq"": {
                          ""auth"": ""Louisa May Alcott""
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
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}{sx|blush||}""
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sense"",
              {
                ""sn"": ""6 a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}an identifying badge, pennant, or flag ""
                  ],
                  [
                    ""uns"",
                    [
                      [
                        [
                          ""text"",
                          ""usually used in plural ""
                        ],
                        [
                          ""vis"",
                          [
                            {
                              ""t"": ""a ship sailing under Swedish {wi}colors{/wi}""
                            }
                          ]
                        ]
                      ]
                    ]
                  ]
                ]
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""b"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}colored clothing distinguishing one as a member of a particular group or representative of a particular person or thing ""
                  ],
                  [
                    ""uns"",
                    [
                      [
                        [
                          ""text"",
                          ""usually used in plural ""
                        ],
                        [
                          ""vis"",
                          [
                            {
                              ""t"": ""a jockey wearing the {wi}colors{/wi} of the stable""
                            },
                            {
                              ""t"": ""wore his college {wi}colors{/wi} to the game""
                            }
                          ]
                        ]
                      ]
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
                ""sn"": ""7 a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}{sx|character||}, {sx|nature||} ""
                  ],
                  [
                    ""uns"",
                    [
                      [
                        [
                          ""text"",
                          ""usually used in plural ""
                        ],
                        [
                          ""vis"",
                          [
                            {
                              ""t"": ""showed himself in his true {wi}colors{/wi}""
                            }
                          ]
                        ]
                      ]
                    ]
                  ]
                ]
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""b"",
                ""ins"": [
                  {
                    ""if"": ""colors"",
                    ""spl"": ""plural""
                  }
                ],
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}position as to a question or course of action {bc}{sx|stand||} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""… the USSR changed neither its {wi}colors{/wi} nor its stripes during all of this …"",
                        ""aq"": {
                          ""auth"": ""Norman Mailer""
                        }
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
                ""sn"": ""8 a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}vividness or variety of effects of language ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""… that {wi}color{/wi} and force of style which were later to make him outstanding among American editors …"",
                        ""aq"": {
                          ""auth"": ""Arthur Krock""
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
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}{sx|local color||}""
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sense"",
              {
                ""sn"": ""9"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}{sx|vitality||}, {sx|interest||} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""The play had a good deal of {wi}color{/wi} to it.""
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
                ""sn"": ""10"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}analysis of game action or strategy, statistics and background information on participants, and often anecdotes provided by a sportscaster to give variety and interest to the broadcast of a game or contest ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""a {wi}color{/wi} commentator""
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
                ""sn"": ""11 a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}an outward often deceptive show {bc}{sx|appearance||} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""His story has the {wi}color{/wi} of truth.""
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
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}a legal claim to or appearance of a right, authority, or office""
                  ]
                ]
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""c"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}a {d_link|pretense|pretense} offered as justification {bc}{sx|pretext||} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""the {wi}color{/wi} for his action""
                      }
                    ]
                  ]
                ]
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""d"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}an appearance of authenticity {bc}{sx|plausibility||} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""lending {wi}color{/wi} to this notion""
                      }
                    ]
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sen"",
              {
                ""sn"": ""12"",
                ""ins"": [
                  {
                    ""if"": ""colors"",
                    ""spl"": ""plural""
                  }
                ]
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}a naval or nautical salute to a flag being hoisted or lowered""
                  ]
                ]
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""b"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}{sx|armed forces||}""
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sense"",
              {
                ""sn"": ""13"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}the quality of {d_link|timbre|timbre} in music ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""the {wi}color{/wi} and richness of the cello""
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
                ""sn"": ""14"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}a small particle of gold in a gold miner's pan after washing""
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""sense"",
              {
                ""sn"": ""15"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}a {d_link|hypothetical|hypothetical} property of {d_link|quarks|quark} that differentiates each type into three forms having a distinct role in binding quarks together""
                  ]
                ]
              }
            ]
          ]
        ]
      }
    ],
    ""et"": [
      [
        ""text"",
        ""Middle English {it}colour,{/it} borrowed from Anglo-French, going back to Latin {it}color,{/it} earlier {it}colōs{/it} \""color as a physical phenomenon, pigment, complexion, appearance,\"" probably, assuming an original meaning \""covering, outermost layer, appearance,\"" going back to {it}*ḱel-ōs,{/it} collective derivative from an Indo-European s-stem {it}*ḱel-os{/it} \""covering\"" (whence perhaps Sanskrit {it}śaras-{/it} \""skin on boiled milk, cream\"" and, from a thematic derivative, Old High German {it}hulisa{/it} \""hull of a legume\""), derivative of a verbal base {it}*ḱel-{/it} \""cover, conceal\"" {ma}{mat|conceal|conceal}{/ma}""
      ]
    ],
    ""date"": ""14th century{ds||1|a|}"",
    ""shortdef"": [
      ""a phenomenon of light (such as red, brown, pink, or gray) or visual perception that enables one to differentiate otherwise identical objects"",
      ""the aspect of the appearance of objects and light sources that may be described in terms of hue, lightness, and saturation for objects and hue, brightness, and saturation for light sources; also : a specific combination of hue, saturation, and lightness or brightness"",
      ""a color other than and as contrasted with black, white, or gray""
    ]
  },
  {
    ""meta"": {
      ""id"": ""color:2"",
      ""uuid"": ""19ba99e4-ebbe-4d09-91c1-2a771118fbd2"",
      ""sort"": ""035446600"",
      ""src"": ""collegiate"",
      ""section"": ""alpha"",
      ""stems"": [
        ""color"",
        ""colored"",
        ""colorer"",
        ""colorers"",
        ""coloring"",
        ""colors""
      ],
      ""offensive"": false
    },
    ""hom"": 2,
    ""hwi"": {
      ""hw"": ""color""
    },
    ""fl"": ""verb"",
    ""ins"": [
      {
        ""if"": ""col*ored""
      },
      {
        ""if"": ""col*or*ing""
      },
      {
        ""if"": ""col*ors""
      }
    ],
    ""def"": [
      {
        ""vd"": ""transitive verb"",
        ""sseq"": [
          [
            [
              ""sense"",
              {
                ""sn"": ""1 a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}to give color to""
                  ]
                ]
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""b"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}to change the color of (as by dyeing, staining, or painting) ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""She {wi}colors{/wi} her hair.""
                      }
                    ]
                  ]
                ]
              }
            ]
          ],
          [
            [
              ""bs"",
              {
                ""sense"": {
                  ""sn"": ""2"",
                  ""dt"": [
                    [
                      ""text"",
                      ""{bc}to change as if by dyeing or painting: such as""
                    ]
                  ]
                }
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}{sx|influence||} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""\""The lives of most of us have been {wi}colored{/wi} by politics … \"""",
                        ""aq"": {
                          ""auth"": ""Christine Weston""
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
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}{sx|misrepresent||}, {sx|distort||} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""a highly {wi}colored{/wi} version of the facts""
                      }
                    ]
                  ]
                ]
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""c"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}{sx|gloss||}, {sx|excuse||} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""{wi}color{/wi} a lie""
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
                ""sn"": ""3"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}{sx|characterize||}, {sx|label||} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""… call it progress; {wi}color{/wi} it inevitable with shades of job security"",
                        ""aq"": {
                          ""auth"": ""C. E. Price""
                        }
                      }
                    ]
                  ]
                ]
              }
            ]
          ]
        ]
      },
      {
        ""vd"": ""intransitive verb"",
        ""sseq"": [
          [
            [
              ""sense"",
              {
                ""sn"": ""1"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}to fill in a shape or picture outlined on a piece of paper using markers, crayons, colored pencils, etc. ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""His granddaughter Fernanda sat at his side, {wi}coloring{/wi} with crayons."",
                        ""aq"": {
                          ""auth"": ""Charles Montgomery""
                        }
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
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}to take on color""
                  ]
                ],
                ""sdsense"": {
                  ""sd"": ""specifically"",
                  ""dt"": [
                    [
                      ""text"",
                      ""{bc}{sx|blush||} ""
                    ],
                    [
                      ""vis"",
                      [
                        {
                          ""t"": ""She {wi}colored{/wi} at the mention of his name.""
                        }
                      ]
                    ]
                  ]
                }
              }
            ]
          ]
        ]
      }
    ],
    ""uros"": [
      {
        ""ure"": ""col*or*er"",
        ""prs"": [
          {
            ""mw"": ""ˈkə-lər-ər"",
            ""sound"": {
              ""audio"": ""color003"",
              ""ref"": ""c"",
              ""stat"": ""1""
            }
          }
        ],
        ""fl"": ""noun""
      }
    ],
    ""et"": [
      [
        ""text"",
        ""Middle English {it}colouren,{/it} borrowed from Anglo-French {it}colurer,{/it} going back to Latin {it}colōrāre,{/it} derivative of {it}color{/it} {et_link|color:1|color:1}""
      ]
    ],
    ""date"": ""14th century{ds|t|1|a|}"",
    ""shortdef"": [
      ""to give color to"",
      ""to change the color of (as by dyeing, staining, or painting)"",
      ""to change as if by dyeing or painting: such as""
    ]
  },
  {
    ""meta"": {
      ""id"": ""colour"",
      ""uuid"": ""5cdc3f1f-35f9-4059-86c5-5b8febbe8db8"",
      ""sort"": ""035450400"",
      ""src"": ""collegiate"",
      ""section"": ""alpha"",
      ""stems"": [
        ""color"",
        ""colour"",
        ""coloured"",
        ""colouring"",
        ""colours""
      ],
      ""offensive"": false
    },
    ""hwi"": {
      ""hw"": ""col*our"",
      ""prs"": [
        {
          ""mw"": ""ˈkə-lər"",
          ""sound"": {
            ""audio"": ""colour01"",
            ""ref"": ""c"",
            ""stat"": ""1""
          }
        }
      ]
    },
    ""cxs"": [
      {
        ""cxl"": ""chiefly British spelling of"",
        ""cxtis"": [
          {
            ""cxt"": ""color""
          }
        ]
      }
    ],
    ""shortdef"": []
  },
  {
    ""meta"": {
      ""id"": ""color bar"",
      ""uuid"": ""ed0ff861-9242-4957-bd50-6ce79643348d"",
      ""sort"": ""035447300"",
      ""src"": ""collegiate"",
      ""section"": ""alpha"",
      ""stems"": [
        ""break the color bar"",
        ""breaks the color bar"",
        ""breaking the color bar"",
        ""broke the color bar"",
        ""break the colour bar"",
        ""breaks the colour bar"",
        ""breaking the colour bar"",
        ""broke the colour bar"",
        ""color bar"",
        ""color bars"",
        ""colour bar"",
        ""colour bars""
      ],
      ""offensive"": false
    },
    ""hwi"": {
      ""hw"": ""color bar""
    },
    ""vrs"": [
      {
        ""vl"": ""US"",
        ""va"": ""color bar""
      },
      {
        ""vl"": ""or British"",
        ""va"": ""colour bar""
      }
    ],
    ""fl"": ""noun"",
    ""ins"": [
      {
        ""il"": ""plural"",
        ""if"": ""color bars""
      }
    ],
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
                    ""{bc}a set of societal or legal barriers that {d_link|segregates|segregate:1} people of color from white people (as by restricting social interaction or requiring separate facilities) and prevents people of color from exercising the same rights and accessing the same opportunities as white people {bc}{sx|color line||}""
                  ],
                  [
                    ""uns"",
                    [
                      [
                        [
                          ""text"",
                          "" usually used with {it}the{/it} ""
                        ],
                        [
                          ""vis"",
                          [
                            {
                              ""t"": ""As a minor leaguer, he was one of five players who {phrase}broke the color bar{/phrase} in the South Atlantic League."",
                              ""aq"": {
                                ""source"": ""{it}The (Mankato, Minnesota) Free Press{/it}""
                              }
                            }
                          ]
                        ]
                      ]
                    ]
                  ]
                ]
              }
            ]
          ]
        ]
      }
    ],
    ""date"": ""1869"",
    ""shortdef"": [
      ""a set of societal or legal barriers that segregates people of color from white people (as by restricting social interaction or requiring separate facilities) and prevents people of color from exercising the same rights and accessing the same opportunities as white people : color line— usually used with the""
    ]
  },
  {
    ""meta"": {
      ""id"": ""color-bearer"",
      ""uuid"": ""41208e0f-89ed-4fcd-b345-0eb0196fb4d4"",
      ""sort"": ""035447400"",
      ""src"": ""collegiate"",
      ""section"": ""alpha"",
      ""stems"": [
        ""color-bearer"",
        ""color-bearers""
      ],
      ""offensive"": false
    },
    ""hwi"": {
      ""hw"": ""col*or-bear*er"",
      ""prs"": [
        {
          ""mw"": ""ˈkə-lər-ˌber-ər"",
          ""sound"": {
            ""audio"": ""color_01"",
            ""ref"": ""c"",
            ""stat"": ""1""
          }
        }
      ]
    },
    ""fl"": ""noun"",
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
                    ""{bc}one who carries a color or standard especially in a military parade or drill""
                  ]
                ]
              }
            ]
          ]
        ]
      }
    ],
    ""date"": ""1677"",
    ""shortdef"": [
      ""one who carries a color or standard especially in a military parade or drill""
    ]
  },
  {
    ""meta"": {
      ""id"": ""color-blind"",
      ""uuid"": ""053629f0-1701-4376-9f21-1fb5accd342c"",
      ""sort"": ""035447500"",
      ""src"": ""collegiate"",
      ""section"": ""alpha"",
      ""stems"": [
        ""color-blind"",
        ""colorblind""
      ],
      ""offensive"": false
    },
    ""hwi"": {
      ""hw"": ""col*or-blind"",
      ""prs"": [
        {
          ""mw"": ""ˈkə-lər-ˌblīnd"",
          ""sound"": {
            ""audio"": ""color_02"",
            ""ref"": ""c"",
            ""stat"": ""1""
          }
        }
      ]
    },
    ""vrs"": [
      {
        ""vl"": ""or"",
        ""va"": ""col*or*blind""
      }
    ],
    ""fl"": ""adjective"",
    ""def"": [
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
                    ""{bc}affected with partial or total inability to distinguish one or more {d_link|chromatic|chromatic:1} colors ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""Dull colors are the rule for {wi}color-blind{/wi} animals, like elephants and hippos and rhinos."",
                        ""aq"": {
                          ""auth"": ""Terence Monmaney""
                        }
                      },
                      {
                        ""t"": ""… the examiner in Seattle who had first looked at these capsules couldn't possibly have seen the green specks: he was {wi}color-blind{/wi}."",
                        ""aq"": {
                          ""auth"": ""David Fisher""
                        }
                      },
                      {
                        ""t"": ""It really was an awful garment, that pullover. It had a queasy zigzag pattern, in many strange, unhappy colors. It looked like something knitted as a present by a {wi}colorblind{/wi} aunt."",
                        ""aq"": {
                          ""auth"": ""Terry Pratchett""
                        }
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
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}not influenced by differences of race {dx_def}see {dxt|race:1||1a}{/dx_def} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""a {wi}color-blind{/wi} policy/approach""
                      }
                    ]
                  ]
                ],
                ""sdsense"": {
                  ""sd"": ""especially"",
                  ""dt"": [
                    [
                      ""text"",
                      ""{bc}treating all people the same regardless of race ""
                    ],
                    [
                      ""vis"",
                      [
                        {
                          ""t"": ""… a country that prefers to see itself as {wi}colorblind{/wi}."",
                          ""aq"": {
                            ""auth"": ""Sidsel Overgaard""
                          }
                        }
                      ]
                    ],
                    [
                      ""snote"",
                      [
                        [
                          ""t"",
                          ""While sense 2 can be used with positive connotations of freedom from racial prejudice, it often suggests a failure or refusal to acknowledge or address the many racial {d_link|inequities|inequity} that exist in society, or to acknowledge important aspects of racial identity.""
                        ]
                      ]
                    ],
                    [
                      ""vis"",
                      [
                        {
                          ""t"": ""Equitable instruction isn't {wi}colorblind{/wi}, it is responsive to students' unique and diverse backgrounds, said Imani Goffney, assistant professor of mathematics education at the University of Maryland College of Education's Center for Mathematics Education."",
                          ""aq"": {
                            ""auth"": ""Lindsay McKenzie""
                          }
                        },
                        {
                          ""t"": ""What I learned was that white parents often refrain from speaking with their children about race, racism and racial inequality. If racial discussions do occur they are characterized by a {wi}colorblind{/wi} rhetoric."",
                          ""aq"": {
                            ""auth"": ""Megan R. Underhill""
                          }
                        }
                      ]
                    ]
                  ]
                }
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
                    ""{bc}{sx|insensitive||}, {sx|oblivious||} ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""We maintain no cash reserves, assuming we can borrow our way out of a crisis. We live as if {wi}color-blind{/wi} to risk."",
                        ""aq"": {
                          ""auth"": ""Byron Moore""
                        }
                      }
                    ]
                  ]
                ]
              }
            ]
          ]
        ]
      }
    ],
    ""date"": ""1847{ds||1||}"",
    ""shortdef"": [
      ""affected with partial or total inability to distinguish one or more chromatic colors"",
      ""not influenced by differences of race; especially : treating all people the same regardless of race"",
      ""insensitive, oblivious""
    ]
  },
  {
    ""meta"": {
      ""id"": ""color blindness"",
      ""uuid"": ""78e556c4-af5b-4515-8b7e-ada808bc746f"",
      ""sort"": ""035447550"",
      ""src"": ""collegiate"",
      ""section"": ""alpha"",
      ""stems"": [
        ""color blindness"",
        ""color blindnesses"",
        ""color-blindness"",
        ""color-blindnesses"",
        ""colorblindness"",
        ""colorblindnesses""
      ],
      ""offensive"": false
    },
    ""hwi"": {
      ""hw"": ""color blindness""
    },
    ""vrs"": [
      {
        ""vl"": ""or"",
        ""va"": ""col*or*blind*ness"",
        ""prs"": [
          {
            ""mw"": ""ˈkə-lər-ˌblīnd-nəs"",
            ""sound"": {
              ""audio"": ""colorblindness"",
              ""ref"": ""owl"",
              ""stat"": ""1""
            }
          }
        ]
      },
      {
        ""vl"": ""or less commonly"",
        ""va"": ""col*or-blind*ness""
      }
    ],
    ""fl"": ""noun"",
    ""def"": [
      {
        ""sseq"": [
          [
            [
              ""bs"",
              {
                ""sense"": {
                  ""dt"": [
                    [
                      ""text"",
                      ""{bc}the quality or state of being {d_link|color-blind|color-blind}: such as""
                    ]
                  ]
                }
              }
            ],
            [
              ""sense"",
              {
                ""sn"": ""a"",
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}partial or total inability to distinguish one or more {d_link|chromatic|chromatic:1} colors ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""In {wi}color blindness{/wi} which affects as many as 8 to 10 percent of men, a person may lose the ability to see all colors or merely the capacity to discriminate between certain hues."",
                        ""aq"": {
                          ""auth"": ""R. Lipkin""
                        }
                      },
                      {
                        ""t"": ""\""{wi}Colorblindness{/wi}\"" is almost always a misnomer. In the vast majority of cases, people can still see many colors, but they can't discriminate as many as people with regular vision."",
                        ""aq"": {
                          ""auth"": ""Amos Zeeberg""
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
                ""dt"": [
                  [
                    ""text"",
                    ""{bc}the act or practice of treating all people the same regardless of race ""
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""For [Justice John] Harlan, {wi}color blindness{/wi} forbade the state from creating invidious racial categories; for Rehnquist (and Reagan and Steele), {wi}color blindness{/wi} means racial neutrality—as if we live in a world where wishing makes prejudice go away."",
                        ""aq"": {
                          ""auth"": ""Julian Bond""
                        }
                      }
                    ]
                  ],
                  [
                    ""snote"",
                    [
                      [
                        ""t"",
                        ""While this sense can be used with positive connotations of freedom from racial prejudice, it often suggests a failure or refusal to acknowledge or address the many racial {d_link|inequities|inequity} that exist in society, or to acknowledge important aspects of racial identity.""
                      ]
                    ]
                  ],
                  [
                    ""vis"",
                    [
                      {
                        ""t"": ""Many sociologists, though, are extremely critical of {wi}colorblindness{/wi} as an ideology. They argue that as the mechanisms that reproduce racial inequality have become more covert and obscure than they were during the era of open, legal segregation, the language of explicit racism has given way to a discourse of {wi}colorblindness{/wi}."",
                        ""aq"": {
                          ""auth"": ""Adia Harvey Wingfield""
                        }
                      },
                      {
                        ""t"": ""They [critics] argue that since race is a major contributing factor in all sorts of societal outcomes, from who goes to jail to what educational opportunities a child has, to adopt {wi}color-blindness{/wi} as an ideology is to ignore important discrepancies, thereby allowing them to fester."",
                        ""aq"": {
                          ""auth"": ""Jesse Singal""
                        }
                      }
                    ]
                  ]
                ]
              }
            ]
          ]
        ]
      }
    ],
    ""et"": [
      [
        ""text"",
        ""{et_link|color-blind|color-blind} + {et_link|-ness|-ness}, after {it}blindness{/it}""
      ]
    ],
    ""date"": ""1844"",
    ""shortdef"": [
      ""the quality or state of being color-blind: such as"",
      ""partial or total inability to distinguish one or more chromatic colors"",
      ""the act or practice of treating all people the same regardless of race""
    ]
  },
  {
    ""meta"": {
      ""id"": ""color-field"",
      ""uuid"": ""994b060b-9b65-411c-a9f4-52b1fcfe65c7"",
      ""sort"": ""035448100"",
      ""src"": ""collegiate"",
      ""section"": ""alpha"",
      ""stems"": [
        ""color-field"",
        ""color-fields""
      ],
      ""offensive"": false
    },
    ""hwi"": {
      ""hw"": ""col*or-field"",
      ""prs"": [
        {
          ""mw"": ""ˈkə-lər-ˌfēld"",
          ""sound"": {
            ""audio"": ""color_03"",
            ""ref"": ""c"",
            ""stat"": ""1""
          }
        }
      ]
    },
    ""fl"": ""noun"",
    ""lbs"": [
      ""often attributive""
    ],
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
                    ""{bc}abstract painting in which color is emphasized and form and surface are correspondingly de-emphasized""
                  ]
                ]
              }
            ]
          ]
        ]
      }
    ],
    ""date"": ""1964"",
    ""shortdef"": [
      ""abstract painting in which color is emphasized and form and surface are correspondingly de-emphasized""
    ]
  },
  {
    ""meta"": {
      ""id"": ""color filter"",
      ""uuid"": ""5e70377c-0299-40b5-b3a5-b148bc089ce2"",
      ""sort"": ""035448200"",
      ""src"": ""collegiate"",
      ""section"": ""alpha"",
      ""stems"": [
        ""color filter"",
        ""color filters""
      ],
      ""offensive"": false
    },
    ""hwi"": {
      ""hw"": ""color filter""
    },
    ""fl"": ""noun"",
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
                    ""{bc}{sx|filter||2b}""
                  ]
                ]
              }
            ]
          ]
        ]
      }
    ],
    ""date"": ""1891"",
    ""shortdef"": [
      ""filter""
    ]
  },
  {
    ""meta"": {
      ""id"": ""color guard"",
      ""uuid"": ""6ffb1fec-74ca-4129-9c54-99bdc37057ab"",
      ""sort"": ""035448400"",
      ""src"": ""collegiate"",
      ""section"": ""alpha"",
      ""stems"": [
        ""color guard"",
        ""color guards""
      ],
      ""offensive"": false
    },
    ""hwi"": {
      ""hw"": ""color guard""
    },
    ""fl"": ""noun"",
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
                    ""{bc}an honor guard for the colors of an organization""
                  ]
                ]
              }
            ]
          ]
        ]
      }
    ],
    ""date"": ""1705"",
    ""shortdef"": [
      ""an honor guard for the colors of an organization""
    ]
  }
]
";

    [Benchmark]
    public void Test()
    {
        var parser = new JsonDocumentParser(new NullLogger<JsonDocumentParser>(), new MerriamWebsterConfig());

        var document = parser.ParseSearchResult(Configuration.CollegiateDictionary, text);
    }
}