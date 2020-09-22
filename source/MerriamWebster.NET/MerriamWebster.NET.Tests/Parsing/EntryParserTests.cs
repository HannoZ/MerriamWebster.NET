using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Response.JsonConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json;
using Shouldly;
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

        private DictionaryEntry[] LoadData(string fileName)
        {
            var response = TestHelper.LoadResponseFromFile(fileName);
            return JsonConvert.DeserializeObject<DictionaryEntry[]>(response, Converter.Settings);
        }
    }
}
