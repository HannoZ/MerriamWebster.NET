using System.Collections.Generic;
using MerriamWebster.NET.Parsing;

namespace MerriamWebster.NET.Dto
{
    public class EntryModel
    {
        public string SearchText { get; set; }
        public ICollection<Entry> Entries { get; set; } = new List<Entry>();
        public string Summary => SummaryHelper.CreateSummary(SearchText, Entries);
    }
}
