using System;
using System.Threading.Tasks;

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
        /// Execute a search request on the specified API.
        /// </summary>
        /// <param name="api">Specifies the API</param>
        /// <param name="searchTerm">The search term to pass to the API</param>
        /// <returns>The API response as string.</returns>
        /// <remarks>
        /// The API returns a list of suggestions if there is no direct match.
        /// </remarks>
        Task<string> Search(string api, string searchTerm);

        /// <summary>
        /// Execute a search request on the specified API with provided API key.
        /// </summary>
        /// <param name="api">Specifies the API</param>
        /// <param name="searchTerm">The search term to pass to the API</param>
        /// <param name="apiKey">The API key for the <paramref name="api"/></param>
        /// <returns>The API response as string.</returns>
        /// <remarks>
        /// The API returns a list of suggestions if there is no direct match.
        /// </remarks>
        Task<string> Search(string api, string searchTerm, string apiKey);
    }
}