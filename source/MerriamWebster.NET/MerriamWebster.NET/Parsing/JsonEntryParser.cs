using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Parser class for a few standard properties (labels, homograph, shortdefs, date) that don't require much specific parsing logic.
    /// </summary>
    public class JsonEntryParser
    {
        /// <summary>
        /// Parses a few standard properties (labels, homograph, shortdefs, date) that don't require much specific parsing logic.
        /// </summary>
        public static void Parse(JsonElement source, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (source.TryGetProperty("hom", out var homElem)
                && homElem.TryGetInt32(out var hom))
            {
                target.Homograph = hom;
            }

            target.FunctionalLabel = LabelsParser.ParseSingle<FunctionalLabel>(source, "fl");

            if (source.TryGetProperty("date", out var date) )
            {
                target.Date = date.GetString() ?? string.Empty;
            }

            var shortdef = JsonParserHelper.GetStringValues(source, "shortdef");
            if (shortdef != null)
            {
                target.ShortDefs = [];
                foreach (var def in shortdef)
                {
                    target.ShortDefs.Add(def);
                }
            }

            target.GeneralLabels = LabelsParser.ParseMultiple<GeneralLabel>(source, "lbs");
            target.SubjectStatusLabels = LabelsParser.ParseMultiple<SubjectStatusLabel>(source, "sls");
        }
    }
}