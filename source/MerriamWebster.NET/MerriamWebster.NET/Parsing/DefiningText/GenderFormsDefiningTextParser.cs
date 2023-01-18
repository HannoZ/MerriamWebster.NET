using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    public class GenderFormsDefiningTextParser : IDefiningTextParser
    {
        public IDefiningText Parse(JsonElement source)
        {
            return new GenderForms
            {
                GenderWordSpelledOut = JsonParserHelper.GetStringValue(source, "gwd"),
                GenderWordCutback = JsonParserHelper.GetStringValue(source, "gwc")
            };
        }
    }
}