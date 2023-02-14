using System;
using System.Threading.Tasks;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET
{
    /// <summary>
    /// Helper class to get parsed results from the Merriam-Webster APIs. 
    /// </summary>
    public class MerriamWebsterSearch
    {
        private readonly IMerriamWebsterClient _client;
        private readonly JsonDocumentParser _parser;

        /// <summary>
        /// Creates a new instance. Should not be called directly, but used by dependency injection framework .
        /// </summary>
        public MerriamWebsterSearch(IMerriamWebsterClient client, JsonDocumentParser parser)
        {
            _client = client;
            _parser = parser;
        }
        
        /// <summary>
        /// Call the specified api to do a search for the provided search term.
        /// </summary>
        /// <param name="api">One of the Merriam-Webster apis</param>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> Search(string api, string searchTerm)
        {
            var result = await _client.Search(api, searchTerm);

            return ParseApiResponse(api, searchTerm, result);
        }

        /// <summary>
        /// Call the specified api with provided api key, to do a search for the provided search term.
        /// </summary>
        /// <param name="api">One of the Merriam-Webster apis</param>
        /// <param name="searchTerm">The search term</param>
        /// <param name="apiKey">The api key</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> Search(string api, string searchTerm, string apiKey)
        {
            var result = await _client.Search(api, searchTerm, apiKey);

            return ParseApiResponse(api, searchTerm, result);
        }

        /// <summary>
        /// Call the collegiate dictionary api to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> SearchCollegiateDictionary(string searchTerm)
        {
            var result = await _client.Search(Configuration.CollegiateDictionary, searchTerm);

            return ParseApiResponse(Configuration.CollegiateDictionary, searchTerm, result);
        }

        /// <summary>
        /// Call the collegiate dictionary api, with provided api key, to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="apiKey">The api key</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> SearchCollegiateDictionary(string searchTerm, string apiKey)
        {
            var result = await _client.Search(Configuration.CollegiateDictionary, searchTerm, apiKey);

            return ParseApiResponse(Configuration.CollegiateDictionary, searchTerm, result);
        }

        /// <summary>
        /// Call the collegiate thesaurus api to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> SearchCollegiateThesaurus(string searchTerm)
        {
            var result = await _client.Search(Configuration.CollegiateThesaurus, searchTerm);

            return ParseApiResponse(Configuration.CollegiateThesaurus, searchTerm, result);
        }

        /// <summary>
        /// Call the collegiate thesaurus api, with provided api key, to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="apiKey">The api key</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> SearchCollegiateThesaurus(string searchTerm, string apiKey)
        {
            var result = await _client.Search(Configuration.CollegiateThesaurus, searchTerm, apiKey);

            return ParseApiResponse(Configuration.CollegiateThesaurus, searchTerm, result);
        }
        
        /// <summary>
        /// Call the medical dictionary api to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> SearchMedicalDictionary(string searchTerm)
        {
            var result = await _client.Search(Configuration.MedicalDictionary, searchTerm);

            return ParseApiResponse(Configuration.MedicalDictionary, searchTerm, result);
        }

        /// <summary>
        /// Call the medical dictionary api, with provided api key, to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="apiKey">The api key</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> SearchMedicalDictionary(string searchTerm, string apiKey)
        {
            var result = await _client.Search(Configuration.MedicalDictionary, searchTerm, apiKey);

            return ParseApiResponse(Configuration.MedicalDictionary, searchTerm, result);
        }

        /// <summary>
        /// Call the Spanish-English dictionary api to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> SearchSpanishEnglishDictionary(string searchTerm)
        {
            var result = await _client.Search(Configuration.SpanishEnglishDictionary, searchTerm);

            return ParseApiResponse(Configuration.SpanishEnglishDictionary, searchTerm, result);
        }

        /// <summary>
        /// Call the Spanish-English dictionary api, with provided api key, to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="apiKey">The api key</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel> SearchSpanishEnglishDictionary(string searchTerm, string apiKey)
        {
            var result = await _client.Search(Configuration.SpanishEnglishDictionary, searchTerm, apiKey);

            return ParseApiResponse(Configuration.SpanishEnglishDictionary, searchTerm, result);
        }

        /// <summary>
        /// Parse the response of an API request
        /// </summary>
        /// <param name="api">The API</param>
        /// <param name="searchTerm">The search term</param>
        /// <param name="json">The API response in JSON format</param>
        /// <returns>The parsed result</returns>
        public ResultModel ParseApiResponse(string api, string searchTerm, string json)
        {
            var resultModel = _parser.ParseSearchResult(api, json);
            resultModel.SearchText = searchTerm;

            return resultModel;
        }
    }
}