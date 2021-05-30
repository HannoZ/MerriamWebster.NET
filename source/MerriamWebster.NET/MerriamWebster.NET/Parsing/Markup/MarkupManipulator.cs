using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// A helper class that removes markup from text. 
    /// </summary>
    /// <remarks>
    /// This class loads all implementations of <see cref="IMarkupManipulator"/> and contains some more specific implemenation.
    /// </remarks>
    public class MarkupManipulator
    {
        private static readonly List<IMarkupManipulator> MarkupManipulators;

        static MarkupManipulator()
        {
            var types = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(IMarkupManipulator).IsAssignableFrom(type) && !type.IsInterface)
                .ToList();

            MarkupManipulators = new List<IMarkupManipulator>(types.Select(type => (IMarkupManipulator)Activator.CreateInstance(type)));
        }

        /// <summary>
        /// Removes markup, using all logic that is currently available.
        /// </summary>
        /// <param name="input">The input text.</param>
        /// <returns>Output text without any markup</returns>
        public static string RemoveMarkupFromString(string input)
        {

            input = input.Replace("{bc}", "")
                .Replace("{dx_def}", "(")
                .Replace("{/dx_def}", ")")
                .Replace("{dx}", "— ")
                .Replace("{/dx}", "")
                .Replace("{dx_ety}", "— ")
                .Replace("{/dx_ety}", "")
                .Replace("{ma}", "— more at ")
                .Replace("{/ma}", "")
                .Replace("{amp}", "&")
                .Replace("{ldquo}", "\u201C")
                .Replace("{rdquo}", "\u201D")
                ;

            input = MarkupManipulators.Aggregate(input, (current, markupRemover) => markupRemover.RemoveMarkup(current));

            // always keep this one as last! 
            input = ReplaceCrossReferenceTarget(input);

            return input;
        }

        /// <summary>
        /// Replaces MW markup with HTML markup, using all logic that is currently available.
        /// </summary>
        /// <param name="input">The input text.</param>
        /// <returns>Output text with HTML markup</returns>
        public static string ReplaceMarkupInString(string input)
        {
            input = MarkupManipulators.Aggregate(input, (current, markupRemover) => markupRemover.ReplaceMarkup(current));
            input = input.Replace("{bc}", "<b class=\"mw-bc\">:</b>");

            // remove any MW markup that has not been replaced by HTML
            input = RemoveMarkupFromString(input);

            return input;
        }

        private static string ReplaceCrossReferenceTarget(string input)
        {
            var regex = new Regex(@"{dxt\|(\w*\s?\w*?):?\d?\|*\d?}");

            // because this element can also contain :, we can't use \S for any non-whitespace character
            // which is a problem if we have a word like 'worn-out'

            return RegexReplace(input, regex)
                .Replace("{dxt|", "")
                .Replace("||}", "");
        }

        internal static string RegexReplace(string input, Regex regex, string htmlTag = null, string @class = null, string style = null)
        {
            var matches = regex.Matches(input);
            input = Regex.Replace(input, regex.ToString(), "[x]");

            foreach (Match match in matches)
            {
                var target = match.Groups[1];

                var index = input.IndexOf("[x]", StringComparison.OrdinalIgnoreCase);
                string first = input.Substring(0, index);
                string last = input.Substring(index + 3);

                if (string.IsNullOrEmpty(htmlTag))
                {
                    input = first + target + last;
                }
                else
                {
                    input = $"{first}<{htmlTag} class=\"{@class}\">{target}</{htmlTag}>{last}";
                }
            }

            return input;
        }
    }
}
