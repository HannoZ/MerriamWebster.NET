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
                .Where(type => typeof(IMarkupManipulator).IsAssignableFrom(type) && !type.IsInterface);

            MarkupManipulators = [];
            foreach (var instance in types.Select(Activator.CreateInstance))
            {
                if (instance is IMarkupManipulator markupManipulator)
                {
                    MarkupManipulators.Add(markupManipulator);
                }
            }
        }

        /// <summary>
        /// Removes markup, using all logic that is currently available.
        /// </summary>
        /// <param name="input">The input text.</param>
        /// <returns>Output text without any markup</returns>
        public static string RemoveMarkupFromString(string? input)
        {
            if (input == null)
            {
                return string.Empty;
            }

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

            input = MarkupManipulators.Aggregate(input, (current, markupRemover) =>
                markupRemover.RemoveMarkup(current));

            // always keep this one as last! 
           // input = ReplaceCrossReferenceTarget(input);

            return input;
        }

        /// <summary>
        /// Replaces MW markup with HTML markup, using all logic that is currently available.
        /// </summary>
        /// <param name="input">The input text.</param>
        /// <returns>Output text with HTML markup</returns>
        public static string ReplaceMarkupInString(string? input)
        {
            if (input == null)
            {
                return string.Empty;
            }

            input = MarkupManipulators.Aggregate(input, (current, markupRemover) => markupRemover.ReplaceMarkup(current));
            input = input.Replace("{bc}", "<b class=\"mw-bc\">:</b>");

            // remove any MW markup that has not been replaced by HTML
            input = RemoveMarkupFromString(input);

            return input;
        }


        /// <summary>
        /// Use a regular expression to manipulate the input string.
        /// </summary>
        /// <param name="input">This is the string that will be manipulated by the method.</param>
        /// <param name="regex">This is a <see cref="Regex"/> object that defines the pattern to be matched in the <paramref name="input"/> string.</param>
        /// <param name="htmlTag">This is an optional parameter that specifies the HTML tag to be used in the replacement. If this parameter is null or empty, the matched pattern will be replaced directly with the target string.</param>
        /// <param name="class">This is an optional parameter that specifies the class attribute of the HTML tag.</param>
        /// <remarks>
        /// <para>
        /// The method first finds all matches of the regex pattern in the input string. Then it replaces all occurrences of the regex pattern in the input string with a placeholder "[x]".
        /// </para>
        /// <para>
        /// For each match, it retrieves the target string (the first group in the match), finds the first occurrence of the placeholder in the input string, and replaces it with the target string enclosed in the specified HTML tag (if provided) with the specified class attribute (if provided).
        /// </para>
        /// <para>
        /// Here's a simplified example of how it works:
        /// <example>
        /// <code>
        /// string input = "Hello {name}, how are you?";
        /// Regex regex = new Regex("{(.*?)}");
        /// string htmlTag = "span";
        /// string @class = "highlight";
        ///
        /// string result = MarkupManipulator.RegexReplace(input, regex, htmlTag, @class);
        /// result: "Hello &lt;span class="highlight"&gt;name&lt;/span&gt;, how are you?"
        /// </code>
        /// </example>
        /// </para>
        /// </remarks>
        public static string RegexReplace(string input, Regex regex, string? htmlTag = null, string? @class = null)
        {
            const string placeholder = "[x]";
            var matches = regex.Matches(input);
            input = Regex.Replace(input, regex.ToString(), placeholder);

            foreach (var match in matches.Cast<Match>())
            {
                var target = match.Groups[1].ToString().TrimEnd('|');

                var index = input.IndexOf(placeholder, StringComparison.OrdinalIgnoreCase);
                var first = input[..index];
                var last = input[(index + 3)..];

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
