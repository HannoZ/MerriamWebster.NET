namespace MerriamWebster.NET.Parsing.Markup
{
    internal class OpenCloseTagMarkupManipulator : IMarkupManipulator
    {
        private readonly string[] _tags = {"b", "it", "inf", "sup", "sc", "wi", "phrase"};

        public string RemoveMarkup(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            foreach (var tag in _tags)
            {
                input = RemoveOpenCloseTag(input, tag);
            }

            return input;
        }

        public string ReplaceMarkup(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            input = ReplaceOpenCloseTag(input, "b", "b");
            input = ReplaceOpenCloseTag(input, "it", "i");
            input = input.Replace("{phrase}", "<span class=\"mw-phrase\"><b><i>")
                .Replace("{/phrase}", "</b></i></span>");

            return input;
        }

        private static string RemoveOpenCloseTag(string input, string tag)
        {
            return input.Replace($"{{{tag}}}", "")
                .Replace($"{{/{tag}}}", "");
        }

        private static string ReplaceOpenCloseTag(string input, string tag, string replacement)
        {
            return input.Replace($"{{{tag}}}", $"<{replacement}>")
                .Replace($"{{/{tag}}}", $"</{replacement}>");
        }
    }
}