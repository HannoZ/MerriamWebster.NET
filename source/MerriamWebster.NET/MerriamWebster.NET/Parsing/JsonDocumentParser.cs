using System;
using System.Text.Json;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Contains methods to parse the raw API response data into a <see cref="ResultModel{T}"/>.
    /// </summary>
    public class JsonDocumentParser<T> where T : EntryBase, new()
    {
        /// <summary>
        /// Parses the result of an api request and returns the result using specific parse options.
        /// </summary>
        public ResultModel<T> ParseSearchResult(string api, string searchResult)
        {
            ArgumentNullException.ThrowIfNull(api, nameof(api));

            var resultModel = new ResultModel<T>
            {
                RawResponse = searchResult
            };

            var json = JsonDocument.Parse(searchResult);

            // the search result is an array with one or more objects that contain the data
            var results = json.RootElement.EnumerateArray();
            foreach (var result in results)
            {
                // not an object, probably the result of an invalid search request
                if (result.ValueKind == JsonValueKind.String)
                {
                    continue;
                }

                var entry = new T();

                var obj = result.EnumerateObject();
                foreach (var prop in obj)
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

            return resultModel;
        }
    }
}