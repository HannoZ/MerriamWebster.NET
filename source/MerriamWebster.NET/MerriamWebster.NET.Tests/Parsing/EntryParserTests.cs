using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Response.JsonConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task EntryParser_CanParse_Abarrotado()
        {
            var data = LoadData("abarrotado");

            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(m => m.GetDictionaryEntry(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(data);

            // ACT 
            var result = await _entryParser.GetAndParseAsync("api", "abarrotado");

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Casa()
        {
            var data = LoadData("casa");

            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(m => m.GetDictionaryEntry(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(data);

            // ACT 
            var result = await _entryParser.GetAndParseAsync("api", "casa");

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Delgado()
        {
            var data = LoadData("delgado");

            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(m => m.GetDictionaryEntry(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(data);

            // ACT 
            var result = await _entryParser.GetAndParseAsync("api", "delgado");

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Estar()
        {
            var data = LoadData("estar");

            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(m => m.GetDictionaryEntry(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(data);

            // ACT 
            var result = await _entryParser.GetAndParseAsync("api", "estar");

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_House()
        {
            var data = LoadData("house");

            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(m => m.GetDictionaryEntry(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(data);

            // ACT 
            var result = await _entryParser.GetAndParseAsync("api", "house");

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Pueblo()
        {
            var data = LoadData("pueblo");

            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(m => m.GetDictionaryEntry(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(data);

            // ACT 
            var result = await _entryParser.GetAndParseAsync("api", "pueblo");

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }


        [TestMethod]
        public async Task EntryParser_SynonymsNotInSummary()
        {
            var data = LoadData("pueblo");

            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(m => m.GetDictionaryEntry(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(data);

            // ACT 
            var result = await _entryParser.GetAndParseAsync("api", "pueblo");

            // ASSERT
            result.Entries.ShouldAllBe(e=> !e.Summary.Contains(":"));
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Quedar()
        {
            var data = LoadData("quedar");

            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(m => m.GetDictionaryEntry(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(data);

            // ACT 
            var result = await _entryParser.GetAndParseAsync("api", "quedar");

            // ASSERT
            result.Entries.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task EntryParser_CanParse_Sierra()
        {
            var data = LoadData("sierra");

            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(m => m.GetDictionaryEntry(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(data);

            // ACT 
            var result = await _entryParser.GetAndParseAsync("api", "sierra");

            // ASSERT
            result.Entries.Count.ShouldBe(2);
        }

        private static IEnumerable<DictionaryEntry> LoadData(string fileName)
        {
            var response = TestHelper.LoadResponseFromFile(fileName);
            return JsonConvert.DeserializeObject<DictionaryEntry[]>(response, Converter.Settings);
        }
    }
}
