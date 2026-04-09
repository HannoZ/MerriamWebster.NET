using System.Diagnostics.CodeAnalysis;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Interface for parsing raw API response data into <see cref="ResultModel"/>.
    /// </summary>
    public interface IJsonDocumentParser
    {
        /// <summary>
        /// Parses the result of an api request and returns the result using specific parse options.
        /// </summary>
        /// <param name="api">The API identifier</param>
        /// <param name="searchResult">The raw JSON response from the API</param>
        /// <returns>The parsed result model</returns>
        ResultModel ParseSearchResult(string api, [StringSyntax(StringSyntaxAttribute.Json)] string searchResult);
    }
}
