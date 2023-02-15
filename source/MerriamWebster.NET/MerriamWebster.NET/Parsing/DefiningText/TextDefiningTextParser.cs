using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    public class TextDefiningTextParser : IDefiningTextParser
    {
        public IDefiningText Parse(JsonElement source)
        {
            string? definitionText = source.GetString();
            var definingText = new Results.DefiningText(definitionText);

            return definingText;
        }
    }
}