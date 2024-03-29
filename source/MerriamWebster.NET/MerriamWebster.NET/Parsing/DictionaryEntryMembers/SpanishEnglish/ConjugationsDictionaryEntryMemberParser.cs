﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers.SpanishEnglish
{
    internal class ConjugationsDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "suppl")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;
            if (!source.TryGetProperty("cjts", out var cjtsElement))
            {
                return;
            }

            var cjts = cjtsElement.EnumerateArray();
            var conjugations = new Conjugations();
            var parsedConjugations = new List<Conjugation>(cjtsElement.GetArrayLength());

            foreach (var cjt in cjts)
            {
                var cjfs = cjt.GetProperty("cjfs");
                var items = cjfs.EnumerateArray().ToList();

                if (cjt.TryGetProperty("cjid", out var id)
                    && id.GetString() == "gppt")
                {
                    conjugations.PresentParticiple = items[0].GetString() ?? string.Empty;
                    conjugations.PastParticiple = items[1].GetString() ?? string.Empty;
                }
                else
                {
                    var conjugation = new Conjugation
                    {
                        Tense = id.GetString() ?? string.Empty,
                        SgFirst = items[0].GetString() ?? string.Empty,
                        SgSecond = items[1].GetString() ?? string.Empty,
                        SgThird = items[2].GetString() ?? string.Empty,
                        PlFirst = items[3].GetString() ?? string.Empty,
                        PlSecond = items[4].GetString() ?? string.Empty,
                        PlThird = items[5].GetString() ?? string.Empty
                    };
                    parsedConjugations.Add(conjugation);
                }
            }

            conjugations.Present = parsedConjugations.Single(c => c.Tense == "pind");
            conjugations.IndefinitePast = parsedConjugations.Single(c => c.Tense == "pprf");
            conjugations.ImperfectPast = parsedConjugations.Single(c => c.Tense == "pret");
            conjugations.Conditional = parsedConjugations.Single(c => c.Tense == "cond");
            conjugations.Future = parsedConjugations.Single(c => c.Tense == "futr");
            conjugations.Imperative = parsedConjugations.Single(c => c.Tense == "impf");
            conjugations.PresentPerfect = parsedConjugations.Single(c => c.Tense == "ppci");
            conjugations.PresentSubjunctive = parsedConjugations.Single(c => c.Tense == "psub");
            conjugations.ImperfectSubjunctive = parsedConjugations.Single(c => c.Tense == "pisb1");
            conjugations.FutureSubjunctive = parsedConjugations.Single(c => c.Tense == "fsub");
            conjugations.PastPerfect = parsedConjugations.Single(c => c.Tense == "ppsi");
            conjugations.PreteritePerfect = parsedConjugations.Single(c => c.Tense == "pant");
            conjugations.FuturePerfect = parsedConjugations.Single(c => c.Tense == "fpin");
            conjugations.ConditionalPerfect = parsedConjugations.Single(c => c.Tense == "cpef");
            conjugations.PresentPerfectSubjunctive = parsedConjugations.Single(c => c.Tense == "ppfs");
            conjugations.PastPerfectSubjunctive = parsedConjugations.Single(c => c.Tense == "ppss1");
            conjugations.FuturePerfectSubjunctive = parsedConjugations.Single(c => c.Tense == "fpsb");

            target.Conjugations = conjugations;
        }
    }
}