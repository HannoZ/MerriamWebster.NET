using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for etymology links (et_link).
    /// </summary>
    public partial class EtymologyLinkManipulator : MarkupManipulator, IMarkupManipulator
    {
        #if NET7_0_OR_GREATER

        private static readonly Regex Pattern = ParsePattern();

        [GeneratedRegex(@"{et_link\|([^}]*)\|[^}]*}")]
        private static partial Regex ParsePattern();
#else
        private static readonly Regex Pattern = new Regex(@"{et_link\|([^}]*)\|[^}]*}", RegexOptions.Compiled);
#endif

        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            return RegexReplace(input, Pattern);
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            return RegexReplace(input, Pattern, "i", "mw-link mw-et-link");
        }
    }
}