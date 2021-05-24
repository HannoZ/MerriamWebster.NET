using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Response.JsonConverters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

        /// <inheritdoc />
        public async Task<IEnumerable<DictionaryEntry>> GetDictionaryEntry(string api, string entry)
        {
            var responseString = await _client.GetStringAsync($"{api}/json/{entry?.ToLower()}?key={_apiKey}");

            try
            {
                var results = JsonConvert.DeserializeObject<DictionaryEntry[]>(responseString, Converter.Settings);
                return results;
            }
            catch
            {
                var response = JsonConvert.DeserializeObject<string[]>(responseString);
                _logger.LogWarning($"No matches found for {entry}. Suggestions: {string.Join(",", response)}");
            }

            return Enumerable.Empty<DictionaryEntry>();
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
