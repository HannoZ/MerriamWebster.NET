﻿using MerriamWebster.NET.Parsing;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using MerriamWebster.NET.Results.SpanishEnglish;
using Sense = MerriamWebster.NET.Results.Sense;
using SenseBase = MerriamWebster.NET.Results.SenseBase;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class EntryParserTests
    {
        private readonly AutoMocker _mocker = new AutoMocker(MockBehavior.Loose);

        private JsonDocumentParser _entryParser;

        [TestInitialize]
        public void Initialize()
        {
            _entryParser = _mocker.CreateInstance<JsonDocumentParser>();
        }
        
        [TestMethod]
        public async Task JsonDocumentParser_CanParse_Abarrotado()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("abarrotado");
            var doc = JsonDocument.Parse(response);
            
            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.SpanishEnglishDictionary, doc);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        //[TestMethod]
        //public async Task EntryParser_CanParse_All()
        //{
        //    string[] exclusions = { "coll_thes_above_meta.json", "sense_learn_apple.json", "sense_above.json", "sense_med_doctor.json" };
        //    var asm = Assembly.GetExecutingAssembly();
        //    var resources = asm.GetManifestResourceNames();

        //    var settings = new JsonSerializerSettings
        //    {
        //        TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
        //        TypeNameHandling = TypeNameHandling.Objects,
        //        NullValueHandling = NullValueHandling.Ignore
        //    };

        //    foreach (var resource in resources)
        //    {
        //        if (exclusions.Any(e => resource.EndsWith(e)))
        //        {
        //            continue;
        //        }

        //        await using var resourceStream = asm.GetManifestResourceStream(resource);

        //        using var reader = new StreamReader(resourceStream);
        //        string content = await reader.ReadToEndAsync();

        //        try
        //        {
        //            var data = JsonConvert.DeserializeObject<MwDictionaryEntry[]>(content, Converter.Settings);

        //            // ACT
        //            var result = _entryParser.Parse("api", data);

        //            // ASSERT
        //            result.Entries.ShouldNotBeEmpty();

        //            // verify serialization/deserialization
        //            var serialized = JsonConvert.SerializeObject(result, settings);
        //            var deserialized = JsonConvert.DeserializeObject<ResultModel>(serialized, settings);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new NotImplementedException(resource, ex);
        //        }
        //    }
        //}



        [TestMethod]
        public async Task EntryParser_CanParse_Casa()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("casa");
            var doc = JsonDocument.Parse(response);
            
            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.SpanishEnglishDictionary, doc);

            // ASSERT
            result.Entries.Count.ShouldBe(4);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Delgado()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("delgado");
            var doc = JsonDocument.Parse(response);
            
            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.SpanishEnglishDictionary, doc);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Distinto()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("distinto");
            var doc = JsonDocument.Parse(response);
            
            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.SpanishEnglishDictionary, doc);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
            result.Entries.SelectMany(e => e.Definitions)
                .SelectMany(d => d.SenseSequence)
                .SelectMany(ss => ss.Senses)
                .OfType<SenseBase>()
                .Where(s => s.Inflections != null)
                .ShouldContain(s => s.Inflections.Any(i => i.Alternate != null));
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Hilar()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("hilar");
            var doc = JsonDocument.Parse(response);

            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.SpanishEnglishDictionary, doc);

            // ASSERT
            result.Entries.Count.ShouldBe(1);
            result.Entries.Cast<SpanishEnglishEntry>().ShouldContain(e => e.Conjugations != null);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Robot()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("robot");
            var doc = JsonDocument.Parse(response);

            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.SpanishEnglishDictionary, doc);
            var entries = result.Entries.Cast<SpanishEnglishEntry>().ToList();

            // ASSERT
            entries.ShouldNotBeEmpty();
            entries.ShouldContain(e => e.Metadata.Language == Language.En);
            entries.ShouldContain(e => e.Metadata.Language == Language.Es);

            entries.ShouldContain(e => e.UndefinedRunOns.Any(uro => uro.AlternateEntry != null));
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Estar()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("estar");
            var doc = JsonDocument.Parse(response);

            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.SpanishEnglishDictionary, doc);
            var entries = result.Entries.Cast<SpanishEnglishEntry>().ToList();
            
            // ASSERT
            entries.ShouldNotBeEmpty();
            entries.ShouldContain(e => e.Conjugations != null);
            
            var senses = GetSenses(result.Entries).OfType<SenseBase>();
            senses.Where(s => s.Variants != null).ShouldNotBeNull();
        }

        //[TestMethod]
        //public void EntryParser_CanParse_House()
        //{
        //    var data = LoadData("house");

        //    // ACT
        //    var result = _entryParser.Parse("house", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Pueblo()
        //{
        //    var data = LoadData("pueblo");

        //    // ACT
        //    var result = _entryParser.Parse("pueblo", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Abeja()
        //{
        //    var data = LoadData("abeja");

        //    // ACT
        //    var result = _entryParser.Parse("abeja", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_CollegiateDict_Voluminous()
        //{
        //    var data = LoadData("coll_dict_voluminous");

        //    // ACT
        //    var result = _entryParser.Parse("voluminous", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_CollegiateThes_Umpire()
        //{
        //    var data = LoadData("coll_thes_umpire");

        //    // ACT
        //    var result = _entryParser.Parse("umpire", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}


        //[TestMethod]
        //public void EntryParser_CanParse_CollegiateThes_Above_Metadata()
        //{
        //    var data = LoadData("coll_thes_above_meta");

        //    // ACT
        //    var result = _entryParser.Parse("above", data);

        //    // ASSERT
        //    var entry = result.Entries.First();

        //    //entry.Metadata.Synonyms.ShouldNotBeEmpty();
        //    //entry.Metadata.Antonyms.ShouldNotBeEmpty();
        //}


        //[TestMethod]
        //public void EntryParser_CanParse_Medical_Doctor()
        //{
        //    var data = LoadData("med_doctor");

        //    // ACT
        //    var result = _entryParser.Parse("doctor", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}

        [TestMethod]
        public async Task EntryParser_CanParse_Learners_Apple()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("learn_apple");
            var doc = JsonDocument.Parse(response);

            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.LearnersDictionary, doc);
            
            // ASSERT
            var definingTexts = GetDefiningTexts(result.Entries);

            definingTexts.OfType<SupplementalInformationNote>().ShouldNotBeEmpty();
        }

        //[TestMethod]
        //public void EntryParser_CanParse_ElementaryDictionary_School()
        //{
        //    var data = LoadData("elem_dict_school");

        //    // ACT
        //    var result = _entryParser.Parse("school", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}


        //[TestMethod]
        //public void EntryParser_CanParse_IntermediateDictionary_Dragon()
        //{
        //    var data = LoadData("inter_dict_dragon");

        //    // ACT
        //    var result = _entryParser.Parse("dragon", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_IntermediateThesaurus_Umpire()
        //{
        //    var data = LoadData("inter_thes_umpire");

        //    // ACT
        //    var result = _entryParser.Parse("umpire", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_SchoolDictionary_Baseball()
        //{
        //    var data = LoadData("school_dict_baseball");

        //    // ACT
        //    var result = _entryParser.Parse("baseball", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}

        //[TestMethod]
        //public void EntryParser_SynonymsNotInSummary()
        //{
        //    var data = LoadData("pueblo");

        //    // ACT
        //    var result = _entryParser.Parse("pueblo", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Quedar()
        //{
        //    var data = LoadData("quedar");

        //    // ACT
        //    var result = _entryParser.Parse("quedar", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //    //result.Entries.ShouldContain(e => e.Conjugations != null);
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Sierra()
        //{
        //    var data = LoadData("sierra");

        //    // ACT
        //    var result = _entryParser.Parse("sierra", data);

        //    // ASSERT
        //    result.Entries.Count.ShouldBe(4);
        //    result.Entries.ShouldContain(e => e.CrossReferences.Any());

        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Tedious()
        //{
        //    var data = LoadData("collegiate_tedious");

        //    // ACT
        //    var result = _entryParser.Parse("tedious", data);

        //    // ASSERT
        //    result.Entries.Count.ShouldBe(1);
        //    result.Entries.First().Quotes.Count.ShouldBe(3);
        //}

        [TestMethod]
        public async Task EntryParser_CanParse_Knee()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("med_knee");
            var doc = JsonDocument.Parse(response);
            
            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.MedicalDictionary, doc);


            // ASSERT
            result.Entries.Count.ShouldBe(10);
        }

        //[TestMethod]
        //public void EntryParser_CanParse_Med_Pelvis()
        //{
        //    var data = LoadData("med_pelvis");

        //    // ACT
        //    var result = _entryParser.Parse("pelvis", data);

        //    // ASSERT
        //    result.Entries.Count.ShouldBe(7);

        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Collegiate_Pelvis()
        //{
        //    var data = LoadData("collegiate_pelvis");

        //    // ACT
        //    var result = _entryParser.Parse("pelvis", data);

        //    // ASSERT
        //    result.Entries.Count.ShouldBe(2);
        //    result.Entries.SelectMany(e => e.Definitions).ShouldContain(d => d.SubjectStatusLabels != null);
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Collegiate_Heart()
        //{
        //    var data = LoadData("collegiate_heart");

        //    // ACT
        //    var result = _entryParser.Parse("heart", data);

        //    // ASSERT
        //    result.Entries.Count.ShouldBe(10);
        //    var senses = GetSenses(result.Entries).OfType<SenseBase>();
        //    senses.ShouldContain(s => s.SubjectStatusLabels != null);

        //    var definingTexts = GetDefiningTexts(result.Entries).ToList();

        //    definingTexts.OfType<SupplementalInformationNote>().ShouldNotBeEmpty();
        //    definingTexts.OfType<CalledAlsoNote>().ShouldNotBeEmpty();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Collegiate_Reap()
        //{
        //    var data = LoadData("collegiate_reap");

        //    // ACT
        //    var result = _entryParser.Parse("reap", data);

        //    // ASSERT
        //    result.Entries.Count.ShouldBe(4);

        //}

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Feline()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_feline");
            var doc = JsonDocument.Parse(response);
            
            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.CollegiateDictionary, doc);


            // ASSERT
            result.Entries.Count.ShouldBe(3);

            GetSenses(result.Entries)
                .OfType<Sense>()
                 .ShouldContain(s => s.SenseNumber == "2"); // to verify that the "bs" element was processed correctly
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Tab()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_tab");
            var doc = JsonDocument.Parse(response);
            
            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.CollegiateDictionary, doc);
            
            // ASSERT
            result.Entries.Count.ShouldBe(7);
            result.Entries.ShouldContain(e => e.GeneralLabels != null);

            var firstDef = result.Entries.First().Definitions.First();
            firstDef.SenseSequence.Count.ShouldBe(4);
            firstDef.SenseSequence.SelectMany(ss => ss.Senses)
                .ShouldContain(s => s.IsParenthesizedSenseSequence);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Abeyance()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_abeyance");
            var doc = JsonDocument.Parse(response);
            
            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.CollegiateDictionary, doc);
            
            // ASSERT
            result.Entries.Count.ShouldBe(1);

            var defs = GetDefiningTexts(result.Entries);
            var un = defs.OfType<UsageNote>().ToList();
            un.ShouldNotBeEmpty();
            un.First().DefiningTexts.OfType<VerbalIllustration>().Count().ShouldBe(2);
        }

        //[TestMethod]
        //public void EntryParser_CanParse_Collegiate_Alliteration()
        //{
        //    var data = LoadData("collegiate_alliteration");

        //    // ACT
        //    var result = _entryParser.Parse("alliteration", data);

        //    // ASSERT
        //    result.Entries.Count.ShouldBe(1);
        //    result.Entries.First().Etymology.Note.Text.ShouldNotBeNull();
        //    result.Entries.First().Etymology.Text.Text.ShouldNotBeNull();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Collegiate_Agree()
        //{
        //    var data = LoadData("collegiate_agree");

        //    // ACT
        //    var result = _entryParser.Parse("agree", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //    result.Entries.ShouldContain(e=>e.Synonyms != null && e.Synonyms.Any());
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Collegiate_Abide()
        //{
        //    var data = LoadData("collegiate_abide");

        //    // ACT
        //    var result = _entryParser.Parse("abide", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();
        //    result.Entries.ShouldContain(e => e.Synonyms != null && e.Synonyms.Any());

        //    var dts = GetDefiningTexts(result.Entries);
        //    dts.ShouldNotBeEmpty();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Collegiate_Acadia()
        //{
        //    var data = LoadData("collegiate_Acadia");

        //    // ACT
        //    var result = _entryParser.Parse("acadia", data);

        //    // ASSERT
        //    result.Entries.First().DirectionalCrossReferences.ShouldNotBeEmpty();

        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Collegiate_Above()
        //{
        //    var data = LoadData("collegiate_above");

        //    // ACT
        //    var result = _entryParser.Parse("above", data);

        //    // ASSERT
        //    result.Entries.Count.ShouldBe(10);
        //    result.Entries.ShouldContain(e=>e.Usages != null && e.Usages.Any());

        //    var usageTexts = result.Entries.Where(e => e.Usages != null).SelectMany(e => e.Usages)
        //        .SelectMany(u=>u.ParagraphTexts)
        //        .ToList();
        //    usageTexts.OfType<DefiningText>().ShouldNotBeEmpty();
        //    usageTexts.OfType<VerbalIllustration>().ShouldNotBeEmpty();

        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Alphabet()
        //{
        //    var data = LoadData("collegiate_alphabet");

        //    // ACT
        //    var result = _entryParser.Parse("alphabet", data);

        //    // ASSERT
        //    result.Entries.Count.ShouldBe(10);
        //    result.Entries.Count(e => e.Table != null).ShouldBe(1);
        //}

        [TestMethod]
        public async Task EntryParser_CanParse_Color()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_color");
            var doc = JsonDocument.Parse(response);
            
            // ACT
            var result = _entryParser.ParseSearchResult(Configuration.CollegiateDictionary, doc);
            
            // ASSERT
            result.Entries.Count.ShouldBe(10);

            var cognates = result.Entries.Where(e => e.CognateCrossReferences != null).Select(e => e.CognateCrossReferences);
            cognates.ShouldNotBeEmpty();

            var first = result.Entries.First();
            var senses = first.Definitions.SelectMany(d => d.SenseSequence.SelectMany(ssq => ssq.Senses)).ToList();

            senses.ShouldContain(s => s.IsParenthesizedSenseSequence && s.Senses.Any());
            senses.ShouldContain(s => s.IsParenthesizedSenseSequence == false);
        }

        //[TestMethod]
        //public void EntryParser_CanParse_Bartonella()
        //{
        //    var data = LoadData("med_bartonella");

        //    // ACT
        //    var result = _entryParser.Parse("bartonella", data);

        //    // ASSERT
        //    result.Entries.First().BiographicalNote.Contents.Count.ShouldBe(4);
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Curie()
        //{
        //    var data = LoadData("med_curie");

        //    // ACT
        //    var result = _entryParser.Parse("curie", data);

        //    // ASSERT
        //    result.Entries.First().BiographicalNote.Contents.Count.ShouldBe(7);
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Tejon()
        //{
        //    var data = LoadData("tejón");

        //    // ACT
        //    var result = _entryParser.Parse("tejón", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();

        //    result.Summary.ShouldNotBeNull();
        //}

        //[TestMethod]
        //public void EntryParser_CanParse_Ver()
        //{
        //    var data = LoadData("ver");

        //    // ACT
        //    var result = _entryParser.Parse("ver", data);

        //    // ASSERT
        //    result.Entries.ShouldNotBeEmpty();

        //    result.Summary.ShouldNotBeNull();
        //}
        
        private static IEnumerable<SenseSequenceSense> GetSenses(IEnumerable<EntryBase> entries) =>
            entries.SelectMany(e => e.Definitions)
                .SelectMany(d => d.SenseSequence)
                .SelectMany(ss => ss.Senses);

        private static IEnumerable<IDefiningText> GetDefiningTexts(IEnumerable<EntryBase> entries) =>
                 GetSenses(entries)
                     .OfType<SenseBase>()
                .SelectMany(s => s.DefiningTexts).ToList();
    }
}
