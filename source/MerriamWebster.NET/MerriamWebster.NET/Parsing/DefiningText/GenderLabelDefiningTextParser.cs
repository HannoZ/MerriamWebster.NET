using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    public class GenderLabelDefiningTextParser : IDefiningTextParser
    {
        public IDefiningText Parse(JsonElement source)
        {
            return new GenderLabel(source.GetString());
        }
    }
}