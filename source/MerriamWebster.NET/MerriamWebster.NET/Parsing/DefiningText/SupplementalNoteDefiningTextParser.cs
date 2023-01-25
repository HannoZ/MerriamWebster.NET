﻿using System.Collections.Generic;
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

            // supplemental notes can contain nested defining types like "vis" and "ri"
            // we must collect those objects first and add each one to the supplemental note separately
            var elements = new List<JsonElement>();
            Enumerate(source);

            foreach (var element in elements)
            {
                var items = element.EnumerateArray().ToList();
                var type = items[0].GetString();
                if (type == "t")
                {
                    type = "text";
                }
                var parser = DefiningTextParserFactory.Create(type);
                if (items[1].ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in items[1].EnumerateArray())
                    {
                        snote.DefiningTexts.Add(parser.Parse(item));
                    }
                }
                else
                {
                    snote.DefiningTexts.Add(parser.Parse(items[1]));
                }


                //if (element.ValueKind == JsonValueKind.Array)
                //{
                //    foreach (var value in element.EnumerateArray())
                //    {
                //        ParseObject(value);
                //    }
                //}
                //else
                //{
                //    ParseObject(element);
                //}

                void ParseObject(JsonElement obj)
                {
                    if (obj.ValueKind == JsonValueKind.String)
                    {
                        var stringValue = obj.GetString();
                        if (stringValue != "t" && stringValue != "vis" && stringValue != "ri")
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