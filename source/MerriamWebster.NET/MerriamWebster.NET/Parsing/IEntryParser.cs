using System.Threading.Tasks;
using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    public interface IEntryParser
    {
        Task<EntryModel> GetAndParseAsync(string api, string searchTerm);
        Task<EntryModel> GetAndParseAsync(string api, string searchTerm, ParseOptions options);
    }
}