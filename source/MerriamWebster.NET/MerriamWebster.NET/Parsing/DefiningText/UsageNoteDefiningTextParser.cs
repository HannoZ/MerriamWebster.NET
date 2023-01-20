using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    public class UsageNoteDefiningTextParser : IDefiningTextParser
    {
        public IDefiningText Parse(JsonElement source)
        {
            var usageNote = new UsageNote();

            // usage notes can contain nested defining types like "vis" and "ri"
            // we must collect those objects first and add each one to the usage note separately
            var elements = new List<JsonElement>();
            Enumerate(source);
            foreach (var element in elements)
            {
                var items = element.EnumerateArray().ToList();
                var parser = DefiningTextParserFactory.Create(items[0].GetString());
                if (items[1].ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in items[1].EnumerateArray())
                    {
                        usageNote.DefiningTexts.Add(parser.Parse(item));
                    }
                }
                else
                {
                    usageNote.DefiningTexts.Add(parser.Parse(items[1]));
                }
            }

            return usageNote;

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