using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.Content
{
    public class DefinitionParser
    {
        public static Definition Parse(JsonElement source)
        {
            var definition = new Definition
            {
                VerbDivider = JsonParserHelper.GetStringValue(source, "vd"),
                SubjectStatusLabels = LabelsParser.ParseMultiple<SubjectStatusLabel>(source, "sls")
            };

            JsonSenseParser.Parse(source, definition);

            return definition;
        }
    }
}