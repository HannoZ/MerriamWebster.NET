﻿using System.Text.Json;
using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class EtymologyParserTests
    {
        [TestMethod]
        public void EtymologyParser_Parse()
        {
            string source = @" [
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
";
            var doc = JsonDocument.Parse(source);

            // ACT
            var etymology = EtymologyParser.Parse(doc.RootElement);

            etymology.Text.Text.ShouldStartWith("borrowed from");
            etymology.Note.Text.ShouldStartWith("Word apparently");
        }
    }
}