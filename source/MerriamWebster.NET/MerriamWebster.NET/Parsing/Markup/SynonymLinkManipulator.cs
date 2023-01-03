using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for synonym links (sx).
    /// </summary>
    public partial class SynonymLinkManipulator : MarkupManipulator, IMarkupManipulator
    {
#if NET7_0_OR_GREATER

        private static readonly Regex Pattern = ParsePattern();

        [GeneratedRegex(@"{sx\|([^}]*)\|.*?\|.*?}")]
        private static partial Regex ParsePattern();
#else
        private static readonly Regex Pattern = new Regex(@"{sx\|([^}]*)\|.*?\|.*?}", RegexOptions.Compiled);
#endif       
        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            return RegexReplace(input, Pattern);
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            return input;
        }
    }
}