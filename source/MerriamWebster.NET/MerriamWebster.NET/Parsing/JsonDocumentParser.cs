using System;
using System.Text.Json;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Contains methods to parse the raw API response data into a <see cref="ResultModel"/>.
    /// </summary>
    public class JsonDocumentParser
    {
        /// <summary>
        /// Parses the result of an api request and returns the result using specific parse options.
        /// </summary>
        public ResultModel ParseSearchResult(string api, JsonDocument searchResult)
        {
            ArgumentNullException.ThrowIfNull(searchResult, nameof(searchResult));

            var resultModel = new ResultModel();

            // the search result is an array with one or more objects that contain the data
            var results = searchResult.RootElement.EnumerateArray();
            foreach (var result in results)
            {
                var entry = EntryFactory.CreateEntry(api);

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