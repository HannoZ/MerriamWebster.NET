using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Response.JsonConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class SenseParserTests
    {
        [TestMethod]
        public void SenseParser_CanParse_Casa()
        {
            var defs = LoadDefinitions("casa");
            var parseOptions = new ParseOptions();

            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, parseOptions)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Delgado()
        {
            var defs = LoadDefinitions("delgado");
            var parseOptions = new ParseOptions();

            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, parseOptions)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Estar()
        {
            var defs = LoadDefinitions("estar");
            var parseOptions = new ParseOptions();

            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, parseOptions)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_House()
        {
            var defs = LoadDefinitions("house");
            var parseOptions = new ParseOptions();

            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, parseOptions)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Pueblo()
        {
            var defs = LoadDefinitions("pueblo");
            var parseOptions = new ParseOptions();

            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, parseOptions)))
            {
                _ = senseParser.Parse();
            }
        }

        [TestMethod]
        public void SenseParser_CanParse_Quedar()
        {
            var defs = LoadDefinitions("quedar");
            var parseOptions = new ParseOptions();

            foreach (var senseParser in defs.Select(definition => new SenseParser(definition, parseOptions)))
            {
                _ = senseParser.Parse();
            }
        }

        private IEnumerable<Definition> LoadDefinitions(string fileName)
        {
            var asm = Assembly.GetExecutingAssembly();
            using var resourceStream =
                asm.GetManifestResourceStream($"MerriamWebster.NET.Tests.Resources.{fileName}.json");

            using var reader = new StreamReader(resourceStream);
            string content = reader.ReadToEnd();

            var entries = JsonConvert.DeserializeObject<DictionaryEntry[]>(content, Converter.Settings);
            return entries.SelectMany(e => e.Definitions);
        }
    }
}