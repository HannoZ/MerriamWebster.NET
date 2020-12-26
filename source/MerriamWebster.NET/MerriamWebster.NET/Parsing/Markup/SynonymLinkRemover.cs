using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    public class SynonymLinkRemover : MarkupRemover, IMarkupRemover
    {
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{sx\|([^}]*)\|.*?\|.*?}");

            return RegexReplace(input, regex);
        }
    }
}