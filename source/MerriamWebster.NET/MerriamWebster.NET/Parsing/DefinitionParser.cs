using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Parser for definition ("def") objects.
    /// </summary>
    public class DefinitionParser
    {
        /// <summary>
        /// Parses a definition ("def") json element.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Definition Parse(JsonElement source)
        {
            var definition = new Definition
            {
                VerbDivider = JsonParserHelper.GetStringValue(source, "vd"),
                SubjectStatusLabels = LabelsParser.ParseMultiple<SubjectStatusLabel>(source, "sls")
            };

            SenseParser.Parse(source, definition);

            return definition;
        }
    }
}