using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class SupplementalNoteDefiningTextParserTests
    {
        [TestMethod]
        public void SupplementalNoteDefiningTextParser_Parse()
        {
            string source = @"[
                                [
                                    ""t"",
                                    ""Manatees are {d_link|sirenians|sirenian} related to and resembling the {d_link|dugong|dugong} but differing most notably in the shape of the tail.""
                                ],
                    [
                     ""vis"",
                    [
                      {
                        ""t"":""An aquatic relative of the elephant"",
                        ""aq"":{""auth"":""Felicity Barringer""}
                      }
                    ]
                    ]
                            ]";

            var doc = JsonDocument.Parse(source);
            var parser = new SupplementalNoteDefiningTextParser();

            // ACT
            var result = parser.Parse(doc.RootElement) as SupplementalInformationNote;

            // ASSERT
            result.ShouldNotBe(null);
            var dts = result.DefiningTexts.ToList();
            dts.Count.ShouldBe(2); 
            dts[0].MainText.Text.ShouldStartWith("Manatees are sirenians related to");
            dts[1].ShouldBeOfType<VerbalIllustration>();
        }
    }
}