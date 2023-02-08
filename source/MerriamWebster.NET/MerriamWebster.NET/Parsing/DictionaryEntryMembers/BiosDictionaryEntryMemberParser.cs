using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using MerriamWebster.NET.Results.Medical;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    /// <inheritdoc />
    public class BiosDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        /// <inheritdoc />
        public void Parse(JsonProperty json, EntryBase target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "bios")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;
            var biographicalNote = new BiographicalNote();
            foreach (var bio in source.EnumerateArray())
            {
                foreach (var biosArr in bio.EnumerateArray())
                {
                    var items= biosArr.EnumerateArray().ToList();

                    if (items.Count != 2)
                    {
                        continue;
                    }

                    var type = items[0].GetString();

                    if (type == "bionw")
                    {
                        var bionw = items[1];
                        var bnw = new BiographicalNameWrap
                        {
                            FirstName = JsonParserHelper.GetStringValue(bionw, "biopname"),
                            AlternateName = JsonParserHelper.GetStringValue(bionw, "bioname"),
                            Surname = JsonParserHelper.GetStringValue(bionw, "biosname")
                        };

                        if (bionw.TryGetProperty("prs", out var prs))
                        {
                            bnw.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
                        }

                        biographicalNote.DefiningTexts.Add(bnw);
                    }
                    else if (type == "biodate")
                    {
                        biographicalNote.DefiningTexts.Add(new BiosDate(items[1].GetString()) );
                    }
                    // note that "text" is not part of the official documenation,
                    // but it does appear in results (see "curie" for example)
                    else if(type is "text" or "biotx")
                    {
                        biographicalNote.DefiningTexts.Add(new BiosText(items[1].GetString()));
                    }
                }
            }

            ((MedicalEntry)target).BiographicalNote = biographicalNote;
        }
    }
}