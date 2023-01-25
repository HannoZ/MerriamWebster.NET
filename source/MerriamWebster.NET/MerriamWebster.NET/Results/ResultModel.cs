using System.Collections.Generic;
using System.Text.Json.Serialization;
using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// The result model contains the result of a search query (in the <see cref="Entries"/> collection),  plus some additional properties.
    /// </summary>
    public class ResultModel<T> where T : EntryBase
    {
        /// <summary>
        /// The search text that was used in the request.
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// A collection of zero or more <see cref="EntryBase"/> objects. This is the main result. 
        /// </summary>
        public ICollection<T> Entries { get; set; } = new List<T>();

        /// <summary>
        /// The summary combines all non-empty summaries of the entries in the <see cref="Entries"/> property.
        /// </summary>
        [JsonIgnore]
        public string Summary => SummaryHelper<T>.CreateSummary(SearchText, Entries);

        /// <summary>
        /// Gets or sets the raw response in JSON format. 
        /// </summary>
        /// <remarks>The raw response can be used to get data that is not parsed by the <see cref="JsonDocumentParser"/>. </remarks>
        public string RawResponse { get; set; }
    }

}
