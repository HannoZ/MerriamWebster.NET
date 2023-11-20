using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    /// <summary>
    /// The defining text parser interface.
    /// </summary>
    public interface IDefiningTextParser
    {
        /// <summary>
        /// Parses the defining text from the specified source.
        /// </summary>
        /// <param name="source">The source <see cref="JsonElement"/>.</param>
        /// <returns>The parsed <see cref="IDefiningText"/> object.</returns>
        IDefiningText Parse(JsonElement source);
    }
}