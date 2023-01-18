using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    public class VisDefiningTextParser : IDefiningTextParser
    {
        // todo merge with VisParser

        public IDefiningText Parse(JsonElement source)
        {
            return VisParser.Parse(source);
        }
    }
}