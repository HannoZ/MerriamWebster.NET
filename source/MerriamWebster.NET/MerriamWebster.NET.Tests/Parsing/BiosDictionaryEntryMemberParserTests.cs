using System.Linq;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using MerriamWebster.NET.Results.Medical;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class BiosDictionaryEntryMemberParserTests
    {
        [TestMethod]
        public void BiosDictionaryEntryMemberParser_Parse()
        {
            string source = @"{""bios"": [
            [
                [
                    ""bionw"",
                    {
                        ""biosname"": ""Bar*ton"",
                        ""bioname"": ""altname"",
                         ""prs"": [
                            {
                                ""mw"": ""ˈbär-ˌtōn"",
                                ""sound"": {
                                    ""audio"": ""barto01m""
                                }
                            }
                        ]
                    }
                ],
                [
                    ""bionw"",
                    {
                        ""biopname"": ""Alberto L.""
                    }
                ],
                [
                    ""biodate"",
                    ""(1874–1950)""
                ],
                [
                    ""biotx"",
                    ""Peruvian physician. In 1909 Barton published an article on elements found in the red blood cells of patients with Oroya fever. In this article he identified the blood parasite ({it}Bartonella bacilliformis{/it}) that is the causative agent of Oroya fever and verruga peruana. The organism is now placed in the genus {it}Bartonella,{/it} which was named after him in 1915.""
                ]
            ]
        ]}";

            var target = new MedicalEntry();
            var parser = new BiosDictionaryEntryMemberParser();
            var bios = EntryMemberParserTestsHelper.GetJsonProperty(source, "bios");

            // ACT
            parser.Parse(bios, target);
            var bio = target.BiographicalNote;

            // ASSERT
            bio.ShouldNotBe(null);
            var contents = bio.DefiningTexts.ToList();
          
            var bio1 = contents[0] as BiographicalNameWrap;
            bio1.AlternateName.ShouldBe("altname");
            bio1.FirstName.ShouldBe(null);
            bio1.Surname.ShouldBe("Bar*ton");
            bio1.Pronunciations.ShouldNotBeEmpty();

            var bio2 = contents[1] as BiographicalNameWrap;
            bio2.FirstName.ShouldBe("Alberto L.");
            bio2.AlternateName.ShouldBe(null);
            bio2.Surname.ShouldBe(null);

            var bio3 = contents[2] as BiosDate;
            bio3.Text.Text.ShouldBe("(1874\u20131950)");

            var bio4 = contents[3] as BiosText;
            bio4.Text.Text.ShouldStartWith("Peruvian physician. In 1909 Barton published an article on elements found in the red blood cells of patients with Oroya fever");

            bio.ToString().ShouldStartWith("altname, Alberto L., (1874–1950) Peruvian physician.");
        }
    }
}