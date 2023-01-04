using System;
using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using BiographicalNote = MerriamWebster.NET.Results.BiographicalNote;
using DefiningText = MerriamWebster.NET.Results.DefiningText;
using Pronunciation = MerriamWebster.NET.Results.Pronunciation;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class BiosParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            if (!source.Bios.HasValue())
            {
                return target;
            }

            target.BiographicalNote = new BiographicalNote();
            foreach (var bioElement in source.Bios)
            {
                foreach (var element in bioElement)
                {
                    if (element is { Length: < 2 })
                    {
                        continue;
                    }

                    var typeOrText = element[0].TypeOrText;
                    if (typeOrText == "bionw")
                    {
                        var note = element[1].BiographicalNote;
                        var content = new BiographicalNameWrap()
                        {
                            FirstName = note.Biopname,
                            AlternateName = note.Bioname,
                            Surname = note.Biosname
                        };

                        if (note.Prs.Any())
                        {
                            content.Pronunciations = new List<Pronunciation>();
                            foreach (var pronunciation in note.Prs)
                            {
                                content.Pronunciations.Add(PronunciationHelper.Parse(pronunciation, target.Metadata.Language, options.AudioFormat));
                            }
                        }

                        target.BiographicalNote.Contents.Add(content);
                    }

                    // note that "text" is not part of the official documenation,
                    // but it does appear in results (see "curie" for example)
                    else if (typeOrText is "biodate" or "text" or "biotx")
                    {
                        target.BiographicalNote.Contents.Add(new DefiningText(element[1].TypeOrText) { Type = typeOrText });
                    }
                }
            }

            return target;
        }
    }
}