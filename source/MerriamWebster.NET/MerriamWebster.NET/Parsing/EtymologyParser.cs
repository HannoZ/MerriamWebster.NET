using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse etymology objects
    /// </summary>
    public class EtymologyParser
    {
        public static Etymology Parse(JsonElement source)
        {
            var etymology = new Etymology();

            foreach (var contentElement in source.EnumerateArray())
            {
                var items = contentElement.EnumerateArray().ToList();
                if (items.Count != 2)
                {
                    continue;
                }

                var type = items[0].GetString();
                if (type == "text")
                {
                    etymology.Text = items[1].GetString() ?? string.Empty;
                }
                else if (type == "et_snote")
                {
                    etymology.Notes = new List<EtymologyNote>();
                    foreach (var noteElement in items[1].EnumerateArray())
                    {
                        var note = new EtymologyNote();
                        var texts = noteElement.EnumerateArray().ToList();

                        if (texts.Count != 2)
                        {
                            continue;
                        }

                        // texts[0] = "t"
                        var noteText = texts[1].GetString();
                        if (!string.IsNullOrEmpty(noteText))
                        {
                            note.Text = noteText; 
                            etymology.Notes.Add(note);
                        }
                    }
                }
            }

            return etymology;
        }
    }
}