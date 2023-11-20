using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    /// <summary>
    /// Parses the defining text of a text ("text") object.
    /// </summary>
    public class TextDefiningTextParser : IDefiningTextParser
    {
        /// <inheritdoc />
        public IDefiningText Parse(JsonElement source)
        {
            string? definitionText = source.GetString();
            var definingText = new Results.DefiningText(definitionText);

            return definingText;
        }
    }
}