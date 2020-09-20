using System.Collections.Generic;
using System.Threading.Tasks;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET
{
    public interface IMerriamWebsterClient
    {
        Task<IEnumerable<DictionaryEntry>> GetDictionaryEntry(string api, string entry);
    }
}