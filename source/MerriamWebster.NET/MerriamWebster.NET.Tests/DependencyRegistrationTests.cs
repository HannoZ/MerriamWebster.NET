using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Net.Http;
using MerriamWebster.NET.Parsing;

namespace MerriamWebster.NET.Tests
{
    [TestClass]
    public class DependencyRegistrationTests
    {
        [TestMethod]
        public void RegisterMerriamWebster_RegistersAllRequiredServices()
        {
            // ARRANGE
            var services = new ServiceCollection();
            var config = new MerriamWebsterConfig
            {
                ApiKey = "test-key"
            };

            // ACT
            services.RegisterMerriamWebster(config);

            // ASSERT
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<IMerriamWebsterClient>().ShouldNotBeNull();
            serviceProvider.GetService<IMerriamWebsterSearch>().ShouldNotBeNull();
            serviceProvider.GetService<IJsonDocumentParser>().ShouldNotBeNull();
            serviceProvider.GetService<MerriamWebsterConfig>().ShouldBe(config);
        }

        [TestMethod]
        public void RegisterMerriamWebster_ConfiguresHttpClientCorrectly()
        {
            // ARRANGE
            var services = new ServiceCollection();
            var config = new MerriamWebsterConfig
            {
                ApiKey = "test-key"
            };

            // ACT
            services.RegisterMerriamWebster(config);

            // ASSERT
            var serviceProvider = services.BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            httpClientFactory.ShouldNotBeNull();

            var httpClient = httpClientFactory.CreateClient(typeof(IMerriamWebsterClient).Name);
            httpClient.ShouldNotBeNull();
            httpClient.BaseAddress.ShouldBe(Configuration.ApiBaseAddress);
        }

        [TestMethod]
        public void RegisterMerriamWebster_WithInvalidApiName_ThrowsArgumentException()
        {
            // ARRANGE
            var services = new ServiceCollection();
            var config = new MerriamWebsterConfig
            {
                ApiKey = "test-key",
                ApiName = "invalid-api"
            };

            // ACT & ASSERT
            Should.Throw<ArgumentException>(() => services.RegisterMerriamWebster(config));
        }
    }
}