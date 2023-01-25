using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MerriamWebster.NET
{
    /// <inheritdoc cref="IMerriamWebsterClient" />
    public class MerriamWebsterClient : IMerriamWebsterClient, IDisposable
    {
        private readonly HttpClient _client;
        private readonly ILogger<MerriamWebsterClient> _logger;
        private string _apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="MerriamWebsterClient"/> class.
        /// </summary>
        /// <param name="client">The HttpClient that is used to make the requests</param>
        /// <param name="config">MerriamWebsterConfig should contain a valid API key</param>
        /// <param name="logger">An <see cref="ILogger"/> instance</param>
        /// <remarks>It's most convenient to register this class as implementation of the <see cref="IMerriamWebsterClient"/> interface and inject the interface where it's needed.
        /// This constructor should therefore not be called directly, new instances should be created by the current IoC framework.</remarks>
        public MerriamWebsterClient(HttpClient client, MerriamWebsterConfig config, ILogger<MerriamWebsterClient> logger)
        {
            _client = client;
            _logger = logger;
            _apiKey = config.ApiKey;
        }

        public async Task<string> Search(string api, string searchTerm)
        {

#if NET7_0_OR_GREATER
            ArgumentException.ThrowIfNullOrEmpty(searchTerm, nameof(searchTerm));
#else
            ArgumentNullException.ThrowIfNull(searchTerm, nameof(searchTerm));
#endif
            string urlPath = $"{api}/json/{searchTerm.ToLower()}";
            _logger.LogInformation($"Sending request - {urlPath}");
            var responseString = await _client.GetStringAsync($"{urlPath}?key={_apiKey}");

            return responseString;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected virtual void Dispose(bool disposing)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            if (disposing)
            {
                _client?.Dispose();
                _apiKey = null;
            }
        }
    }
}
