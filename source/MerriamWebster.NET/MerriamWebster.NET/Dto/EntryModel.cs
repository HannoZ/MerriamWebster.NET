﻿using System.Collections.Generic;
using MerriamWebster.NET.Parsing;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// The <see cref="EntryModel"/> is the representation of a search query result.
    /// </summary>
    public class EntryModel
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
        /// A collection of zero or more <see cref="Entry"/> objects. Some queries return additional results that are related to the search in some way. 
        /// </summary>
        public ICollection<Entry> AdditionalResults { get; set; } = new List<Entry>();
        /// <summary>
        /// A collection of zero or more <see cref="Entry"/> objects.<br/>
        /// An undefined entry word is derived from or related to the headword, carries a functional label and possibly other information, but does not have any definitions.
        /// </summary>
        public ICollection<Entry> UndefinedResults { get; set; } = new List<Entry>();
        /// <summary>
        /// The summary combines all non-empty summaries of the entries in the <see cref="Entries"/> property.
        /// </summary>
        public string Summary => SummaryHelper.CreateSummary(SearchText, Entries);
        /// <summary>
        /// Gets or sets the raw response in JSON format. 
        /// </summary>
        /// <remarks>The raw response can be used to get data that is not parsed by the <see cref="IEntryParser"/>.<br/>
        /// Use <see cref="JsonConvert"/> to deserialize this string into a <see cref="Response.DictionaryEntry"/>.</remarks>
        public string  RawResponse { get; set; }
        /// <summary>
        /// A collection of zero or more <see cref="Quote"/>s. 
        /// </summary>
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
    }
}
