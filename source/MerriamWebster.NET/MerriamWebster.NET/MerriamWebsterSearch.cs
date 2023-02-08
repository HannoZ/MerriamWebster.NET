using System;
using System.Threading.Tasks;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using MerriamWebster.NET.Results.Medical;
using MerriamWebster.NET.Results.SpanishEnglish;

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
        public async Task<ResultModel<Entry>> Search(string api, string searchTerm)
        {
            var result = await _client.Search(api, searchTerm);

            return ParseApiResponse<Entry>(api, searchTerm, result);
        }

        /// <summary>
        /// Call the specified api with provided api key, to do a search for the provided search term.
        /// </summary>
        /// <param name="api">One of the Merriam-Webster apis</param>
        /// <param name="searchTerm">The search term</param>
        /// <param name="apiKey">The api key</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel<Entry>> Search(string api, string searchTerm, string apiKey)
        {
            var result = await _client.Search(api, searchTerm, apiKey);

            return ParseApiResponse<Entry>(api, searchTerm, result);
        }

        /// <summary>
        /// Call the collegiate dictionary api to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel<Entry>> SearchCollegiateDictionary(string searchTerm)
        {
            var result = await _client.Search(Configuration.CollegiateDictionary, searchTerm);

            return ParseApiResponse<Entry>(Configuration.CollegiateDictionary, searchTerm, result);
        }

        /// <summary>
        /// Call the collegiate dictionary api, with provided api key, to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="apiKey">The api key</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel<Entry>> SearchCollegiateDictionary(string searchTerm, string apiKey)
        {
            var result = await _client.Search(Configuration.CollegiateDictionary, searchTerm, apiKey);

            return ParseApiResponse<Entry>(Configuration.CollegiateDictionary, searchTerm, result);
        }

        /// <summary>
        /// Call the collegiate thesaurus api to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel<Entry>> SearchCollegiateThesaurus(string searchTerm)
        {
            var result = await _client.Search(Configuration.CollegiateThesaurus, searchTerm);

            return ParseApiResponse<Entry>(Configuration.CollegiateThesaurus, searchTerm, result);
        }

        /// <summary>
        /// Call the collegiate thesaurus api, with provided api key, to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="apiKey">The api key</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel<Entry>> SearchCollegiateThesaurus(string searchTerm, string apiKey)
        {
            var result = await _client.Search(Configuration.CollegiateThesaurus, searchTerm, apiKey);

            return ParseApiResponse<Entry>(Configuration.CollegiateThesaurus, searchTerm, result);
        }
        
        /// <summary>
        /// Call the medical dictionary api to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel<MedicalEntry>> SearchMedicalDictionary(string searchTerm)
        {
            var result = await _client.Search(Configuration.MedicalDictionary, searchTerm);

            return ParseApiResponse<MedicalEntry>(Configuration.MedicalDictionary, searchTerm, result);
        }

        /// <summary>
        /// Call the medical dictionary api, with provided api key, to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="apiKey">The api key</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel<MedicalEntry>> SearchMedicalDictionary(string searchTerm, string apiKey)
        {
            var result = await _client.Search(Configuration.MedicalDictionary, searchTerm, apiKey);

            return ParseApiResponse<MedicalEntry>(Configuration.MedicalDictionary, searchTerm, result);
        }

        /// <summary>
        /// Call the Spanish-English dictionary api to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel<SpanishEnglishEntry>> SearchSpanishEnglishDictionary(string searchTerm)
        {
            var result = await _client.Search(Configuration.SpanishEnglishDictionary, searchTerm);

            return ParseApiResponse<SpanishEnglishEntry>(Configuration.SpanishEnglishDictionary, searchTerm, result);
        }

        /// <summary>
        /// Call the Spanish-English dictionary api, with provided api key, to do a search for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="apiKey">The api key</param>
        /// <returns>The parsed result</returns>
        public async Task<ResultModel<SpanishEnglishEntry>> SearchSpanishEnglishDictionary(string searchTerm, string apiKey)
        {
            var result = await _client.Search(Configuration.SpanishEnglishDictionary, searchTerm, apiKey);

            return ParseApiResponse<SpanishEnglishEntry>(Configuration.SpanishEnglishDictionary, searchTerm, result);
        }

        /// <summary>
        /// Parse the response of an API request
        /// </summary>
        /// <param name="api">The API</param>
        /// <param name="searchTerm">The search term</param>
        /// <param name="json">The API response in JSON format</param>
        /// <returns>The parsed result</returns>
        public ResultModel<TEntry> ParseApiResponse<TEntry>(string api, string searchTerm, string json) where TEntry : EntryBase, new()
        {
            var resultModel = _parser.ParseSearchResult<TEntry>(api, json);
            resultModel.SearchText = searchTerm;

            return resultModel;
        }
    }
}