using System.Collections.Generic;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Response;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// The <see cref="ResultModel"/> contains the result of a search query (in the <see cref="Entries"/> collection),  plus some additional properties.
    /// </summary>
    public class ResultModel
    {
        /// <summary>
        /// The search text that was used in the request.
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// A collection of zero or more <see cref="Entry"/> objects. This is the main result. 
        /// </summary>
        public ICollection<Entry> Entries { get; set; } = new List<Entry>();

        /// <summary>
        /// The summary combines all non-empty summaries of the entries in the <see cref="Entries"/> property.
        /// </summary>
        [JsonIgnore]
        public string Summary => SummaryHelper.CreateSummary(SearchText, Entries);
        /// <summary>
        /// Gets or sets the raw response in JSON format. 
        /// </summary>
        /// <remarks>The raw response can be used to get data that is not parsed by the <see cref="IEntryParser"/>.<br/>
        /// Use <see cref="JsonConvert"/> to deserialize this string into a <see cref="MwDictionaryEntry"/>.</remarks>
        public string RawResponse { get; set; }
    }

}
