using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using Moq.Protected;
using Shouldly;
using System;
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

        

        private static HttpResponseMessage SetupOkResponseMessage(string content)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content)
            };
        }


    }
}
