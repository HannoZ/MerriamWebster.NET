using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Parsing.Markup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Contains methods to get a result from the API and parse the raw data into an <see cref="ResultModel"/>.
    /// </summary>
    public class EntryParser : IEntryParser
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore
        };
        
        /// <inheritdoc />
        public ResultModel Parse(string searchTerm, IEnumerable<Response.DictionaryEntry> results)
        {
            return Parse(searchTerm, results, ParseOptions.Default);
        }

        /// <inheritdoc />
        public ResultModel Parse(string searchTerm, IEnumerable<Response.DictionaryEntry> results, ParseOptions options)
        {
            if (searchTerm == null)
            {
                throw new ArgumentNullException(nameof(searchTerm));
            }

            if (options == null)
            {
                options = ParseOptions.Default;
            }

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

                if (result.Variants.Any())
                {
                    searchResult.Variants = VariantHelper.Parse(result.Variants, searchResult.Metadata.Language, options.AudioFormat).ToList();
                }

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

                if (result.Et.Any())
                {
                    searchResult.Etymology = result.Et.ParseEtymology();
                }
            }

            return resultModel;
        }

        private static Entry CreateSearchResult(Response.DictionaryEntry result, ParseOptions options)
        {
            var searchResult = new Entry
            {
                Metadata = result.ParseMetadata(),
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

            if (result.Synonyms.Any())
            {
                searchResult.Synonyms = ParseSynonyms(result.Synonyms).ToList();
            }

            if (result.DirectionalCrossReferences.Any())
            {
                searchResult.DirectionalCrossReferences = new List<FormattedText>();
                foreach (var crossReference in result.DirectionalCrossReferences)
                {
                    searchResult.DirectionalCrossReferences.Add(new FormattedText(crossReference));
                }
            }

            if (result.Usages.Any())
            {
                searchResult.Usages = new List<Usage>();
                foreach (var srcUsage in result.Usages)
                {
                    var usage = new Usage
                    {
                        ParagraphLabel = srcUsage.ParagraphLabel
                    };

                    foreach (var complexTypeWrapper in srcUsage.ParagraphText)
                    {
                        var type = complexTypeWrapper[0].TypeLabelOrText;
                        if (type == DefiningTextTypes.Text)
                        {
                            usage.ParagraphTexts.Add(new DefiningText(complexTypeWrapper[1].TypeLabelOrText));
                        }
                        else if (type == DefiningTextTypes.VerbalIllustration)
                        {
                            foreach (var dt in complexTypeWrapper[1].DefiningTextComplexTypes)
                            {
                                usage.ParagraphTexts.Add(VisHelper.Parse(dt.DefiningText));
                            }
                        }
                        else if (type == DefiningTextTypes.InAdditionReference)
                        {
                            // TODO, requires sample json
                        }
                    }

                    searchResult.Usages.Add(usage);
                }
            }

            if (result.Table != null)
            {
                searchResult.Table = new Table
                {
                    Displayname = result.Table.Displayname,
                    TableId = result.Table.Tableid
                };
            }

            return searchResult;
        }

        private static void ParseBasicStuff(ParseOptions options, Response.DictionaryEntry result, Entry searchResult)
        {
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
                foreach (var pronunciation in result.HeadwordInformation.Pronunciations)
                {
                    var pron = PronunciationHelper.Parse(pronunciation, searchResult.Metadata.Language, options.AudioFormat);
                    searchResult.Headword.Pronunciations.Add(pron);
                }

                searchResult.Headword.Text = result.HeadwordInformation.Headword;
                searchResult.Headword.ParenthesizedSubjectStatusLabel = result.HeadwordInformation.ParenthesizedSubjectStatusLabel;
            }

            if (result.AlternateHeadwords.Any())
            {
                searchResult.AlternateHeadwords = new List<AlternateHeadwordInformation>();
                foreach (var alternateHeadword in result.AlternateHeadwords)
                {
                    var alternateHeadwordInformation = new AlternateHeadwordInformation
                    {
                        HeadwordCutback = alternateHeadword.HeadwordCutback,
                        ParenthesizedSubjectStatusLabel = alternateHeadword.ParenthesizedSubjectStatusLabel,
                        Text = alternateHeadword.Headword
                    };

                    if (alternateHeadword.Pronunciations.Any())
                    {
                        alternateHeadwordInformation.Pronunciations = new List<Pronunciation>();
                        foreach (var pronunciation in alternateHeadword.Pronunciations)
                        {
                            alternateHeadwordInformation.Pronunciations.Add(PronunciationHelper.Parse(pronunciation, searchResult.Metadata.Language, options.AudioFormat));
                        }
                    }

                    searchResult.AlternateHeadwords.Add(alternateHeadwordInformation);
                }
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

                if (dro.Et.Any())
                {
                    searchResult.Etymology = dro.Et.ParseEtymology();
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

        private static IEnumerable<Synonym> ParseSynonyms(Response.Synonym[] sources)
        {
            foreach (var source in sources)
            {
                var synonym = new Synonym
                {
                    ParagraphLabel = source.Pl
                };

                if (source.Sarefs?.Any() == true)
                {
                    synonym.SeeInAdditionReference = new List<string>(source.Sarefs);
                }

                foreach (var dt in source.Pt)
                {
                    if (dt[0].TypeLabelOrText == DefiningTextTypes.Text)
                    {
                        synonym.DefiningTexts.Add(new DefiningText(dt[1].TypeLabelOrText));
                    }
                    else if (dt[0].TypeLabelOrText == DefiningTextTypes.VerbalIllustration)
                    {
                        foreach (var dtc in dt[1].DefiningTextComplexTypes)
                        {
                            synonym.DefiningTexts.Add(VisHelper.Parse(dtc.DefiningText));
                        }
                    }
                }

                yield return synonym;
            }
        }
    }
}