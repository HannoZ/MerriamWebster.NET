using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using Moq.Protected;
using Shouldly;

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

            _client = mocker.CreateInstance<MerriamWebsterClient>();
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
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
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
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
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
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
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
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_House()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("house");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Abarrotado()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("abarrotado");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Sierra()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("sierra");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Jiron()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("jirón");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Tedious()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("collegiate_tedious");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Med_Pelvis()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("med_pelvis");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
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
            var result = await _client.GetDictionaryEntry("api", "entry");

            // ASSERT
            result.ShouldNotBeEmpty();
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
