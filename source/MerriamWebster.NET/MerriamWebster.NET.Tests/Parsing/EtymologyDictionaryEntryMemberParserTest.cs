using System;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class EtymologyDictionaryEntryMemberParserTest
    {
        [TestMethod]
        public void EtymologyDictionaryEntryMemberParser_Parse()
        {
            string source = @"{""et"": [
            [
                ""text"",
                ""borrowed from New Latin {it}allīterātiōn-, allīterātiō,{/it} from Latin {it}ad-{/it} {et_link|ad-|ad-} + {it}lītera{/it} \""letter\"" + {it}-ātiōn-, -ātiō{/it} {et_link|-ation|-ation} {ma}{mat|letter:1|}{/ma}""
            ],
            [
                ""et_snote"",
                [
                    [
                        ""t"",
                        ""Word apparently coined by the Italian humanist Giovanni Pontano (ca. 1426-1503) in the dialogue {it}Actius{/it} (written 1495-99, first printed 1507).""
                    ]
                ]
            ]
        ]
}";

            var target = new Entry();
            var parser = new EtymologyDictionaryEntryMemberParser();
            var et = EntryMemberParserTestsHelper.GetJsonProperty(source, "et");

            // ACT
            parser.Parse(et, target);

            // ASSERT
            target.Etymology.ShouldNotBe(null);
        }

        [TestMethod]
        public void EtymologyDictionaryEntryMemberParser_Parse_TargetIsNull()
        {
            string source = @"{""et"": [
            [
                ""text"",
                ""borrowed from New Latin {it}allīterātiōn-, allīterātiō,{/it} from Latin {it}ad-{/it} {et_link|ad-|ad-} + {it}lītera{/it} \""letter\"" + {it}-ātiōn-, -ātiō{/it} {et_link|-ation|-ation} {ma}{mat|letter:1|}{/ma}""
            ]
        ]
}";

            var parser = new EtymologyDictionaryEntryMemberParser();
            var et = EntryMemberParserTestsHelper.GetJsonProperty(source, "et");

            // ACT / ASSERT
            Should.Throw<ArgumentNullException>(() => parser.Parse(et, null));
        }

        [TestMethod]
        public void EtymologyDictionaryEntryMemberParser_Parse_SourceIsNotEt()
        {
            string source = @"{""abc"": [
            [
                ""text"",
                ""borrowed from New Latin {it}allīterātiōn-, allīterātiō,{/it} from Latin {it}ad-{/it} {et_link|ad-|ad-} + {it}lītera{/it} \""letter\"" + {it}-ātiōn-, -ātiō{/it} {et_link|-ation|-ation} {ma}{mat|letter:1|}{/ma}""
            ]
        ]
}";

            var parser = new EtymologyDictionaryEntryMemberParser();
            var et = EntryMemberParserTestsHelper.GetJsonProperty(source, "abc");

            // ACT / ASSERT
            Should.Throw<ArgumentException>(() => parser.Parse(et, new Entry()));
        }
    }
}