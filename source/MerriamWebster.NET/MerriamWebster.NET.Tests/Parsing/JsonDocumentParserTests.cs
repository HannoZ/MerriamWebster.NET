#nullable enable
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using System;
using System.Text.Json;
using MerriamWebster.NET.Parsing;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class JsonDocumentParserTests
    {
        private JsonDocumentParser _parser;
        private Mock<ILogger<JsonDocumentParser>> _loggerMock;
        private MerriamWebsterConfig _config;

        [TestInitialize]
        public void Initialize()
        {
            _loggerMock = new Mock<ILogger<JsonDocumentParser>>();
            _config = new MerriamWebsterConfig { ApiKey = "test" };
            _parser = new JsonDocumentParser(_loggerMock.Object, _config);
        }

        [TestMethod]
        public void ParseSearchResult_NullApi_ThrowsArgumentNullException()
        {
            // ACT & ASSERT
            try
            {
                _parser.ParseSearchResult(null!, "{}");
                Assert.Fail("Expected ArgumentNullException");
            }
            catch (ArgumentNullException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void ParseSearchResult_EmptyApi_ThrowsArgumentException()
        {
            // ACT & ASSERT
            try
            {
                _parser.ParseSearchResult("", "{}");
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void ParseSearchResult_NullSearchResult_ThrowsArgumentNullException()
        {
            // ACT & ASSERT
            try
            {
                _parser.ParseSearchResult("api", null!);
                Assert.Fail("Expected ArgumentNullException");
            }
            catch (ArgumentNullException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void ParseSearchResult_EmptySearchResult_ThrowsArgumentException()
        {
            // ACT & ASSERT
            try
            {
                _parser.ParseSearchResult("api", "");
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void ParseSearchResult_ValidJsonArray_ReturnsResultModelWithEntries()
        {
            // ARRANGE
            var json = "[{\"meta\":{\"id\":\"test\"}}]";

            // ACT
            var result = _parser.ParseSearchResult("api", json);

            // ASSERT
            result.ShouldNotBeNull();
            result.Entries.ShouldNotBeNull();
            result.Entries.Count.ShouldBe(1);
        }

        [TestMethod]
        public void ParseSearchResult_NonArrayJson_ReturnsEmptyResultModel()
        {
            // ARRANGE
            var json = "{\"error\":\"not found\"}";

            // ACT
            var result = _parser.ParseSearchResult("api", json);

            // ASSERT
            result.ShouldNotBeNull();
            result.Entries.ShouldNotBeNull();
            result.Entries.Count.ShouldBe(0);
        }

        [TestMethod]
        public void ParseSearchResult_StringElementInArray_SkipsStringElement()
        {
            // ARRANGE
            var json = "[\"suggestion1\", \"suggestion2\"]";

            // ACT
            var result = _parser.ParseSearchResult("api", json);

            // ASSERT
            result.ShouldNotBeNull();
            result.Entries.ShouldNotBeNull();
            result.Entries.Count.ShouldBe(0);
        }

        [TestMethod]
        public void ParseSearchResult_InvalidJson_ReturnsEmptyResultModel()
        {
            // ARRANGE
            var invalidJson = "{invalid json}";

            // ACT
            var result = _parser.ParseSearchResult("api", invalidJson);

            // ASSERT
            result.ShouldNotBeNull();
            result.Entries.ShouldNotBeNull();
            result.Entries.Count.ShouldBe(0);
        }

        [TestMethod]
        public void ParseSearchResult_IncludeRawResponseTrue_IncludesRawResponse()
        {
            // ARRANGE
            _config.IncludeRawResponse = true;
            var json = "[{\"meta\":{\"id\":\"test\"}}]";

            // ACT
            var result = _parser.ParseSearchResult("api", json);

            // ASSERT
            result.RawResponse.ShouldBe(json);
        }

        [TestMethod]
        public void ParseSearchResult_IncludeRawResponseFalse_RawResponseIsNull()
        {
            // ARRANGE
            _config.IncludeRawResponse = false;
            var json = "[{\"meta\":{\"id\":\"test\"}}]";

            // ACT
            var result = _parser.ParseSearchResult("api", json);

            // ASSERT
            result.RawResponse.ShouldBeNull();
        }

        [TestMethod]
        public void ParseSearchResult_EmptyArray_ReturnsResultModelWithEmptyEntries()
        {
            // ARRANGE
            var json = "[]";

            // ACT
            var result = _parser.ParseSearchResult("api", json);

            // ASSERT
            result.ShouldNotBeNull();
            result.Entries.ShouldNotBeNull();
            result.Entries.Count.ShouldBe(0);
        }

        [TestMethod]
        public void ParseSearchResult_MixedArrayWithStringsAndObjects_ProcessesOnlyObjects()
        {
            // ARRANGE
            var json = "[\"suggestion\", {\"meta\":{\"id\":\"test\"}}]";

            // ACT
            var result = _parser.ParseSearchResult("api", json);

            // ASSERT
            result.ShouldNotBeNull();
            result.Entries.ShouldNotBeNull();
            result.Entries.Count.ShouldBe(1);
        }
    }
}