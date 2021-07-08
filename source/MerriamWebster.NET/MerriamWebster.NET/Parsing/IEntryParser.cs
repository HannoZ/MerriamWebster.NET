using System.Threading.Tasks;
using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// The <see cref="IEntryParser"/> interface defines methods to retrieve data from the Merriam-Webster API.
    /// </summary>
    /// <remarks>
    /// The methods in this interface are the preferred way of interacting with the API, because the raw responses are very complex. 
    /// </remarks>
    public interface IEntryParser
    {
        /// <summary>
        /// Executes a request and returns the parsed result.
        /// </summary>
        /// <param name="api"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        Task<ResultModel> GetAndParseAsync(string api, string searchTerm);
        /// <summary>
        /// Executes a request and returns the parsed result using specific parse options.
        /// </summary>
        /// <param name="api"></param>
        /// <param name="searchTerm"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ResultModel> GetAndParseAsync(string api, string searchTerm, ParseOptions options);
    }
}