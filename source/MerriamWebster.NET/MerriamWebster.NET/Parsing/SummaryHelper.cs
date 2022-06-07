using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    internal static class SummaryHelper
    {
        public static string CreateSummary(string searchText, ICollection<Entry> results)
        {
            string summary = string.Empty;

            foreach (var entry in results.Where(e => e.ShortDefs?.Any() == true))
            {
                if (entry.Metadata.Id == searchText)
                {
                    summary += entry.Summary + " | ";
                }
                else
                {
                    summary += $"{entry.Metadata.Id}: {entry.Summary} | ";
                }
            }

            return summary.TrimEnd(' ', '|');
        }
    }
}