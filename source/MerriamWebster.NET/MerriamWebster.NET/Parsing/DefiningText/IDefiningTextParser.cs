using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    public interface IDefiningTextParser
    {
        IDefiningText Parse(JsonElement source);
    }
}