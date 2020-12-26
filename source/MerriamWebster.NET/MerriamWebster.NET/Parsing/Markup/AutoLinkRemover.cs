using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    public class AutoLinkRemover : MarkupRemover, IMarkupRemover
    {
        public string RemoveMarkup(string input)
        {
            var regex = new Regex(@"{a_link\|([^}]*)}");

            return RegexReplace(input, regex);
        }
    }
}