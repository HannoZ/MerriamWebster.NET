using MerriamWebster.NET.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerriamWebster.NET.Parsing.Markup;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Contains methods to get a result from the API and parse the raw data into an <see cref="ResultModel"/>.
    /// </summary>
    public class EntryParser : IEntryParser
    {
        private readonly IMerriamWebsterClient _client;
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        /// <summary>
        /// Initializes a new instances of the <see cref="EntryParser"/> class.
        /// </summary>
        /// <param name="client"></param>
        /// <remarks>It's most convenient to register this class as implementation of the <see cref="IEntryParser"/> interface and inject the interface where it's needed.
        /// This constructor should therefore not be called directly, new instances should be created by the current IoC framework.</remarks>
        public EntryParser(IMerriamWebsterClient client)
        {
            _client = client;
        }

        /// <inheritdoc />
        public Task<ResultModel> GetAndParseAsync(string api, string searchTerm)
        {
            return GetAndParseAsync(api, searchTerm, ParseOptions.Default);
        }

        /// <inheritdoc />
        public async Task<ResultModel> GetAndParseAsync(string api, string searchTerm, ParseOptions options)
        {
            if (searchTerm == null)
            {
                throw new ArgumentNullException(nameof(searchTerm));
            }

            if (options == null)
            {
                options = ParseOptions.Default;
            }

            var results = await _client.GetDictionaryEntry(api, searchTerm);

            var resultModel = new ResultModel
            {
                SearchText = searchTerm.ToLowerInvariant(),
                RawResponse = JsonConvert.SerializeObject(results, SerializerSettings)
            };

            foreach (var result in results)
            {
                var searchResult = CreateSearchResult(result, options);

                // parse definitions
                foreach (var def in result.Definitions)
                {
                    var definition = new Definition
                    {
                        VerbDivider = def.VerbDivider
                    };

                    var senseParser = new SenseParser(def, searchResult.Metadata.Language, options);
                    senseParser.Parse(definition);

                    if (def.Sls.Any())
                    {
                        definition.SubjectStatusLabels = new List<Label>();
                        foreach (var label in def.Sls)
                        {
                            definition.SubjectStatusLabels.Add(label);
                        }
                    }

                    searchResult.Definitions.Add(definition);
                }

                // we're done with this search result, add to collection
                resultModel.Entries.Add(searchResult);

                // parse and add any additional results (they appear in the 'DefinedRunOns' ('dro') property)
                if (result.DefinedRunOns.Any())
                {
                     ParseDros(searchResult, result.DefinedRunOns, options);
                }

                // parse and add any 'undefined run-ons'
                if (result.UndefinedRunOns.Any())
                {
                    searchResult.UndefinedRunOns = ParseUros(result, options).ToList();
                }

                if (result.Quotes.Any())
                {
                    // parse and add any quotes
                    searchResult.Quotes = new List<Quote>();

                    foreach (var sourceQuote in result.Quotes)
                    {
                        var quote = QuoteHelper.Parse(sourceQuote, options);
                        searchResult.Quotes.Add(quote);
                    }
                }
            }

            return resultModel;
        }

        private static Entry CreateSearchResult(Response.DictionaryEntry result, ParseOptions options)
        {
            var searchResult = new Entry
            {
                Metadata = MetadataHelper.Parse(result),
                PartOfSpeech = result.FunctionalLabel ?? string.Empty,
                ShortDefs = result.Shortdefs,
                Homograph = result.Homograph.GetValueOrDefault()
                // TODO
                //Synonyms = result.Metadata.Synonyms.SelectMany(s => s).ToList(),
                //Antonyms = result.Metadata.Antonyms.SelectMany(s => s).ToList()
            };

            if (!string.IsNullOrEmpty(result.FunctionalLabel))
            {
                searchResult.PartOfSpeech = result.FunctionalLabel;
            }

            if (result.GeneralLabels.Any())
            {
                searchResult.GeneralLabels = new List<Label>();
                foreach (var generalLabel in result.GeneralLabels)
                {
                    searchResult.GeneralLabels.Add(generalLabel);
                }
            }

            if (result.SubjectStatusLabels.Any())
            {
                searchResult.SubjectStatusLabels = new List<Label>();
                foreach (var subjectStatusLabel in result.SubjectStatusLabels)
                {
                    searchResult.SubjectStatusLabels.Add(subjectStatusLabel);
                }
            }

            ParseBasicStuff(options, result, searchResult);

            searchResult.Conjugations = ParseConjugations(result.Supplemental);
            if (result.CrossReferences.Any())
            {
                searchResult.CrossReferences = CrossReferenceHelper.Parse(result.CrossReferences).ToList();
            }

            if (result.CognateCrossReferences.Any())
            {
                searchResult.CognateCrossReferences = CognateCrossReferenceHelper.Parse(result.CognateCrossReferences).ToList();
            }

            if (result.Inflections.Any())
            {
                searchResult.Inflections = InflectionHelper.Parse(result.Inflections, searchResult.Metadata.Language, options.AudioFormat).ToList();
            }

            return searchResult;
        }

        private static void ParseBasicStuff(ParseOptions options, Response.DictionaryEntry result, Entry searchResult)
        {
            foreach (var pronunciation in result.HeadwordInformation.Pronunciations)
            {
                var pron = PronunciationHelper.Parse(pronunciation, searchResult.Metadata.Language, options.AudioFormat);
                searchResult.Headword.Pronunciations.Add(pron);
            }

            if (result.Artwork != null)
            {
                searchResult.Artwork = new Artwork
                {
                    Caption = result.Artwork.Caption,
                    HtmlLocation = ArtworkLinkCreator.CreatePageLink(result.Artwork),
                    ImageLocation = ArtworkLinkCreator.CreateDirectLink(result.Artwork)
                };
            }

            if (!string.IsNullOrEmpty(result.Date))
            {
                searchResult.Date = MarkupManipulator.RemoveMarkupFromString(result.Date);
            }

            if (result.HeadwordInformation != null)
            {
                // TODO
            }
        }

        private static void ParseDros(Entry result, Response.DefinedRunOn[] dros, ParseOptions parseOptions)
        {
            var searchResults = new List<DefinedRunOn>();
            if (dros == null)
            {
                return;
            }

            foreach (var dro in dros)
            {
                var searchResult = new DefinedRunOn
                {
                    Phrase = dro.Phrase
                };

                foreach (var droDef in dro.Definitions)
                {
                    var senseParser = new SenseParser(droDef, result.Metadata.Language, parseOptions);
                    var def = new Definition();
                    senseParser.Parse(def);

                    searchResult.Definitions.Add(def);
                }

                searchResults.Add(searchResult);
            }

            result.DefinedRunOns = searchResults;
        }

        private static IEnumerable<UndefinedRunOn> ParseUros(Response.DictionaryEntry entry, ParseOptions options)
        {
            var searchResults = new List<UndefinedRunOn>();

            foreach (var uro in entry.UndefinedRunOns)
            {
                var searchResult = new UndefinedRunOn
                {
                    EntryWord = uro.EntryWord,
                    PartOfSpeech = uro.FunctionalLabel
                };

                if (uro.Pronunciations.Any())
                {
                    searchResult.Pronunciations = new List<Pronunciation>();
                    foreach (var pronunciation in uro.Pronunciations)
                    {
                        var pron = PronunciationHelper.Parse(pronunciation, (Language)entry.Metadata.Lang,
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

                searchResults.Add(searchResult);
            }

            return searchResults;
        }

        private static Conjugations ParseConjugations(Response.Supplemental supplemental)
        {
            if (supplemental?.Conjugations.Any() != true)
            {
                return null;
            }

            var conjugations = new Conjugations();
            var parsedConjugations = new List<Conjugation>();
            foreach (var cjt in supplemental.Conjugations)
            {
                if (cjt.Id == "gppt")
                {
                    conjugations.PastParticiple = cjt.Fields[1];
                    conjugations.PresentParticiple = cjt.Fields[0];
                }
                else
                {
                    var conjugation = new Conjugation
                    {
                        Tense = cjt.Id,
                        SgFirst = cjt.Fields[0],
                        SgSecond = cjt.Fields[1],
                        SgThird = cjt.Fields[2],
                        PlFirst = cjt.Fields[3],
                        PlSecond = cjt.Fields[4],
                        PlThird = cjt.Fields[5],
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


            return conjugations;
        }


    }
}