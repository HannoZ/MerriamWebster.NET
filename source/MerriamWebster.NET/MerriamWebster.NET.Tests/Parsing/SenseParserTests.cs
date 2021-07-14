using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Response.JsonConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;
using Shouldly;
using DefiningText = MerriamWebster.NET.Dto.DefiningText;
using Definition = MerriamWebster.NET.Response.Definition;
using Sense = MerriamWebster.NET.Dto.Sense;
using SenseBase = MerriamWebster.NET.Dto.SenseBase;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class SenseParserTests
    {
        [TestMethod]
        public void SenseParser_CanParse_Casa()
        {
            var defs = LoadDefinitions("casa");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Delgado()
        {
            var defs = LoadDefinitions("delgado");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Estar()
        {
            var defs = LoadDefinitions("estar");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Jiron()
        {
            var defs = LoadDefinitions("jirón");
            bool additionalInformationFound = false;

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();

                foreach (var sense in def.SenseSequence)
                {
                    if (sense.Senses.OfType<SenseBase>().Where(ss => ss.SubjectStatusLabels != null).SelectMany(ss => ss.SubjectStatusLabels).Any())
                    {
                        additionalInformationFound = true;
                    }
                }
            }

            additionalInformationFound.ShouldBeTrue();
        }

        [TestMethod]
        public void SenseParser_CanParse_House()
        {
            var defs = LoadDefinitions("house");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Pueblo()
        {
            var defs = LoadDefinitions("pueblo");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Quedar()
        {
            var defs = LoadDefinitions("quedar");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Abaco()
        {
            var defs = LoadDefinitions("collegiate_abaco");
            List<Dto.Definition> definitions = new List<Dto.Definition>();

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.NotApplicable, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();

                definitions.Add(def);
            }

            var dts = GetDefiningTexts(definitions)
               .ToList();

            dts.Count.ShouldBe(5);
            dts.OfType<RunInWord>().Count().ShouldBe(2);
        }

        [TestMethod]
        public void SenseParser_CanParse_Algiers()
        {
            var defs = LoadDefinitions("collegiate_algiers");
            List<Dto.Definition> definitions = new List<Dto.Definition>();

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.NotApplicable, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();

                definitions.Add(def);
            }

            var dts = GetDefiningTexts(definitions)
                .ToList();

            dts.Count.ShouldBe(5);
            dts.OfType<RunInWord>().Count().ShouldBe(1);
        }

        [TestMethod]
        public void SenseParser_CanParse_Abarrotado()
        {
            var defs = LoadDefinitions("abarrotado");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Abbey()
        {
            var defs = LoadDefinitions("abbey");
            List<Dto.Definition> definitions = new List<Dto.Definition>();

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();

                definitions.Add(def);
            }

            var gls = GetDefiningTexts(definitions)
                .OfType<GenderLabel>().ToList();

            gls.ShouldNotBeEmpty();
            gls.ShouldContain(g=>g.Label == "feminine");
        }

        [TestMethod]
        public void SenseParser_CanParse_Alliteration()
        {
            var defs = LoadDefinitions("collegiate_alliteration");
            List<Dto.Definition> definitions = new List<Dto.Definition>();

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.NotApplicable, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();

                definitions.Add(def);
            }

            var dts = GetDefiningTexts(definitions);
            dts.OfType<CalledAlsoNote>().ShouldNotBeNull();
        }

        [TestMethod]
        public void SenseParser_CanParse_Sierra()
        {
            var defs = LoadDefinitions("sierra");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Hilar()
        {
            var defs = LoadDefinitions("hilar");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Reboot()
        {
            var defs = LoadDefinitions("collegiate_reboot");

            List<Dto.Definition> definitions = new List<Dto.Definition>();

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.NotApplicable, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();

                definitions.Add(def);
            }

            var senses = definitions.SelectMany(d => d.SenseSequence)
                .SelectMany(ss => ss.Senses)
                .OfType<SenseBase>().ToList();
            senses.ShouldContain(s => s.SenseSpecificGrammaticalLabel != null);
            senses.ShouldContain(s => s.SenseSpecificGrammaticalLabel == null);
        }

        [TestMethod]
        public void SenseParser_CanParse_Robot()
        {
            var defs = LoadDefinitions("robot");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.En, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void SenseParser_CanParseSense_Above()
        {
            var content = TestHelper.LoadResponseFromFile("sense_above");
            var definition = JsonConvert.DeserializeObject<Definition>(content, Converter.Settings);
            var senseParser = new SenseParser(definition, Language.NotApplicable, ParseOptions.Default);

            // ACT
            var def = new Dto.Definition();
            senseParser.Parse(def);

            // ASSERT
            def.SenseSequence.Count.ShouldBe(1);
            def.SenseSequence.First().Senses.Count.ShouldBe(4);

            var dts = GetDefiningTexts(new[] {def}).ToList();
            dts.OfType<DefiningText>().ShouldAllBe(t=> !t.Text.Text.Contains("{wi}"));
            dts.OfType<VerbalIllustration>().ShouldAllBe(vis => !vis.Sentence.Text.Contains("{wi}"));
        }

        [TestMethod]
        public void SenseParser_CanParseSense_Medical_Doctor()
        {
            var content = TestHelper.LoadResponseFromFile("sense_med_doctor");
            var definition = JsonConvert.DeserializeObject<Definition>(content, Converter.Settings);
            var senseParser = new SenseParser(definition, Language.NotApplicable, ParseOptions.Default);

            // ACT
            var def = new Dto.Definition();
            senseParser.Parse(def);

            // ASSERT
            // verify that the divided sense has been parsed 
            def.SenseSequence
                .SelectMany(ss => ss.Senses)
                .Cast<Sense>()
                .Where(s => s.DividedSense != null)
                .ShouldNotBeEmpty();
        }

        [TestMethod]
        public void SenseParser_CanParseSense_Learner_Apple()
        {
            var content = TestHelper.LoadResponseFromFile("sense_learn_apple");
            var definition = JsonConvert.DeserializeObject<Definition>(content, Converter.Settings);
            var senseParser = new SenseParser(definition, Language.NotApplicable, ParseOptions.Default);

            // ACT
            var def = new Dto.Definition();
            senseParser.Parse(def);

            // ASSERT
            var dts = GetDefiningTexts(new[] {def});
            dts.OfType<SupplementalInformationNote>().ShouldNotBeEmpty();
        }

        [TestMethod]
        public void SenseParser_SynonymsNotInText()
        {
            var defs = LoadDefinitions("pueblo");
            var definitions = new List<Dto.Definition>();

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.En, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);

                definitions.Add(def);
            }

            var dts = GetDefiningTexts(definitions);
            dts.OfType<DefiningText>().ShouldAllBe(t=> !t.Text.Text.Contains(":"));
        }

        [TestMethod]
        public void SenseParser_AttributionOfQuote_Ginger()
        {
            var defs = LoadDefinitions("example_ginger");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.NotApplicable, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);

                // ASSERT
                var vis = def.SenseSequence.SelectMany(ss => ss.Senses)
                    .OfType<SenseBase>()
                    .SelectMany(s => s.DefiningTexts)
                    .OfType<VerbalIllustration>();
                vis.ShouldContain(v => v.AttributionOfQuote != null);
            }
        }

        [TestMethod]
        public void SenseParser_CanParseSense_Coll_Tedious()
        {
            var defs = LoadDefinitions("collegiate_tedious");
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.NotApplicable, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }
        [TestMethod]
        public void SenseParser_CanParseSense_Coll_Dodgson()
        {
            var defs = LoadDefinitions("collegiate_Dodgson");
            List<Dto.Definition> definitions = new List<Dto.Definition>();

            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.NotApplicable, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();

                definitions.Add(def);
            }

            var dts = GetDefiningTexts(definitions);
            dts.OfType<BiographicalNameWrap>().Count().ShouldBe(2);
        }

        [TestMethod]
        public void SenseParser_CanParse_Banadera()
        {
            var defs = LoadDefinitions("banadera");
            List<Dto.Definition> definitions = new List<Dto.Definition>();

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.Es, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();

                definitions.Add(def);
            }

            var senses = GetSenses(definitions);

            senses.Cast<Dto.Sense>().ShouldContain(s=>s.CrossReferences != null && s.CrossReferences.Any());
        }

        [TestMethod]
        public void SenseParser_CanParse_Youngster()
        {
            var defs = LoadDefinitions("youngster");
            List<Dto.Definition> definitions = new List<Dto.Definition>();

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.En, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();

                definitions.Add(def);
            }

            var dts = GetDefiningTexts(definitions);

            dts.OfType<GenderForms>().ShouldNotBeEmpty();
        }

        private static IEnumerable<Definition> LoadDefinitions(string fileName)
        {
            var content = TestHelper.LoadResponseFromFile(fileName);

            var entries = JsonConvert.DeserializeObject<DictionaryEntry[]>(content, Converter.Settings);
            return entries.SelectMany(e => e.Definitions);
        }

        private IEnumerable<SenseBase> GetSenses(IEnumerable<Dto.Definition> definitions)
            => definitions.SelectMany(d => d.SenseSequence)
                .SelectMany(ss => ss.Senses).OfType<SenseBase>();

        private IEnumerable<IDefiningText> GetDefiningTexts(IEnumerable<Dto.Definition> definitions) =>
            GetSenses(definitions)
                .SelectMany(s => s.DefiningTexts)
                .ToList();

    }
}