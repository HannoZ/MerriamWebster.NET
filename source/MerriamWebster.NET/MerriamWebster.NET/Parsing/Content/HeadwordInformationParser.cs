using System;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class HeadwordInformationParser : IContentParser
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

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (source.HeadwordInformation == null)
            {
                return target;
            }

            foreach (var pronunciation in source.HeadwordInformation.Pronunciations)
            {
                var pron = PronunciationHelper.Parse(pronunciation, target.Metadata.Language, options.AudioFormat);
                target.Headword.Pronunciations.Add(pron);
            }

            target.Headword.Text = source.HeadwordInformation.Headword;
            target.Headword.ParenthesizedSubjectStatusLabel = source.HeadwordInformation.ParenthesizedSubjectStatusLabel;

            return target;
        }
    }
}