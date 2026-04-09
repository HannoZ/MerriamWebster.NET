#nullable enable
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using Moq.Protected;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MerriamWebster.NET.Tests
{
    [TestClass]
    public class MerriamWebsterClientTests
    {

        private Mock<HttpMessageHandler> _handlerMock;
        private MerriamWebsterClient _client;

        [TestInitialize]
        public void Initialize()
        {
            _handlerMock = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_handlerMock.Object)
            {
                BaseAddress = new Uri("http://www.tempuri.org")
            };

            var mocker = new AutoMocker(MockBehavior.Loose);
            mocker.Use(httpClient);

            var config = new MerriamWebsterConfig
            {
                ApiKey = "key"
            };
            mocker.Use(config);

            _client = mocker.CreateInstance<MerriamWebsterClient>();
        }
        
        [TestMethod]
        public async Task MerriamWebsterClient_DeserializeAll()
        {
            string[] exclusions = { "coll_thes_above_meta.json", "sense_learn_apple.json", "sense_above.json", "sense_med_doctor.json" };
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


                _handlerMock.Protected()
                    .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(SetupOkResponseMessage(content));
                
                try
                {
                    var result = await _client.Search("api", "entry");
                    result.ShouldNotBe(null);
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(resource, ex);
                }
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Casa()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("casa");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.Search("api", "entry");

            // ASSERT
            result.ShouldNotBe(null);
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Estar()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("estar");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.Search("api", "entry");

            // ASSERT
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Quedar()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("quedar");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.Search("api", "entry");

            // ASSERT
            result.ShouldNotBe(null);
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Delgado()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("delgado");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.Search("api", "entry");

            // ASSERT
            result.ShouldNotBe(null);
        }

        

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Med_Knee()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("med_knee");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.Search("api", "entry");

            //// ASSERT
            result.ShouldNotBe(null);
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_WithSpaces_ShouldEncodeUrl()
        {
            // ARRANGE
            string response = await TestHelper.LoadResponseFromFileAsync("casa");
            HttpRequestMessage? capturedRequest = null;

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>((request, ct) => capturedRequest = request)
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            await _client.Search("api", "hello world", "testkey");

            // ASSERT
            capturedRequest.ShouldNotBeNull();
            capturedRequest.RequestUri?.AbsoluteUri.ShouldContain("hello%20world");
            capturedRequest.RequestUri?.AbsoluteUri.ShouldNotContain("hello world");
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_WithUnicodeCharacters_ShouldEncodeUrl()
        {
            // ARRANGE
            string response = await TestHelper.LoadResponseFromFileAsync("casa");
            HttpRequestMessage? capturedRequest = null;

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>((request, ct) => capturedRequest = request)
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            await _client.Search("api", "café", "testkey");

            // ASSERT
            capturedRequest.ShouldNotBeNull();
            capturedRequest.RequestUri?.AbsoluteUri.ShouldContain("%");
            // café should be encoded as caf%C3%A9
            capturedRequest.RequestUri?.AbsoluteUri.ShouldNotContain("café");
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_WithSpecialCharacters_ShouldEncodeUrl()
        {
            // ARRANGE
            string response = await TestHelper.LoadResponseFromFileAsync("casa");
            HttpRequestMessage? capturedRequest = null;

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>((request, ct) => capturedRequest = request)
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            await _client.Search("api", "what's", "testkey");

            // ASSERT
            capturedRequest.ShouldNotBeNull();
            capturedRequest.RequestUri?.AbsoluteUri.ShouldContain("%27"); // ' encoded as %27
            capturedRequest.RequestUri?.AbsoluteUri.ShouldNotContain("what's");
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_WithUppercaseLetters_ShouldConvertToLowercase()
        {
            // ARRANGE
            string response = await TestHelper.LoadResponseFromFileAsync("casa");
            HttpRequestMessage? capturedRequest = null;

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>((request, ct) => capturedRequest = request)
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            await _client.Search("api", "HELLO", "testkey");

            // ASSERT
            capturedRequest.ShouldNotBeNull();
            var url = capturedRequest.RequestUri?.AbsoluteUri ?? string.Empty;
            url.ShouldContain("hello");
            // Verify no uppercase letters in the encoded term part (after /json/ and before ?)
            var jsonPart = url.Split(new[] { "/json/" }, StringSplitOptions.None)[1].Split('?')[0];
            jsonPart.ShouldBe("hello");
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_BadRequest_ThrowsArgumentException()
        {
            // ARRANGE
            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Bad Request")
                });

            // ACT & ASSERT
            try
            {
                await _client.Search("api", "test", "key");
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_Unauthorized_ThrowsUnauthorizedAccessException()
        {
            // ARRANGE
            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Unauthorized")
                });

            // ACT & ASSERT
            try
            {
                await _client.Search("api", "test", "key");
                Assert.Fail("Expected UnauthorizedAccessException");
            }
            catch (UnauthorizedAccessException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_Forbidden_ThrowsUnauthorizedAccessException()
        {
            // ARRANGE
            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Forbidden")
                });

            // ACT & ASSERT
            try
            {
                await _client.Search("api", "test", "key");
                Assert.Fail("Expected UnauthorizedAccessException");
            }
            catch (UnauthorizedAccessException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_NotFound_ThrowsKeyNotFoundException()
        {
            // ARRANGE
            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Not Found")
                });

            // ACT & ASSERT
            try
            {
                await _client.Search("api", "test", "key");
                Assert.Fail("Expected KeyNotFoundException");
            }
            catch (KeyNotFoundException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_TooManyRequests_ThrowsInvalidOperationException()
        {
            // ARRANGE
            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.TooManyRequests)
                {
                    Content = new StringContent("Too Many Requests")
                });

            // ACT & ASSERT
            try
            {
                await _client.Search("api", "test", "key");
                Assert.Fail("Expected InvalidOperationException");
            }
            catch (InvalidOperationException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_InternalServerError_ThrowsHttpRequestException()
        {
            // ARRANGE
            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Internal Server Error")
                });

            // ACT & ASSERT
            try
            {
                await _client.Search("api", "test", "key");
                Assert.Fail("Expected HttpRequestException");
            }
            catch (HttpRequestException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_EmptyResponse_ReturnsEmptyString()
        {
            // ARRANGE
            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("")
                });

            // ACT
            var result = await _client.Search("api", "test", "key");

            // ASSERT
            result.ShouldBeEmpty();
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_NullApi_ThrowsArgumentNullException()
        {
            // ACT & ASSERT
            try
            {
                await _client.Search(null!, "test", "key");
                Assert.Fail("Expected ArgumentNullException");
            }
            catch (ArgumentNullException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_EmptyApi_ThrowsArgumentException()
        {
            // ACT & ASSERT
            try
            {
                await _client.Search("", "test", "key");
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_WhitespaceApi_ThrowsArgumentException()
        {
            // ACT & ASSERT
            try
            {
                await _client.Search("   ", "test", "key");
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_NullSearchTerm_ThrowsArgumentNullException()
        {
            // ACT & ASSERT
            try
            {
                await _client.Search("api", null!, "key");
                Assert.Fail("Expected ArgumentNullException");
            }
            catch (ArgumentNullException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_EmptySearchTerm_ThrowsArgumentException()
        {
            // ACT & ASSERT
            try
            {
                await _client.Search("api", "", "key");
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_WhitespaceSearchTerm_ThrowsArgumentException()
        {
            // ACT & ASSERT
            try
            {
                await _client.Search("api", "   ", "key");
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_NullApiKey_ThrowsArgumentNullException()
        {
            // ACT & ASSERT
            try
            {
                await _client.Search("api", "test", null!);
                Assert.Fail("Expected ArgumentNullException");
            }
            catch (ArgumentNullException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_EmptyApiKey_ThrowsArgumentException()
        {
            // ACT & ASSERT
            try
            {
                await _client.Search("api", "test", "");
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }

        [TestMethod]
        public async Task MerriamWebsterClient_Search_WhitespaceApiKey_ThrowsArgumentException()
        {
            // ACT & ASSERT
            try
            {
                await _client.Search("api", "test", "   ");
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }

        

        private static HttpResponseMessage SetupOkResponseMessage(string content)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content)
            };
        }


    }
}
