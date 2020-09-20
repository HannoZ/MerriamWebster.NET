using System.Collections.Generic;
using MerriamWebster.NET.Parsing;

namespace MerriamWebster.NET.Dto
{
    public class EntryModel
    {
        public string SearchText { get; set; }
        public ICollection<SearchResult> Results { get; set; } = new List<SearchResult>();
        public string Summary => SummaryHelper.CreateSummary(SearchText, Results);
    }
}
