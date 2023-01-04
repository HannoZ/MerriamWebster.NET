using System;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class HeadwordInformationParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));
            ArgumentNullException.ThrowIfNull(options, nameof(options));

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