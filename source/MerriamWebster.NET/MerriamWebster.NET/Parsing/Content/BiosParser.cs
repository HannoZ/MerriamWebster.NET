using System;
using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class BiosParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(target);
            ArgumentNullException.ThrowIfNull(source);
#else
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (!source.Bios.HasValue())
            {
                return target;
            }
#endif
            target.BiographicalNote = new Dto.BiographicalNote();
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
                            content.Pronunciations = new List<Dto.Pronunciation>();
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
                        target.BiographicalNote.Contents.Add(new Dto.DefiningText(element[1].TypeOrText){Type = typeOrText});
                    }
                }
            }

            return target;
        }
    }
}