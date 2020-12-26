using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    public class EtymologyLinkRemover : MarkupRemover, IMarkupRemover
    {
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{et_link\|([^}]*)\|[^}]*}");

            return RegexReplace(input, regex);
        }
    }
}