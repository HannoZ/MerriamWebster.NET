using System;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing
{
    public class DefinitionParser
    {
        public static void Parse(JsonElement source, EntryBase target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (source.TryGetProperty("def", out var defElement))
            {
                var definitions = defElement.EnumerateArray();
                foreach (var def in definitions)
                {
                    var definition = new Definition
                    {
                        VerbDivider = JsonParserHelper.GetStringValue(def, "vd"),
                        SubjectStatusLabels = LabelsParser.ParseMultiple<SubjectStatusLabel>(def, "sls")
                    };

                    JsonSenseParser.Parse(def, definition);

                    target.Definitions.Add(definition);
                }
            }
        }
    }
}