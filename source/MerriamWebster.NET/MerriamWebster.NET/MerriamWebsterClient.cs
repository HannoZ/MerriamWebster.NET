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
    public class MerriamWebsterClient : IMerriamWebsterClient, IDisposable
    {
        private readonly HttpClient _client;
        private readonly ILogger<MerriamWebsterClient> _logger;
        private string _apiKey;
        
        public MerriamWebsterClient(HttpClient client, MerriamWebsterConfig config, ILogger<MerriamWebsterClient> logger)
        {
            _client = client;
            _logger = logger;
            _apiKey = config.ApiKey;
        }

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
        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client?.Dispose();
                _apiKey = null;
            }
        }
    }
}
