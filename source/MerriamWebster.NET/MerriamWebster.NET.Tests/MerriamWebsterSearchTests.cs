#nullable enable
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using Shouldly;
using System;
using System.Threading.Tasks;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Tests
{
    [TestClass]
    public class MerriamWebsterSearchTests
    {
        private AutoMocker _mocker;
        private IMerriamWebsterSearch _search;

        [TestInitialize]
        public void Initialize()
        {
            _mocker = new AutoMocker(MockBehavior.Loose);
            
            // Setup the parser to return a valid ResultModel
            _mocker.GetMock<IJsonDocumentParser>()
                .Setup(x => x.ParseSearchResult(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new ResultModel());
            
            _search = _mocker.CreateInstance<MerriamWebsterSearch>();
        }

        [TestMethod]
        public async Task Search_WithValidParameters_ReturnsResultModel()
        {
            // ARRANGE
            var expectedResponse = "[{\"meta\":{\"id\":\"test\"}}]";
            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(x => x.Search(Configuration.SpanishEnglishDictionary, "test"))
                .ReturnsAsync(expectedResponse);

            // ACT
            var result = await _search.Search("test", Configuration.SpanishEnglishDictionary);

            // ASSERT
            result.ShouldNotBeNull();
            result.Entries.ShouldNotBeNull();
        }

        [TestMethod]
        public async Task Search_WithApiKeyOverride_UsesProvidedKey()
        {
            // ARRANGE
            var expectedResponse = "[{\"meta\":{\"id\":\"test\"}}]";
            var customApiKey = "custom-key";
            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(x => x.Search(Configuration.SpanishEnglishDictionary, "test", customApiKey))
                .ReturnsAsync(expectedResponse)
                .Verifiable();

            // ACT
            var result = await _search.Search("test", Configuration.SpanishEnglishDictionary, customApiKey);

            // ASSERT
            _mocker.GetMock<IMerriamWebsterClient>().Verify();
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public async Task Search_WithoutApi_UsesConfiguredDefaultApi()
        {
            // ARRANGE
            var expectedResponse = "[{\"meta\":{\"id\":\"test\"}}]";
            var config = new MerriamWebsterConfig
            {
                ApiName = Configuration.CollegiateDictionary
            };
            _mocker.Use(config);
            var search = _mocker.CreateInstance<MerriamWebsterSearch>();

            _mocker.GetMock<IMerriamWebsterClient>()
                .Setup(x => x.Search("test"))
                .ReturnsAsync(expectedResponse)
                .Verifiable();

            // ACT
            var result = await search.Search("test");

            // ASSERT
            _mocker.GetMock<IMerriamWebsterClient>().Verify();
            result.ShouldNotBeNull();
        }
    }
}

