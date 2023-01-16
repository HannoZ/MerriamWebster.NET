using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.Content
{
    public interface IDefiningTextParser
    {
        IDefiningText Parse(JsonElement source);
    }
}