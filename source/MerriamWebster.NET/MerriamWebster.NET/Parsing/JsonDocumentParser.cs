using System;
using System.Text.Json;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using Microsoft.Extensions.Logging;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Contains methods to parse the raw API response data into a <see cref="ResultModel{T}"/>.
    /// </summary>
    public class JsonDocumentParser 
    {
        private readonly ILogger<JsonDocumentParser> _logger;
        
        public JsonDocumentParser(ILogger<JsonDocumentParser> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Parses the result of an api request and returns the result using specific parse options.
        /// </summary>
        public ResultModel<T> ParseSearchResult<T>(string api, string searchResult)
            where T : EntryBase, new()
        {
            ArgumentNullException.ThrowIfNull(api, nameof(api));

            var resultModel = new ResultModel<T>
            {
                RawResponse = searchResult
            };

            try
            {
                var json = JsonDocument.Parse(searchResult);

                // the search result is an array with one or more objects that contain the data
                foreach (var result in json.RootElement.EnumerateArray())
                {
                    // not an object, probably the result of an invalid search request
                    if (result.ValueKind == JsonValueKind.String)
                    {
                        continue;
                    }

                    var entry = new T();

                    foreach (var prop in result.EnumerateObject())
                    {
                        // check if there is a specific parser for the current property
                        var parser = DictionaryEntryMemberParserFactory.GetDictionaryEntryMemberParser(api, prop.Name);
                        parser?.Parse(prop, entry);
                    }

                    // handle some specific properties
                    var entryParser = new JsonEntryParser();
                    entryParser.Parse(result, entry);

                    resultModel.Entries.Add(entry);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Parsing the response failed.");
            }

            return resultModel;
        }
    }
}