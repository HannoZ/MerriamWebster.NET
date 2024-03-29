﻿using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Sense = MerriamWebster.NET.Results.Sense;
using SenseBase = MerriamWebster.NET.Results.SenseBase;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class EntryParserTests
    {
        private readonly AutoMocker _mocker = new AutoMocker(MockBehavior.Loose);

        private JsonDocumentParser _parser;

        [TestInitialize]
        public void Initialize()
        {
            _parser = _mocker.CreateInstance<JsonDocumentParser>();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_All()
        {
            string[] exclusions =
            {
                "coll_thes_above_meta.json", "sense_learn_apple.json", "sense_above.json", "sense_med_doctor.json",
                "learn_apple.json"
            };
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
                    // ACT

                    // verify serialization/deserialization
                    var options = new JsonSerializerOptions()
                    {

                    };

                    if (resource.Contains("med_"))
                    {
                        var result = _parser.ParseSearchResult(Configuration.MedicalDictionary, content);
                        result.Entries.ShouldNotBeEmpty();
                        
                        var serialized = System.Text.Json.JsonSerializer.Serialize(result, options);
                        var deserialized = JsonSerializer.Deserialize<ResultModel>(serialized, options);

                    }
                    else if (resource.Contains("_"))
                    {
                        var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, content);
                        result.Entries.ShouldNotBeEmpty();
                        
                        var serialized = System.Text.Json.JsonSerializer.Serialize(result, options);
                        var deserialized = JsonSerializer.Deserialize<ResultModel>(serialized, options);
                    }
                    else
                    {
                        var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, content);
                        result.Entries.ShouldNotBeEmpty();
                        
                        var serialized = System.Text.Json.JsonSerializer.Serialize(result, options);
                        var deserialized = JsonSerializer.Deserialize<ResultModel>(serialized, options);
                    }

                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(resource, ex);
                }
            }
        }

        [TestMethod]
        public async Task JsonDocumentParser_CanParse_Abarrotado()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("abarrotado");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, response);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void EntryParser_CanHandleSearchSuggestions()
        {
            // output for 'foobar'
            string response = @"[
    ""foofaraw"",
    ""footboard"",
    ""footer"",
    ""isobar"",
    ""lobar"",
    ""foosball"",
    ""football"",
    ""footbath"",
    ""footballer"",
    ""footboards"",
    ""foolery"",
    ""footage"",
    ""footboy"",
    ""footers"",
    ""isobars"",
    ""kilobar"",
    ""Longobard"",
    ""food bank"",
    ""foodborne"",
    ""foofaraws""
]";

            // ACT
            var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, response);

            // ASSERT
        }


        [TestMethod]
        public async Task EntryParser_CanParse_Casa()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("casa");
            var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, response);
        
            // ASSERT
            result.Entries.Count.ShouldBe(4);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Delgado()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("delgado");
            var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, response);
         
            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Distinto()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("distinto");
            var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, response);

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
            var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, response);

            // ASSERT
            result.Entries.Count.ShouldBe(1);
            result.Entries.ShouldContain(e => e.Conjugations != null);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Robot()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("robot");
            var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, response);
            var entries = result.Entries;

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
            var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, response);
            var entries = result.Entries.ToList();

            // ASSERT
            entries.ShouldNotBeEmpty();
            entries.ShouldContain(e => e.Conjugations != null);

            var senses = GetSenses(result.Entries).OfType<SenseBase>();
            senses.Where(s => s.Variants != null).ShouldNotBeNull();

            entries.SelectMany(e => e.DefinedRunOns).ShouldNotBeEmpty();
        }


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
        //public async Task EntryParser_CanParse_Learners_Apple()
        //{
        //    var response = await TestHelper.LoadResponseFromFileAsync("learn_apple");
        //    var doc = JsonDocument.Parse(response);

        //     ACT
        //    var result = _entryParser.ParseSearchResult(Configuration.LearnersDictionary, doc);

        //     ASSERT
        //    var definingTexts = GetDefiningTexts(result.Entries);

        //    definingTexts.OfType<SupplementalInformationNote>().ShouldNotBeEmpty();
        //}

        [TestMethod]
        public async Task EntryParser_CanParse_Quedar()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("quedar");
            var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, response);
            var entries = result.Entries.ToList();

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
            entries.ShouldContain(e => e.Conjugations != null);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Sierra()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("sierra");
            var result = _parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, response);
            var entries = result.Entries.ToList();
            
            // ASSERT
            result.Entries.Count.ShouldBe(4);
            entries.ShouldContain(e => e.CrossReferences.Any());
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Tedious()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_tedious"); 

            // ACT
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);

            // ASSERT
            result.Entries.Count.ShouldBe(1);
            result.Entries.Cast<Entry>().First().Quotes.Count.ShouldBe(3);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Knee()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("med_knee");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.MedicalDictionary, response);

            // ASSERT
            result.Entries.Count.ShouldBe(10);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Pelvis()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_pelvis");
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);

            // ASSERT
            result.Entries.Count.ShouldBe(2);
            result.Entries.SelectMany(e => e.Definitions).ShouldContain(d => d.SubjectStatusLabels != null);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Heart()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_heart");
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);

            // ASSERT
            result.Entries.Count.ShouldBe(10);
            var senses = GetSenses(result.Entries).OfType<SenseBase>();
            senses.ShouldContain(s => s.SubjectStatusLabels != null);

            var definingTexts = GetDefiningTexts(result.Entries).ToList();

            definingTexts.OfType<SupplementalInformationNote>().ShouldNotBeEmpty();
            definingTexts.OfType<CalledAlsoNote>().ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Feline()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_feline");
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);


            // ASSERT
            result.Entries.Count.ShouldBe(3);

            var senses = GetSenses(result.Entries);

            senses.OfType<Sense>()
             .ShouldContain(s => s.SenseNumber == "2"); // to verify that the "bs" element was processed correctly
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Tab()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_tab");
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);

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

            // ACT
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);

            // ASSERT
            result.Entries.Count.ShouldBe(1);

            var defs = GetDefiningTexts(result.Entries);
            var un = defs.OfType<UsageNote>().ToList();
            un.ShouldNotBeEmpty();
            un.First().DefiningTexts.OfType<VerbalIllustration>().Count().ShouldBe(2);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Alliteration()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_alliteration");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);


            // ASSERT
            result.Entries.Count.ShouldBe(1);
            result.Entries.First().Etymology.Note.Text.ShouldNotBeNull();
            result.Entries.First().Etymology.Text.Text.ShouldNotBeNull();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Agree()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_agree");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
            result.Entries.Cast<Entry>().ShouldContain(e => e.Synonyms != null && e.Synonyms.Any());
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Abide()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_abide");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);


            // ASSERT
            result.Entries.ShouldNotBeEmpty();
            result.Entries.Cast<Entry>().ShouldContain(e => e.Synonyms != null && e.Synonyms.Any());

            var dts = GetDefiningTexts(result.Entries);
            dts.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Acadia()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_Acadia");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);

            // ASSERT
            result.Entries.Cast<Entry>().First().DirectionalCrossReferences.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Collegiate_Above()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_above");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);


            // ASSERT
            result.Entries.Count.ShouldBe(10);
            var entries = result.Entries.Cast<Entry>().ToList();
            entries.ShouldContain(e => e.Usages != null && e.Usages.Any());

            var usageTexts = entries.Where(e => e.Usages != null).SelectMany(e => e.Usages)
                .SelectMany(u => u.ParagraphTexts)
                .ToList();
            usageTexts.OfType<DefiningText>().ShouldNotBeEmpty();
            usageTexts.OfType<VerbalIllustration>().ShouldNotBeEmpty();

        }

        [TestMethod]
        public async Task EntryParser_CanParse_Alphabet()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_alphabet");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);

            // ASSERT
            result.Entries.Count.ShouldBe(10);
            result.Entries.Cast<Entry>().Count(e => e.Table != null).ShouldBe(1);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Color()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("collegiate_color");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.CollegiateDictionary, response);

            // ASSERT
            result.Entries.Count.ShouldBe(10);

            var cognates = result.Entries.Where(e => e.CognateCrossReferences != null).Select(e => e.CognateCrossReferences);
            cognates.ShouldNotBeEmpty();

            var first = result.Entries.First();
            var senses = first.Definitions.SelectMany(d => d.SenseSequence.SelectMany(ssq => ssq.Senses)).ToList();

            senses.ShouldContain(s => s.IsParenthesizedSenseSequence && s.Senses.Any());
            senses.ShouldContain(s => s.IsParenthesizedSenseSequence == false);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Bartonella()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("med_bartonella");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.MedicalDictionary, response);
            var entries = result.Entries.ToList();

            // ASSERT
            entries[0].BiographicalNote.DefiningTexts.Count.ShouldBe(4);
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Curie()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("med_curie");

            // ACT
            var result = _parser.ParseSearchResult(Configuration.MedicalDictionary, response);
            var entries = result.Entries.ToList();

            // ASSERT
            entries[0].BiographicalNote.DefiningTexts.Count.ShouldBe(7);
        }


        [TestMethod]
        public async Task EntryParser_CanParse_Ver()
        {
            var response = await TestHelper.LoadResponseFromFileAsync("ver");
           
            // ACT
            var result = _parser.ParseSearchResult(Configuration.MedicalDictionary, response);

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
            result.Summary.ShouldNotBeNull();

            var options = new JsonSerializerOptions()
            {

            };
            var serialized = System.Text.Json.JsonSerializer.Serialize(result, options);
            var d = JsonSerializer.Deserialize<ResultModel>(serialized, options);
        }

        private static IEnumerable<SenseSequenceSense> GetSenses(IEnumerable<Entry> entries) =>
            entries.SelectMany(e => e.Definitions)
                .SelectMany(d => d.SenseSequence)
                .SelectMany(ss => ss.Senses);

        private static IEnumerable<IDefiningText> GetDefiningTexts(IEnumerable<Entry> entries) =>
                 GetSenses(entries)
                     .OfType<SenseBase>()
                .SelectMany(s => s.DefiningTexts).ToList();
    }
}
