using System;
using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Pronunciation = MerriamWebster.NET.Response.Pronunciation;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class VariantHelperTests
    {
        [TestMethod]
        public void VariantHelper_Parse_Happyflow()
        {
            var sources = new[]
            {
                new Response.Variant
                {
                    Cutback = "cb",
                    VariantLabel = "l",
                    SenseSpecificInflectionPluralLabel = "spl",
                    Pronunciations = new[]
                    {
                        new Pronunciation
                        {
                            Ipa = "ipa"
                        }
                    },
                    Text = "text"
                }
            };

            // ACT
            var result = VariantHelper.Parse(sources, Language.En, AudioFormat.Mp3).ToList();

            // ASSERT
            result.ShouldNotBeEmpty();
            var r0 = result[0];
            r0.Text.ShouldBe("text");
            r0.Cutback.ShouldBe("cb");
            r0.Label.ShouldBe("l");
            r0.SenseSpecificInflectionPluralLabel.Text.ShouldBe("spl");
            r0.Pronunciations.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void VariantHelper_Parse_HandleNull()
        {
            // ACT
            var result = VariantHelper.Parse(null, Language.En, AudioFormat.Mp3);

            // ASSERT
            result.ShouldBeEmpty();
        }
    }
}
