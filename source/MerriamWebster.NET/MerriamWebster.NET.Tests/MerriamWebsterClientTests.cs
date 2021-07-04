using System;
using System.IO;
using System.Linq;
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
            var result = (await _client.GetDictionaryEntry("api", "entry")).ToList();

            // ASSERT
            result.ShouldNotBeEmpty();

            // test for CalledAlsoNote specifically
            var ca = result.SelectMany(r => r.Definitions.SelectMany(d => d.SenseSequences).SelectMany(sss => sss))
                .SelectMany(ss => ss)
                .Select(s => s.Sense)
                .Where(s => s?.DefiningTexts != null)
                .SelectMany(s => s.DefiningTexts)
                .SelectMany(dtWrapper => dtWrapper)
                .Where(dt => dt.CalledAlso != null)
                .Select(dt => dt.CalledAlso);

            ca.ShouldNotBeEmpty();
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

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Dodgson()
        {


            string response = await TestHelper.LoadResponseFromFileAsync("collegiate_Dodgson");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = (await _client.GetDictionaryEntry("api", "entry")).ToList();

            // ASSERT
            result.ShouldNotBeEmpty();

            // test for BiographicalNameWrap specifically
            var bnw = result.SelectMany(r => r.Definitions.SelectMany(d => d.SenseSequences).SelectMany(sss => sss))
                .SelectMany(ss => ss)
                .Select(s => s.Sense)
                .Where(s=>s?.DefiningTexts != null)
                .SelectMany(s => s.DefiningTexts)
                .SelectMany(dtWrapper => dtWrapper)
                .Where(dt=>dt.BiographicalNameWrap != null)
                .Select(dt => dt.BiographicalNameWrap);

            bnw.ShouldNotBeEmpty();
        }

        [TestMethod]
        public async Task MerriamWebsterClient_CanDeserialize_Reap()
        {
            string response = await TestHelper.LoadResponseFromFileAsync("collegiate_reap");

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(SetupOkResponseMessage(response));

            // ACT
            var result = (await _client.GetDictionaryEntry("api", "entry")).ToList();

            // TODO parse Date {ds} token

            // TODO verify content pseq/sseq

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
