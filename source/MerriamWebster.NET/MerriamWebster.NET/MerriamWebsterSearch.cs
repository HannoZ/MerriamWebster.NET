using System.Threading.Tasks;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using MerriamWebster.NET.Results.Medical;
using MerriamWebster.NET.Results.SpanishEnglish;

namespace MerriamWebster.NET
{
    public class MerriamWebsterSearch
    {
        private readonly IMerriamWebsterClient _client;

        public MerriamWebsterSearch(IMerriamWebsterClient client)
        {
            _client = client;
        }

        
        public async Task<ResultModel<Entry>> Search(string api, string searchTerm)
        {
            var result = await _client.Search(api, searchTerm);
            var parser = new JsonDocumentParser<Entry>();

            return parser.ParseSearchResult(api, result);
        }

        public async Task<ResultModel<Entry>> SearchCollegiateDictionary(string searchTerm)
        {
            var result = await _client.Search(Configuration.CollegiateDictionary, searchTerm);
            var parser = new JsonDocumentParser<Entry>();

            return parser.ParseSearchResult(Configuration.CollegiateDictionary, result);
        }

        public async Task<ResultModel<Entry>> SearchCollegiateThesaurus(string searchTerm)
        {
            var result = await _client.Search(Configuration.CollegiateThesaurus, searchTerm);
            var parser = new JsonDocumentParser<Entry>();

            return parser.ParseSearchResult(Configuration.CollegiateThesaurus, result);
        }
        
        public async Task<ResultModel<MedicalEntry>> SearchMedicalDictionary(string searchTerm)
        {
            var result = await _client.Search(Configuration.MedicalDictionary, searchTerm);
            var parser = new JsonDocumentParser<MedicalEntry>();

            return parser.ParseSearchResult(Configuration.MedicalDictionary, result);
        }

        public async Task<ResultModel<SpanishEnglishEntry>> SearchSpanishEnglishDictionary(string searchTerm)
        {
            var result = await _client.Search(Configuration.SpanishEnglishDictionary, searchTerm);
            var parser = new JsonDocumentParser<SpanishEnglishEntry>();

            return parser.ParseSearchResult(Configuration.SpanishEnglishDictionary, result);
        }


    }
}