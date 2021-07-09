using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Response.JsonConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;
using Shouldly;
using Definition = MerriamWebster.NET.Response.Definition;

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
                    if (sense.Senses.Where(ss=>ss.SubjectStatusLabels != null).SelectMany(ss => ss.SubjectStatusLabels).Any())
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
            def.SenseSequence.SelectMany(ss=>ss.Senses).Select(s => s.Text).ShouldAllBe(t => !t.Contains("{wi}"));
            def.SenseSequence.SelectMany(ss => ss.Senses).SelectMany(s => s.VerbalIllustrations).ShouldAllBe(e => !e.Sentence.Contains("{wi}"));
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
                .Where(s=>s.DividedSense != null)
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

        }

        [TestMethod]
        public void SenseParser_SynonymsNotInText()
        {
            var defs = LoadDefinitions("pueblo");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.En, ParseOptions.Default)))
            {
                var def = new Dto.Definition();
                senseParser.Parse(def);

                def.SenseSequence.SelectMany(ss => ss.Senses).ShouldAllBe(s => !s.Text.Contains(":"));
            }
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
                // TODO result.Examples.First().Quote.ShouldNotBeNull();
            }
        }

        [TestMethod]
        public void SenseParser_CanParseSense_Coll_Tedious()
        {
            var defs = LoadDefinitions("collegiate_tedious");
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, Language.NotApplicable, ParseOptions.Default)))
            {var def = new Dto.Definition();
                senseParser.Parse(def);
                def.SenseSequence.ShouldNotBeEmpty();
            }
        }

        private static IEnumerable<Definition> LoadDefinitions(string fileName)
        {
            var content = TestHelper.LoadResponseFromFile(fileName);

            var entries = JsonConvert.DeserializeObject<DictionaryEntry[]>(content, Converter.Settings);
            return entries.SelectMany(e => e.Definitions);
        }
    }
}