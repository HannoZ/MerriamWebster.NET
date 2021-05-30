namespace MerriamWebster.NET.Parsing.Markup
{
    /// <summary>
    /// An <see cref="IMarkupManipulator"/> implementation for gloss markup.
    /// </summary>
    public class GlossManipulator : MarkupManipulator, IMarkupManipulator
    {
        /// <inheritdoc />
        public string RemoveMarkup(string input)
        {
            input = input.Replace("{gloss}", "[")
                .Replace("{/gloss}", "]");

            return input;
        }

        /// <inheritdoc />
        public string ReplaceMarkup(string input)
        {
            input = input.Replace("{gloss}", "<span class=\"mw-gloss\">[")
                .Replace("{/gloss}", "]</span>");

            return RemoveMarkup(input);
        }
    }
}