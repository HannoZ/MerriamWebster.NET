using System.Text.Json;
using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results.Medical;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class BiographicalNameWrapDefiningTextParserTests
    {
        [TestMethod]
        public void BiographicalNameWrapDefiningTextParser_Parse()
        {
            string source = @" {
                      ""pname"": ""Charles Lut*widge"",
                      ""sname"": ""Dodgson"",
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
                    }";

            var doc = JsonDocument.Parse(source);
            var parser = new BiographicalNameWrapDefiningTextParser();

            // ACT
            var result = parser.Parse(doc.RootElement) as BiographicalNameWrap;

            // ASSERT
            result.ShouldNotBe(null);
            result.AlternateName.ShouldBeNull();
            result.Surname.ShouldBe("Dodgson");
            result.FirstName.ShouldBe("Charles Lut*widge");
            result.MainText.Text.ShouldBe("Charles Lut*widge Dodgson");
            result.Pronunciations.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void BiographicalNameWrapDefiningTextParser_Parse_Altname()
        {
            string source = @" {
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
                    }";

            var doc = JsonDocument.Parse(source);
            var parser = new BiographicalNameWrapDefiningTextParser();

            // ACT
            var result = parser.Parse(doc.RootElement) as BiographicalNameWrap;

            // ASSERT
            result.ShouldNotBe(null);
            result.AlternateName.ShouldBe("Lewis Car*roll");
            result.Surname.ShouldBe(null);
            result.FirstName.ShouldBe(null);
            result.MainText.Text.ShouldBe("Lewis Car*roll");
            result.Pronunciations.ShouldNotBeEmpty();
        }

    }
}