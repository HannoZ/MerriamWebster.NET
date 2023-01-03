using System;
using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for auto links (a_link).
    /// </summary>
    public partial class AutoLinkManipulator : MarkupManipulator, IMarkupManipulator
    {
#if NET7_0_OR_GREATER

        private static readonly Regex Pattern = ParsePattern();

        [GeneratedRegex("{a_link\\|([^}]*)}")]
        private static partial Regex ParsePattern();
#else
        private static readonly Regex Pattern = new Regex(@"{a_link\|([^}]*)}", RegexOptions.Compiled);
#endif

        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            return RegexReplace(input, Pattern);
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            return RegexReplace(input, Pattern, "i", "mw-link mw-auto-link");
        }

    }
}