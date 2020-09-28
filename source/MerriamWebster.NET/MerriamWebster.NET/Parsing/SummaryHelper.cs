using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    public static class SummaryHelper
    {
        public static string CreateSummary(string searchText, ICollection<Entry> results)
        {
            string summary = string.Empty;
            foreach (var searchResult in results.Where(r=> !string.IsNullOrWhiteSpace(r.Summary)))
            {
                if (searchResult.Text == searchText)
                {
                    summary += searchResult.Summary + " | ";
                }
                else
                {
                    summary += $"{searchResult.Text}: {searchResult.Summary} | ";
                }
            }

            return summary.TrimEnd(' ', '|');
        }
    }
}