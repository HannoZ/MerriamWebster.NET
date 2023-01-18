using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    public class SupplementalNoteDefiningTextParser : IDefiningTextParser
    {
        public IDefiningText Parse(JsonElement source)
        {
            var snote = new SupplementalInformationNote();

            var elements = new List<JsonElement>();
            Enumerate(source);

            foreach (var element in elements)
            {
                if (element.ValueKind == JsonValueKind.Array)
                {
                    foreach (var value in element.EnumerateArray())
                    {
                        ParseObject(value);
                    }
                }
                else
                {
                    ParseObject(element);
                }

                void ParseObject(JsonElement obj)
                {
                    if (obj.ValueKind == JsonValueKind.String)
                    {
                        var stringValue = obj.GetString();
                        if (stringValue != "t")
                        {
                            snote.DefiningTexts.Add(new Results.DefiningText(stringValue));
                        }

                    }
                    else if (obj.ValueKind == JsonValueKind.Object)
                    {
                        var text = JsonParserHelper.GetStringValue(obj, "t");
                        snote.DefiningTexts.Add(new Results.DefiningText(text));
                    }
                }
            }

            return snote;

            void Enumerate(JsonElement element)
            {
                if (element.ValueKind == JsonValueKind.Array)
                {
                    var subElements = element.EnumerateArray().ToList();
                    if (subElements.Count == 2
                        && subElements[0].ValueKind == JsonValueKind.String)
                    {
                        elements.Add(element);
                    }
                    else
                    {
                        foreach (var subElement in subElements)
                        {
                            Enumerate(subElement);
                        }
                    }

                }
                else
                {
                    elements.Add(element);
                }
            }
        }
    }
}