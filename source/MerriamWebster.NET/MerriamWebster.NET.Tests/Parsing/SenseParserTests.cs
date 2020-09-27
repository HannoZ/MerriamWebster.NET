using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Response.JsonConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Shouldly;

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
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, ParseOptions.Default)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Delgado()
        {
            var defs = LoadDefinitions("delgado");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, ParseOptions.Default)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Estar()
        {
            var defs = LoadDefinitions("estar");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, ParseOptions.Default)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_House()
        {
            var defs = LoadDefinitions("house");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, ParseOptions.Default)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Pueblo()
        {
            var defs = LoadDefinitions("pueblo");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, ParseOptions.Default)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Quedar()
        {
            var defs = LoadDefinitions("quedar");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, ParseOptions.Default)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Abarrotado()
        {
            var defs = LoadDefinitions("abarrotado");

            // ACT
            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, ParseOptions.Default)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParseSense_Above()
        {
            var content = TestHelper.LoadResponseFromFile("sense_above");
            var def = JsonConvert.DeserializeObject<Definition>(content, Converter.Settings);
            var senseParser = new SenseParser(def, ParseOptions.Default);

            // ACT
            var result = senseParser.Parse();

            // ASSERT
            result.Count.ShouldBe(4);
            result.Select(s=>s.Text).ShouldAllBe(t=> !t.Contains("{wi}"));
            result.SelectMany(s => s.Examples).ShouldAllBe(e => !e.Sentence.Contains("{wi}"));
        }

        private IEnumerable<Definition> LoadDefinitions(string fileName)
        {
            var content = TestHelper.LoadResponseFromFile(fileName);
           
            var entries = JsonConvert.DeserializeObject<DictionaryEntry[]>(content, Converter.Settings);
            return entries.SelectMany(e => e.Definitions);
        }
    }
}