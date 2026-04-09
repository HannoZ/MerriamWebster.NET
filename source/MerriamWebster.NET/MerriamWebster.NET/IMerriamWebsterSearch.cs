using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET
{
    /// <summary>
    /// Interface for getting parsed results from the Merriam-Webster APIs.
    /// </summary>
    public interface IMerriamWebsterSearch
    {
        /// <summary>
        /// Search the configured API or the specified API for the provided search term.
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <param name="api">Optional API name; if not provided, the configured default is used.</param>
        /// <param name="apiKey">Optional API key; if not provided, uses the configured default.</param>
        /// <returns>The parsed result</returns>
        Task<ResultModel> Search(string searchTerm, string? api = null, string? apiKey = null);
    }
}
