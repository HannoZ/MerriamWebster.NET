namespace MerriamWebster.NET.Parsing.Markup
{
    public class OpenCloseTagMarkupRemover : IMarkupRemover
    {
        private readonly string[] _tags = new[] {"b", "it", "inf", "sup", "sc", "wi"};

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

        private static string RemoveOpenCloseTag(string input, string tag)
        {
            return input.Replace($"{{{tag}}}", "")
                .Replace($"{{/{tag}}}", "");
        }
    }
}