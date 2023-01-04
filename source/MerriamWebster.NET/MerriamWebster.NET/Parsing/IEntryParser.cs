using System.Collections.Generic;
using MerriamWebster.NET.Results;

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
        /// Parses the result of an api request.
        /// </summary>
        ResultModel Parse(string searchTerm, IEnumerable<Response.MwDictionaryEntry> results);

        /// <summary>
        /// Parses the result of an api request and returns the result using specific parse options.
        /// </summary>
        ResultModel Parse(string searchTerm, IEnumerable<Response.MwDictionaryEntry> results, ParseOptions options);
    }
}