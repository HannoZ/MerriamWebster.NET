using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Response.JsonConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MerriamWebster.NET.Dto;
using SenseBase = MerriamWebster.NET.Dto.SenseBase;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class EntryParserTests
    {
        private readonly AutoMocker _mocker = new AutoMocker(MockBehavior.Loose);

        private EntryParser _entryParser;

        [TestInitialize]
        public void Initialize()
        {
            _entryParser = _mocker.CreateInstance<EntryParser>();
        }


        [TestMethod]
        public async Task EntryParser_CanParse_All()
        {
            string[] exclusions = { "coll_thes_above_meta.json", "sense_learn_apple.json", "sense_above.json", "sense_med_doctor.json" };
            var asm = Assembly.GetExecutingAssembly();
            var resources = asm.GetManifestResourceNames();
            foreach (var resource in resources)
            {
                if (exclusions.Any(e => resource.EndsWith(e)))
                {
                    continue;
                }

                await using var resourceStream = asm.GetManifestResourceStream(resource);

                using var reader = new StreamReader(resourceStream);
                string content = await reader.ReadToEndAsync();

                try
                {
                    var data = JsonConvert.DeserializeObject<DictionaryEntry[]>(content, Converter.Settings);

                    // ACT
                    var result = _entryParser.Parse("api", data);

                    // ASSERT
                    result.Entries.ShouldNotBeEmpty();

                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(resource, ex);
                }
            }
        }

        [TestMethod]
        public void EntryParser_CanParse_Abarrotado()
        {
            var data = LoadData("abarrotado");

            // ACT
            var result = _entryParser.Parse("abarrotado", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_Casa()
        {
            var data = LoadData("casa");

            // ACT
            var result = _entryParser.Parse("casa", data);

            // ASSERT
            result.Entries.Count.ShouldBe(4);
        }

        [TestMethod]
        public void EntryParser_CanParse_Delgado()
        {
            var data = LoadData("delgado");

            // ACT 
            var result = _entryParser.Parse("delgado", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_Distinto()
        {
            var data = LoadData("distinto");

            // ACT 
            var result = _entryParser.Parse("distinto", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
            result.Entries.SelectMany(e => e.Definitions)
                .SelectMany(d => d.SenseSequence)
                .SelectMany(ss => ss.Senses)
                .Where(s => s.Inflections != null)
                .ShouldContain(s => s.Inflections.Any(i => i.Alternate != null));
        }

        [TestMethod]
        public void EntryParser_CanParse_Hilar()
        {
            var data = LoadData("hilar");

            // ACT
            var result = _entryParser.Parse("hilar", data);

            // ASSERT
            result.Entries.Count.ShouldBe(1);
            result.Entries.ShouldContain(e => e.Conjugations != null);
        }

        [TestMethod]
        public void EntryParser_CanParse_Robot()
        {
            var data = LoadData("robot");

            var result = _entryParser.Parse("robot", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();

            result.Entries.ShouldContain(e => e.Metadata.Language == Language.En);
            result.Entries.ShouldContain(e => e.Metadata.Language == Language.Es);

            result.Entries.ShouldContain(e => e.UndefinedRunOns.Any(uro => uro.AlternateEntry != null));
        }

        [TestMethod]
        public void EntryParser_CanParse_Estar()
        {
            var data = LoadData("estar");

            // ACT
            var result = _entryParser.Parse("estar", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
            // TODO
            //result.AdditionalResults.ShouldNotBeEmpty();
            //result.Entries.ShouldContain(e=>e.Conjugations != null);
        }

        [TestMethod]
        public void EntryParser_CanParse_House()
        {
            var data = LoadData("house");

            // ACT
            var result = _entryParser.Parse("house", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_Pueblo()
        {
            var data = LoadData("pueblo");

            // ACT
            var result = _entryParser.Parse("pueblo", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_Abeja()
        {
            var data = LoadData("abeja");

            // ACT
            var result = _entryParser.Parse("abeja", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_CollegiateDict_Voluminous()
        {
            var data = LoadData("coll_dict_voluminous");

            // ACT
            var result = _entryParser.Parse("voluminous", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_CollegiateThes_Umpire()
        {
            var data = LoadData("coll_thes_umpire");

            // ACT
            var result = _entryParser.Parse("umpire", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }


        [TestMethod]
        public void EntryParser_CanParse_CollegiateThes_Above_Metadata()
        {
            var data = LoadData("coll_thes_above_meta");

            // ACT
            var result = _entryParser.Parse("above", data);

            // ASSERT
            var entry = result.Entries.First();
            // TODO
            //entry.Synonyms.ShouldNotBeEmpty();
            //entry.Antonyms.ShouldNotBeEmpty();
        }



        [TestMethod]
        public void EntryParser_CanParse_Medical_Doctor()
        {
            var data = LoadData("med_doctor");

            // ACT
            var result = _entryParser.Parse("doctor", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_Learners_Apple()
        {
            var data = LoadData("learn_apple");
            // ACT
            var result = _entryParser.Parse("apple", data);

            // ASSERT
            var definingTexts = GetDefiningTexts(result.Entries);

            definingTexts.OfType<SupplementalInformationNote>().ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_ElementaryDictionary_School()
        {
            var data = LoadData("elem_dict_school");

            // ACT
            var result = _entryParser.Parse("school", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }


        [TestMethod]
        public void EntryParser_CanParse_IntermediateDictionary_Dragon()
        {
            var data = LoadData("inter_dict_dragon");

            // ACT
            var result = _entryParser.Parse("dragon", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_IntermediateThesaurus_Umpire()
        {
            var data = LoadData("inter_thes_umpire");

            // ACT
            var result = _entryParser.Parse("umpire", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_SchoolDictionary_Baseball()
        {
            var data = LoadData("school_dict_baseball");

            // ACT
            var result = _entryParser.Parse("baseball", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_SynonymsNotInSummary()
        {
            var data = LoadData("pueblo");

            // ACT
            var result = _entryParser.Parse("pueblo", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_Quedar()
        {
            var data = LoadData("quedar");

            // ACT
            var result = _entryParser.Parse("quedar", data);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
            result.Entries.ShouldContain(e => e.Conjugations != null);
        }

        [TestMethod]
        public void EntryParser_CanParse_Sierra()
        {
            var data = LoadData("sierra");

            // ACT
            var result = _entryParser.Parse("sierra", data);

            // ASSERT
            result.Entries.Count.ShouldBe(4);
            result.Entries.ShouldContain(e => e.CrossReferences.Any());

        }

        [TestMethod]
        public void EntryParser_CanParse_Tedious()
        {
            var data = LoadData("collegiate_tedious");

            // ACT
            var result = _entryParser.Parse("tedious", data);

            // ASSERT
            result.Entries.Count.ShouldBe(1);
            result.Entries.First().Quotes.Count.ShouldBe(3);
        }

        [TestMethod]
        public void EntryParser_CanParse_Knee()
        {
            var data = LoadData("med_knee");

            // ACT
            var result = _entryParser.Parse("knee", data);

            // ASSERT
            result.Entries.Count.ShouldBe(10);
        }

        [TestMethod]
        public void EntryParser_CanParse_Med_Pelvis()
        {
            var data = LoadData("med_pelvis");

            // ACT
            var result = _entryParser.Parse("pelvis", data);

            // ASSERT
            result.Entries.Count.ShouldBe(7);

        }

        [TestMethod]
        public void EntryParser_CanParse_Collegiate_Pelvis()
        {
            var data = LoadData("collegiate_pelvis");

            // ACT
            var result = _entryParser.Parse("pelvis", data);

            // ASSERT
            result.Entries.Count.ShouldBe(2);
            result.Entries.SelectMany(e => e.Definitions).ShouldContain(d => d.SubjectStatusLabels != null);
        }

        [TestMethod]
        public void EntryParser_CanParse_Collegiate_Heart()
        {
            var data = LoadData("collegiate_heart");

            // ACT
            var result = _entryParser.Parse("heart", data);

            // ASSERT
            result.Entries.Count.ShouldBe(10);
            var senses = GetSenses(result.Entries);
            senses.ShouldContain(s => s.SubjectStatusLabels != null);

            var definingTexts = GetDefiningTexts(result.Entries).ToList();

            definingTexts.OfType<SupplementalInformationNote>().ShouldNotBeEmpty();
            definingTexts.OfType<CalledAlsoNote>().ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_Collegiate_Reap()
        {
            var data = LoadData("collegiate_reap");

            // ACT
            var result = _entryParser.Parse("reap", data);

            // ASSERT
            result.Entries.Count.ShouldBe(4);

        }

        [TestMethod]
        public void EntryParser_CanParse_Collegiate_Feline()
        {
            var data = LoadData("collegiate_feline");

            // ACT
            var result = _entryParser.Parse("feline", data);

            // ASSERT
            result.Entries.Count.ShouldBe(3);

            GetSenses(result.Entries)
                .OfType<Dto.Sense>()
                 .ShouldContain(s => s.SenseNumber == "2"); // to verify that the "bs" element was processed correctly
        }

        [TestMethod]
        public void EntryParser_CanParse_Collegiate_Tab()
        {
            var data = LoadData("collegiate_tab");

            // ACT
            var result = _entryParser.Parse("tab", data);

            // ASSERT
            result.Entries.Count.ShouldBe(7);
            result.Entries.ShouldContain(e => e.GeneralLabels != null);

            var firstDef = result.Entries.First().Definitions.First();
            firstDef.SenseSequence.Count.ShouldBe(4);
            firstDef.SenseSequence.First().ParenthesizedSenseSequence.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanParse_Collegiate_Abeyance()
        {
            var data = LoadData("collegiate_abeyance");

            // ACT
            var result = _entryParser.Parse("abeyance", data);

            // ASSERT
            result.Entries.Count.ShouldBe(1);

            var defs = GetDefiningTexts(result.Entries);
            var un = defs.OfType<UsageNote>().ToList();
            un.ShouldNotBeEmpty();
            un.First().VerbalIllustrations.Count.ShouldBe(2);
        }

        [TestMethod]
        public void EntryParser_CanParse_Collegiate_Alliteration()
        {
            var data = LoadData("collegiate_alliteration");

            // ACT
            var result = _entryParser.Parse("alliteration", data);

            // ASSERT
            result.Entries.Count.ShouldBe(1);
            result.Entries.First().Etymology.Note.Text.ShouldNotBeNull();
            result.Entries.First().Etymology.Text.Text.ShouldNotBeNull();
        }

        private static IEnumerable<Response.DictionaryEntry> LoadData(string fileName)
        {
            var response = TestHelper.LoadResponseFromFile(fileName);
            return JsonConvert.DeserializeObject<Response.DictionaryEntry[]>(response, Converter.Settings);
        }

        private IEnumerable<SenseBase> GetSenses(IEnumerable<Entry> entries) =>
            entries.SelectMany(e => e.Definitions)
                .SelectMany(d => d.SenseSequence)
                .SelectMany(ss => ss.Senses);

        private IEnumerable<IDefiningText> GetDefiningTexts(IEnumerable<Entry> entries) =>
                 GetSenses(entries)
                .SelectMany(s => s.DefiningTexts).ToList();
    }
}
