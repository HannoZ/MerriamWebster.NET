using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    /// <summary>
    /// <i>Spanish-English only.</i> Parses the defining text for gender label ("gl") objects.
    /// </summary>
    public class GenderLabelDefiningTextParser : IDefiningTextParser
    {
        /// <inheritdoc />
        public IDefiningText Parse(JsonElement source)
        {
            return new GenderLabel(source.GetString());
        }
    }
}