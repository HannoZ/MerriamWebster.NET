using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;
using Conjugation = MerriamWebster.NET.Dto.Conjugation;
using Pronunciation = MerriamWebster.NET.Dto.Pronunciation;

namespace MerriamWebster.NET.Parsing
{
    public class EntryParser : IEntryParser
    {
        private readonly IMerriamWebsterClient _client;
        
        public EntryParser(IMerriamWebsterClient client)
        {
            _client = client;
        }

        public Task<EntryModel> GetAndParseAsync(string api, string searchTerm)
        {
            return GetAndParseAsync(api, searchTerm, new ParseOptions());
        }

        public async Task<EntryModel> GetAndParseAsync(string api, string searchTerm, ParseOptions options)
        {
            var results = await _client.GetDictionaryEntry(api, searchTerm);

            var resultModel = new EntryModel
            {
                SearchText = searchTerm.ToLowerInvariant()
            };

            foreach (var result in results)
            {
                if (!result.Metadata.Stems.Contains(searchTerm.ToLowerInvariant()))
                {
                    continue;
                }
                foreach (var def in result.Definitions)
                {
                    var searchResult = new Entry
                    {
                        Id = result.Metadata.Id,
                        Text = result.HeadwordInformation.Headword,
                        Pos = result.FunctionalLabel ?? string.Empty
                    };

                    foreach (var pronunciation in result.HeadwordInformation.Pronunciations)
                    {
                        var pron = new Pronunciation
                        {
                            WrittenPronunciation = pronunciation.WrittenPronunciation,
                            AudioLink = AudioLinkCreator.CreateLink(result.Metadata.Lang, pronunciation.Sound, options.AudioFormat)
                        };
                        searchResult.Pronunciations.Add(pron);
                    }

                    if (def.VerbDivider != null)
                    {
                        searchResult.Pos = def.VerbDivider;
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

                    searchResult.Stems = result.Metadata.Stems;

                    var senseParser = new SenseParser(def, options);
                    var senses = senseParser.Parse();
                    searchResult.Senses = new List<Sense>(senses);

                    var conjugation = ParseConjugations(result.Supplemental);
                    searchResult.Conjugations = conjugation;

                    resultModel.Entries.Add(searchResult);
                }

                var additionalResults = ParseDros(result.DefinedRunOns, options);
                foreach (var searchResult in additionalResults)
                {
                    resultModel.Entries.Add(searchResult);
                }
            }
            
            return resultModel;
        }

        private static IEnumerable<Entry> ParseDros(DefinedRunOn[] dros, ParseOptions parseOptions)
        {
            var searchResults = new List<Entry>();
            if (dros == null)
            {
                return searchResults;
            }

            foreach (var dro in dros)
            {
                var searchResult = new Entry {Text = dro.Drp, Pos = dro.Fl};

                foreach (var droDef in dro.Def)
                {
                    var senseParser = new SenseParser(droDef, parseOptions);
                    var senses = senseParser.Parse();
                    searchResult.Senses = new List<Sense>(senses);
                }

                searchResults.Add(searchResult);
            }

            return searchResults;
        }

        private static Conjugations ParseConjugations(Supplemental supplemental)
        {
            if (supplemental == null)
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