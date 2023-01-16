using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.Content
{
    public class TextDefiningTextParser : IDefiningTextParser
    {
        public IDefiningText Parse(JsonElement source)
        {
            string definitionText = source.GetString();
            var definingText = new DefiningText(definitionText);

            return definingText;
        }
    }
}