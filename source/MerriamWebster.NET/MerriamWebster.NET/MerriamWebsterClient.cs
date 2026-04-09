using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MerriamWebster.NET
{
    /// <inheritdoc cref="IMerriamWebsterClient" />
    public class MerriamWebsterClient : IMerriamWebsterClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<MerriamWebsterClient> _logger;
        private readonly MerriamWebsterConfig _config;

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
            _config = config;
        }

        /// <inheritdoc />
        public Task<string> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(_config.ApiKey))
            {
                throw new InvalidOperationException("No api key was registered, request not possible");
            }

            return Search(_config.ApiName, searchTerm, _config.ApiKey);
        }

        /// <inheritdoc />
        public  Task<string> Search(string api, string searchTerm)
        {
            if (string.IsNullOrEmpty(_config.ApiKey))
            {
                throw new InvalidOperationException("No api key was registered, request not possible");
            }

            return Search(api, searchTerm, _config.ApiKey);
        }

        /// <inheritdoc />
        public async Task<string> Search(string api, string searchTerm, string apiKey)
        {
            ArgumentException.ThrowIfNullOrEmpty(searchTerm, nameof(searchTerm));
            ArgumentException.ThrowIfNullOrEmpty(api, nameof(api));
            ArgumentException.ThrowIfNullOrEmpty(apiKey, nameof(apiKey));

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new ArgumentException("Search term cannot be whitespace.", nameof(searchTerm));
            }
            if (string.IsNullOrWhiteSpace(api))
            {
                throw new ArgumentException("API cannot be whitespace.", nameof(api));
            }
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("API key cannot be whitespace.", nameof(apiKey));
            }

            string encodedTerm = Uri.EscapeDataString(searchTerm.ToLowerInvariant());
            string urlPath = $"{api}/json/{encodedTerm}";
            _logger.LogDebug("Sending request to Merriam-Webster API for term: {SearchTerm}", searchTerm);
            
            using var response = await _client.GetAsync($"{urlPath}?key={apiKey}");
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("API request failed with status code {StatusCode}.", response.StatusCode);
                
                // Provide specific exception types based on HTTP status code
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new ArgumentException($"Bad request. The search term or API parameter is invalid.", nameof(searchTerm));
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Unauthorized. Invalid or missing API key.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new UnauthorizedAccessException("Forbidden. The API key does not have permission for this resource.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new KeyNotFoundException($"No entry found for search term '{searchTerm}'.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    throw new InvalidOperationException("Rate limit exceeded. Please wait before making another request.");
                }
                else
                {
                    throw new HttpRequestException($"API request failed with status code {(int)response.StatusCode} ({response.StatusCode}).");
                }
            }

            return responseString;
        }
    }
}
