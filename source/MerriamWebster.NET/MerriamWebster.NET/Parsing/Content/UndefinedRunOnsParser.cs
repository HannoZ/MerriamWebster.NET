using System;
using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using AlternateUndefinedEntryWord = MerriamWebster.NET.Results.AlternateUndefinedEntryWord;
using Pronunciation = MerriamWebster.NET.Results.Pronunciation;
using UndefinedRunOn = MerriamWebster.NET.Results.UndefinedRunOn;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class UndefinedRunOnsParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            // parse and add any 'undefined run-ons'
            if (!source.UndefinedRunOns.HasValue())
            {
                return target;
            }

            target.UndefinedRunOns = new List<UndefinedRunOn>();

            foreach (var uro in source.UndefinedRunOns)
            {
                var searchResult = new UndefinedRunOn
                {
                    EntryWord = uro.EntryWord,
                    PartOfSpeech = uro.FunctionalLabel
                };

                if (uro.GeneralLabels.Any())
                {
                    searchResult.GeneralLabels = new List<Label>();
                    foreach (var generalLabel in uro.GeneralLabels)
                    {
                        searchResult.GeneralLabels.Add(generalLabel);
                    }
                }

                if (uro.Sls.Any())
                {
                    searchResult.SubjectStatusLabels = new List<Label>();
                    foreach (var sls in searchResult.SubjectStatusLabels)
                    {
                        searchResult.SubjectStatusLabels.Add(sls);
                    }
                }

                if (uro.Pronunciations.Any())
                {
                    searchResult.Pronunciations = new List<Pronunciation>();
                    foreach (var pronunciation in uro.Pronunciations)
                    {
                        var pron = PronunciationHelper.Parse(pronunciation, target.Metadata.Language,
                            options.AudioFormat);
                        searchResult.Pronunciations.Add(pron);
                    }
                }

                if (uro.AlternateEntry != null)
                {
                    searchResult.AlternateEntry = new AlternateUndefinedEntryWord
                    {
                        Text = uro.AlternateEntry.Text,
                        TextCutback = uro.AlternateEntry.TextCutback
                    };
                }

                if (uro.Vrs.Any())
                {
                    searchResult.Variants = VariantHelper.Parse(uro.Vrs, target.Metadata.Language, options.AudioFormat).ToList();
                }

                if (uro.Inflections.Any())
                {
                    searchResult.Inflections = InflectionHelper.Parse(uro.Inflections, target.Metadata.Language, options.AudioFormat).ToList();
                }

                target.UndefinedRunOns.Add(searchResult);
            }

            return target;
        }


    }
}