﻿using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    /// <summary>
    /// Parses the defining text of a called-also note ("ca" object).
    /// </summary>
    public class CalledAlsoNoteDefiningTextParser : IDefiningTextParser
    {
        /// <inheritdoc />
        public IDefiningText Parse(JsonElement source)
        {
            var note = new CalledAlsoNote
            {
                Intro = JsonParserHelper.GetStringValue(source, "intro") ?? string.Empty
            };

            if (source.TryGetProperty("cats", out var cats))
            {
                foreach (var cat in cats.EnumerateArray())
                {
                    var caTarget = new CalledAlsoTarget
                    {
                        TargetText = JsonParserHelper.GetStringValue(cat, "cat") ?? string.Empty,
                        Reference = JsonParserHelper.GetStringValue(cat, "catref"),
                        ParenthesizedNumber = JsonParserHelper.GetStringValue(cat, "pn"),
                        ParenthesizedSubjectStatusLabel = LabelsParser.ParseSingle<ParenthesizedSubjectStatusLabel>(cat, "psl")
                    };
                    if (cat.TryGetProperty("prs", out var prs))
                    {
                        caTarget.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
                    }

                    note.Targets.Add(caTarget);
                }
            }

            return note;
        }
    }
}