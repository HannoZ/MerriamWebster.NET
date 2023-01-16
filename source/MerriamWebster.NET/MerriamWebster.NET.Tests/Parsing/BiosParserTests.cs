using System.Linq;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Parsing.Content;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class BiosParserTests
    {
        [TestMethod]
        public void BiosParser_Parse()
        {
            //var source = new MwDictionaryEntry
            //{
            //    Bios = new[]
            //    {
            //        new[]
            //        {
            //            new BioElement[]
            //            {
            //                new BioElement{TypeOrText = "bionw"},
            //                new BioElement{BiographicalNote = new Response.BiographicalNote
            //                {
            //                    Bioname = "altname",
            //                    Biopname = "pname",
            //                    Biosname = "sname",
            //                    Prs = new []
            //                    {
            //                        new Response.Pronunciation()
            //                    }
            //                }}
            //            },
            //            new BioElement[]
            //            {
            //                new BioElement{TypeOrText = "biodate"},
            //                new BioElement{TypeOrText = "biodate_text"}
            //            },
            //            new BioElement[]
            //            {
            //                new BioElement{TypeOrText = "biotx"},
            //                new BioElement{TypeOrText = "biotx_text"}
            //            }
            //        }
            //    }
            //};
            
            //var target = new Entry();

            //var parser = new BiosParser();

            // ACT
            //parser.Parse(source, target, ParseOptions.Default);

            //// ASSERT
            //var bios = target.BiographicalNote;
            //bios.ShouldNotBe(null);
            //var content = bios.Contents.ToList();
            //var bio1 = content[0] as BiographicalNameWrap;
            //bio1.AlternateName.ShouldBe("altname");
            //bio1.FirstName.ShouldBe("pname");
            //bio1.Surname.ShouldBe("sname");
            //bio1.Pronunciations.ShouldNotBeEmpty();
            //bio1.MainText.Text.ShouldBe("altname");

            //content[1].MainText.Text.ShouldBe("biodate_text");
            //content[2].MainText.Text.ShouldBe("biotx_text");
        }
    }
}