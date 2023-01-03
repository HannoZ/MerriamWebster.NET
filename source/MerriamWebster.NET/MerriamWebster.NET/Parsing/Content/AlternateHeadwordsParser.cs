using System;
using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class AlternateHeadwordsParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (!source.AlternateHeadwords.HasValue())
            {
                return target;
            }

            target.AlternateHeadwords = new List<AlternateHeadwordInformation>();
            foreach (var alternateHeadword in source.AlternateHeadwords)
            {
                var alternateHeadwordInformation = new AlternateHeadwordInformation
                {
                    HeadwordCutback = alternateHeadword.HeadwordCutback,
                    ParenthesizedSubjectStatusLabel = alternateHeadword.ParenthesizedSubjectStatusLabel,
                    Text = alternateHeadword.Headword
                };

                if (alternateHeadword.Pronunciations.Any())
                {
                    alternateHeadwordInformation.Pronunciations = new List<Dto.Pronunciation>();
                    foreach (var pronunciation in alternateHeadword.Pronunciations)
                    {
                        alternateHeadwordInformation.Pronunciations.Add(PronunciationHelper.Parse(pronunciation, target.Metadata.Language, options.AudioFormat));
                    }
                }

                target.AlternateHeadwords.Add(alternateHeadwordInformation);
            }

            return target;
        }
    }
}