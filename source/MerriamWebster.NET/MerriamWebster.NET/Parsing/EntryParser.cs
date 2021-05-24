using MerriamWebster.NET.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// The <see cref="EntryParser"/> class is used to get a result from the API and parse the raw data into an <see cref="EntryModel"/>.
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
        public Task<EntryModel> GetAndParseAsync(string api, string searchTerm)
        {
            return GetAndParseAsync(api, searchTerm, ParseOptions.Default);
        }

        /// <inheritdoc />
        public async Task<EntryModel> GetAndParseAsync(string api, string searchTerm, ParseOptions options)
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

            var resultModel = new EntryModel
            {
                SearchText = searchTerm.ToLowerInvariant()
            };

            foreach (var result in results)
            {
                resultModel.RawResponse = JsonConvert.SerializeObject(result, SerializerSettings);

                if (!result.Metadata.Stems.Contains(searchTerm.ToLowerInvariant()))
                {
                    continue;
                }

                var searchResult = CreateSearchResult(options, result);

                // parse definitions
                foreach (var def in result.Definitions)
                {
                    if (def.VerbDivider != null)
                    {
                        // verb divider indicates an entry that we should treat separately
                        var extraResult = CreateSearchResult(options, result);
                        extraResult.Pos = def.VerbDivider;
                        var senseParser = new SenseParser(def, options);
                        var senses = senseParser.Parse();
                        extraResult.Senses = new List<Sense>(senses);

                        resultModel.Entries.Add(extraResult);
                    }
                    else
                    {
                        var senseParser = new SenseParser(def, options);
                        var senses = senseParser.Parse();
                        searchResult.Senses = new List<Sense>(senses);
                    }
                }

                // we're done with this search result, add to collection
                resultModel.Entries.Add(searchResult);

                // parse and add any additional results (they appear in the 'DefinedRunOns' ('dro') property)
                var additionalResults = ParseDros(result.DefinedRunOns, options);
                foreach (var additionalResult in additionalResults)
                {
                    resultModel.AdditionalResults.Add(additionalResult);
                }

                // parse and add any 'undefined run-ons'
                var undefinedResults = ParseUros(result, options);
                foreach (var entry in undefinedResults)
                {
                    resultModel.UndefinedResults.Add(entry);
                }

            }

            return resultModel;
        }

        private static Entry CreateSearchResult(ParseOptions options, Response.DictionaryEntry result)
        {
            var searchResult = new Entry
            {
                Id = result.Metadata.Id,
                Text = result.HeadwordInformation.Headword,
                Pos = result.FunctionalLabel ?? string.Empty,
                Stems = result.Metadata.Stems,
                Language = (Language) result.Metadata.Lang,
                ShortDefs = result.Shortdefs,
                Synonyms = result.Metadata.Synonyms.SelectMany(s => s).ToList(),
                Antonyms = result.Metadata.Antonyms.SelectMany(s => s).ToList()
            };

            ParseBasicStuff(options, result, searchResult);

            searchResult.Conjugations = ParseConjugations(result.Supplemental);
            searchResult.CrossReferences = ParseCrossReferences(result).ToList();

            return searchResult;
        }

        private static void ParseBasicStuff(ParseOptions options, Response.DictionaryEntry result, Entry searchResult)
        {
            foreach (var pronunciation in result.HeadwordInformation.Pronunciations)
            {
                var pron = new Pronunciation
                {
                    WrittenPronunciation = pronunciation.WrittenPronunciation,
                    AudioLink = AudioLinkCreator.CreateLink(result.Metadata.Lang, pronunciation.Sound, options.AudioFormat)
                };
                searchResult.Pronunciations.Add(pron);
            }

            if (searchResult.Pos.StartsWith("feminine"))
            {
                searchResult.Gender = "feminine";
                searchResult.Pos = searchResult.Pos.Replace("feminine", "").TrimStart();
            }
            else if (searchResult.Pos.StartsWith("masculine"))
            {
                searchResult.Gender = "masculine";
                searchResult.Pos = searchResult.Pos.Replace("masculine", "").TrimStart();
            }
        }

        private static IEnumerable<CrossReference> ParseCrossReferences(Response.DictionaryEntry result)
        {
            foreach (var crossReference in result.CrossReferences.SelectMany(cr => cr))
            {
                yield return new CrossReference
                {
                    Target = crossReference.Target,
                    Text = crossReference.Text
                };
            }
        }

        private static IEnumerable<Entry> ParseDros(Response.DefinedRunOn[] dros, ParseOptions parseOptions)
        {
            var searchResults = new List<Entry>();
            if (dros == null)
            {
                return searchResults;
            }

            foreach (var dro in dros)
            {
                var searchResult = new Entry { Text = dro.Phrase, Pos = dro.FunctionalLabel };

                foreach (var droDef in dro.Definitions)
                {
                    var senseParser = new SenseParser(droDef, parseOptions);
                    var senses = senseParser.Parse();
                    searchResult.Senses = new List<Sense>(senses);
                }

                searchResults.Add(searchResult);
            }

            return searchResults;
        }

        private static IEnumerable<Entry> ParseUros(Response.DictionaryEntry entry, ParseOptions options)
        {
            var searchResults = new List<Entry>();

            foreach (var uro in entry.UndefinedRunOns)
            {
                var searchResult = new Entry
                {
                    Text = uro.EntryWord,
                    Pos = uro.FunctionalLabel,
                    Language = (Language)entry.Metadata.Lang
                };
                searchResult.Stems.Add(uro.EntryWord);
                if (uro.AlternateEntry?.Text != null)
                {
                    searchResult.Stems.Add(uro.AlternateEntry.Text);
                }

                foreach (var pronunciation in uro.Pronunciations)
                {
                    var pron = new Pronunciation
                    {
                        WrittenPronunciation = pronunciation.WrittenPronunciation,
                        AudioLink = AudioLinkCreator.CreateLink(entry.Metadata.Lang, pronunciation.Sound, options.AudioFormat)
                    };
                    searchResult.Pronunciations.Add(pron);
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