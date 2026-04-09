using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET
{
    /// <summary>
    /// Helper class to get parsed results from the Merriam-Webster APIs. 
    /// </summary>
    public class MerriamWebsterSearch : IMerriamWebsterSearch
    {
        private readonly IMerriamWebsterClient _client;
        private readonly IJsonDocumentParser _parser;
        private readonly MerriamWebsterConfig _config;

        /// <summary>
        /// Creates a new instance. Should not be called directly, but used by dependency injection framework.
        /// </summary>
        public MerriamWebsterSearch(IMerriamWebsterClient client, IJsonDocumentParser parser, MerriamWebsterConfig config)
        {
            _client = client;
            _parser = parser;
            _config = config;
        }

        /// <summary>
        /// Search the configured API or the specified API for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="api">Optional API name; if not provided, the configured default is used.</param>
        /// <param name="apiKey">Optional API key; if not provided, uses the configured default.</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> Search(string searchTerm, string? api = null, string? apiKey = null)
        {
            string result;
            var apiName = api ?? _config.ApiName;
            if (string.IsNullOrWhiteSpace(apiName))
            {
                throw new ArgumentException("A valid API name must be provided either in the request or in configuration.", nameof(api));
            }

            // no api and no api key are provided
            if (api == null && apiKey == null)
            {  
                result = await _client.Search(searchTerm);
            }
            else 
            {  
                if (apiKey == null) // api key is not provided, but api is provided
                {
                    result = await _client.Search(apiName, searchTerm);
                }
                else // both api and api key are provided
                {
                    result = await _client.Search(apiName, searchTerm, apiKey);
                }                
            }       

            var resultModel = _parser.ParseSearchResult(apiName, result);
            resultModel.SearchText = searchTerm;

            return resultModel;
        }        
    }
}