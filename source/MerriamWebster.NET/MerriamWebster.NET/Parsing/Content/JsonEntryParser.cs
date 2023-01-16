using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.Content
{
    public class JsonEntryParser
    {
        public void Parse(JsonElement source, EntryBase target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));
            
            if (source.TryGetProperty("hom", out var homElem)
                && homElem.TryGetInt32(out var hom))
            {
                target.Homograph = hom;
            }

            target.FunctionalLabel = LabelsParser.ParseSingle<FunctionalLabel>(source, "fl");
            
            if (source.TryGetProperty("date", out var date))
            {
                target.Date = date.GetString();
            }

            var shortdef = JsonParserHelper.GetStringValues(source, "shortdef");
            if (shortdef != null)
            {
                target.ShortDefs = new List<string>();
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