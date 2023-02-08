using MerriamWebster.NET.Parsing.DefiningText;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.SpanishEnglish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// The <see cref="SenseParser"/> class does the heavy-lifting of peeling the senses out of a search result.
    /// </summary>
    public class SenseParser
    {
        public static void Parse(JsonElement source, Definition target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (source.TryGetProperty("sseq", out var sseqElement))
            {
                var sseqs = sseqElement.EnumerateArray();
                foreach (var sseq in sseqs)
                {
                    var senseSequence = new SenseSequence();

                    var sequences = sseq.EnumerateArray();
                    foreach (var sequence in sequences)
                    {
                        var items = sequence.EnumerateArray().ToList();

                        // sourceSseq comes in pairs: a string that defines the object ("sense", "sen", "pseq", etc.) , followed by the actual object
                        if (items.Count != 2)
                        {
                            continue;
                        }

                        var type = items[0].GetString();
                        var sourceSense = items[1];
                        
                        if (type == "bs") // binding substitute
                        {
                            var subSense = ParseBsSense(sourceSense);
                            if (subSense != null)
                            {
                                senseSequence.Senses.Add(subSense);
                            }
                        }
                        else if (type == "sense") // common sense ;-) 
                        {
                            var targetSense = ParseCommonSense(sourceSense);
                            senseSequence.Senses.Add(targetSense);
                        }
                        else if (type == "sen") // truncated sense
                        {
                            var targetSense = new Sense
                            {
                                IsTruncatedSense = true,
                                SenseNumber = JsonParserHelper.GetStringValue(sourceSense, "sn") ?? string.Empty
                            };

                            ParseGeneralSenseProperties(sourceSense, targetSense);

                            if (sourceSense.TryGetProperty("xrs", out var xrs))
                            {
                                targetSense.CrossReferences = new List<CrossReference>(CrossReferenceParser.Parse(xrs));
                            }
                            
                            senseSequence.Senses.Add(targetSense);
                        }
                        else if (type == "pseq") // parenthesized sense sequence
                        {
                            var pseq = new SenseSequenceSense()
                            {
                                IsParenthesizedSenseSequence = true,
                                Senses = new List<SenseSequenceSense>()
                            };

                            foreach (var sourceSequence in sourceSense.EnumerateArray())
                            {
                                var pseqElements = sourceSequence.EnumerateArray().ToList();
                                var pseqType = pseqElements[0].GetString();
                                if (pseqType == "bs")
                                {
                                    var subSense = ParseBsSense(pseqElements[1]);
                                    if (subSense != null)
                                    {
                                        pseq.Senses.Add(subSense);
                                    }
                                }
                                else if (pseqType == "sense")
                                {
                                    var sense = ParseCommonSense(pseqElements[1]);
                                    pseq.Senses.Add(sense);
                                }
                            }

                            senseSequence.Senses.Add(pseq);
                        }
                    }

                    target.SenseSequence.Add(senseSequence);
                }
            }

            Sense? ParseBsSense(JsonElement sourceSense)
            {
                // a bs should always contain a nested sense object  
                if (!sourceSense.TryGetProperty("sense", out var subSenseElement))
                {
                    return null;
                }

                var subSense = new Sense
                {
                    IsBindingSubstitute = true,
                    SenseNumber = JsonParserHelper.GetStringValue(subSenseElement, "sn") ?? string.Empty
                };

                ParseGeneralSenseProperties(subSenseElement, subSense);
                ParseSpecificSenseProperties(subSenseElement, subSense);

                return subSense;
            }

            Sense ParseCommonSense(JsonElement sourceSense)
            {
                var targetSense = new Sense
                {
                    SenseNumber = JsonParserHelper.GetStringValue(sourceSense, "sn") ?? string.Empty
                };

                ParseGeneralSenseProperties(sourceSense, targetSense);
                ParseSpecificSenseProperties(sourceSense, targetSense);

                if (sourceSense.TryGetProperty("xrs", out var xrs))
                {
                    targetSense.CrossReferences = new List<CrossReference>(CrossReferenceParser.Parse(xrs));
                }

                return targetSense;
            }
        }

        private static void ParseGeneralSenseProperties(JsonElement source, SenseBase sense)
        {
            sense.SubjectStatusLabels = LabelsParser.ParseMultiple<SubjectStatusLabel>(source, "sls");
            sense.GeneralLabels = LabelsParser.ParseMultiple<GeneralLabel>(source, "lbs");
            sense.SenseSpecificGrammaticalLabel = LabelsParser.ParseSingle<SenseSpecificGrammaticalLabel>(source, "sgram");
            
            if (source.TryGetProperty("vrs", out var vrs))
            {
                sense.Variants = new List<Variant>(VariantParser.Parse(vrs));
            }

            if (source.TryGetProperty("prs", out var prs))
            {
                sense.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
            }

            if (source.TryGetProperty("ins", out var ins))
            {
                sense.Inflections = new List<Inflection>(InflectionsParser.Parse(ins));
            }

            if (source.TryGetProperty("et", out var et))
            {
                sense.Etymology = EtymologyParser.Parse(et);
            }
        }

        private static void ParseSpecificSenseProperties(JsonElement source, SenseBase sense)
        {
            var definingTexts = JsonDefiningTextParser.Parse(source);
            sense.DefiningTexts = new List<IDefiningText>(definingTexts);

            if (sense is Sense s)
            {
                foreach (var dt in s.DefiningTexts.OfType<Results.DefiningText>())
                {
                    var text = dt.Text.RawText;
                    var synonyms = SynonymsParser.ExtractSynonyms(text).ToList();
                    if (synonyms.Any())
                    {
                        s.Synonyms = new List<string>(synonyms);
                       
                        // not very robust, but until now I only found sx links at the beginning of a string in the spanish-english dictionary
                        // in that case the synonyms should be removed from the text, in other cases we keep them between square brackets
                         
                        if (text.StartsWith("{sx"))
                        {
                            foreach (var synonym in s.Synonyms)
                            {
                                text = text.Replace(synonym, "");
                            }
                        }
                        else
                        {
                            foreach (var synonym in s.Synonyms)
                            {
                                text = text.Replace(synonym, $"[{synonym}]");
                            }
                        }

                        dt.Text = text;
                    }
                }
            }

            if (source.TryGetProperty("sdsense", out var sdsense))
            {
                var dividedSense = new DividedSense();
                ParseGeneralSenseProperties(sdsense, dividedSense);
                ParseSpecificSenseProperties(sdsense, dividedSense);

                if (sdsense.TryGetProperty("sd", out var sd))
                {
                    dividedSense.SenseDivider = sd.GetString();
                }

                ((Sense)sense).DividedSense = dividedSense;
            }
        }
    }
}