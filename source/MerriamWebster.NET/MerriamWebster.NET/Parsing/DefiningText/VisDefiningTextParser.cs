using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    /// <summary>
    /// Parses the defining text of a verbal illustration ("vis") object.
    /// </summary>
    public class VisDefiningTextParser : IDefiningTextParser
    {
        // todo merge with VisParser

        /// <inheritdoc />
        public IDefiningText Parse(JsonElement source)
        {
            return VisParser.Parse(source);
        }
    }
}