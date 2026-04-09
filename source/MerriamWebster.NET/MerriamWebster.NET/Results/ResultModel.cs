using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using MerriamWebster.NET.Parsing;


namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// The result model contains the result of a search query (in the <see cref="Entries"/> collection),  plus some additional properties.
    /// </summary>
    public class ResultModel
    {
        /// <summary>
        /// Creates a new instance of <see cref="ResultModel"/>.
        /// </summary>
        public ResultModel()
        {
            SearchText = string.Empty;
        }

        /// <summary>
        /// The search text that was used in the request.
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// A collection of zero or more <see cref="Entry"/> objects. This is the main result. 
        /// </summary>
        public ICollection<Entry> Entries { get; set; } = [];

        /// <summary>
        /// The summary combines all non-empty summaries of the entries in the <see cref="Entries"/> property.
        /// </summary>
        [JsonIgnore]
        public string Summary => SummaryHelper.CreateSummary(SearchText, Entries);

        /// <summary>
        /// Gets a flattened collection of all short definitions from every entry in the result.
        /// </summary>
        /// <remarks>
        /// Use this property for simple scenarios where only the short definition text is needed.
        /// </remarks>
        [JsonIgnore]
        public IEnumerable<string> ShortDefinitions => Entries.SelectMany(e => e.ShortDefs);

        /// <summary>
        /// <i>Optional.</i> Gets or sets the raw response in JSON format. 
        /// </summary>
        /// <remarks>
        /// Raw response is only included if the <see cref="MerriamWebsterConfig.IncludeRawResponse"/> property is set to <c>true</c>.
        /// The raw response can be used for debugging purposes (e.g., to check data that is not parsed by the <see cref="JsonDocumentParser"/>). </remarks>
        public string? RawResponse { get; set; }
    }
}
