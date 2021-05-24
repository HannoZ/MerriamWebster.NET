using System.Collections.Generic;
using System.Threading.Tasks;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET
{
    /// <summary>
    /// The MerriamWebsterClient interface defines the methods that are available on the Merriam-Webster API.
    /// </summary>
    /// <remarks>
    /// Currently the only way to interact with the API is by sending a GET request for a specific entry.
    /// </remarks>
    public interface IMerriamWebsterClient
    {
        /// <summary>
        /// Gets a dictionary entry. 
        /// </summary>
        /// <param name="api">Specifies the API</param>
        /// <param name="entry">The dictionary entry to retrieve</param>
        /// <returns>Zero or more results.</returns>
        /// <remarks>
        /// The API returns a list of suggestions if there is no direct match.
        /// The <see cref="MerriamWebsterClient"/> implementation of this method logs these suggestions as warnings and returns an empty collection.
        /// </remarks>
        Task<IEnumerable<DictionaryEntry>> GetDictionaryEntry(string api, string entry);
    }
}