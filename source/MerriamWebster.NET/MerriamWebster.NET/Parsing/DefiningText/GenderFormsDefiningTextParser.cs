using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    /// <summary>
    /// <i>Spanish-English only.</i> Parses the defining text for gender forms ("gwds") objects.
    /// </summary>
    public class GenderFormsDefiningTextParser : IDefiningTextParser
    {
        /// <inheritdoc />
        public IDefiningText Parse(JsonElement source)
        {
            return new GenderForms
            {
                GenderWordSpelledOut = JsonParserHelper.GetStringValue(source, "gwd") ?? string.Empty,
                GenderWordCutback = JsonParserHelper.GetStringValue(source, "gwc")
            };
        }
    }
}