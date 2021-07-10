using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Parsing.Markup;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// The <see cref="SenseParser"/> class does the heavy-lifting of peeling the senses out of a <see cref="Response.Definition"/>.
    /// </summary>
    public class SenseParser
    {
        private readonly Response.Definition _def;
        private readonly Language _language;
        private readonly ParseOptions _parseOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="SenseParser"/> class.
        /// </summary>
        /// <param name="def">The definition object to parse.</param>
        /// <param name="language">The language from metadata</param>
        /// <param name="parseOptions">The parse options.</param>
        public SenseParser(Response.Definition def, Language language, ParseOptions parseOptions)
        {
            _def = def;
            _language = language;
            _parseOptions = parseOptions;
        }

        /// <summary>
        /// Parses the input definition into a collection of <see cref="Dto.Sense"/>s.
        /// </summary>
        public void Parse(Definition definition)
        {
            if (definition == null)
            {
                return;
            }

            foreach (var sourceSseqs in _def.SenseSequences)
            {
                var senseSequence = new SenseSequence();

                foreach (var sourceSseq in sourceSseqs)
                {
                    // sourceSseq comes in pairs: a string that defines the object ("sense", "sen", "pseq", etc.) , followed by the actual object
                    if (sourceSseq.Length == 2)
                    {
                        if (sourceSseq[0].Name == Response.SseqEnum.Bs)
                        {
                            var sourceSense = sourceSseq[1].Sense;

                            // a binding substitute (bs) should always contain a nested sense object  
                            if (sourceSense?.SubSense != null)
                            {
                                var sense = ParseGeneralSenseProperties<Sense>(sourceSense.SubSense);
                                sense.SenseNumber = sourceSense.SubSense.SenseNumber;
                                ParseSpecificSenseProperties(sourceSense.SubSense, sense);
                                sense.IsBindingSubstitute = true;

                                senseSequence.Senses.Add(sense);
                            }
                        }

                        if (sourceSseq[0].Name == Response.SseqEnum.Sense)
                        {
                            var sourceSense = sourceSseq[1].Sense;
                            if (sourceSense != null)
                            {

                                var sense = ParseGeneralSenseProperties<Sense>(sourceSense);
                                sense.SenseNumber = sourceSense.SenseNumber;
                                ParseSpecificSenseProperties(sourceSense, sense);
                                
                                senseSequence.Senses.Add(sense);
                            }
                        }
                        else if (sourceSseq[0].Name == Response.SseqEnum.Sen)
                        {
                            var sourceSense = sourceSseq[1].Sense;
                            if (sourceSense != null)
                            {
                                var sense = ParseGeneralSenseProperties<Sense>(sourceSense);
                                sense.SenseNumber = sourceSense.SenseNumber;
                                sense.IsTruncatedSense = true;

                                senseSequence.Senses.Add(sense);
                            }
                        }
                        else if (sourceSseq[0].Name == Response.SseqEnum.Pseq && sourceSseq[1].SenseSequences != null)
                        {
                            var pseq = new SenseSequence();
                            if (senseSequence.ParenthesizedSenseSequence == null)
                            {
                                senseSequence.ParenthesizedSenseSequence = new List<SenseSequence>();
                            }
                            foreach (var sourceSequence in sourceSseq[1].SenseSequences)
                            {
                                if (sourceSequence[0].Name == Response.SseqEnum.Bs)
                                {
                                    var sourceSense = sourceSequence[1].Sense;

                                    // a binding substitute (bs) should always contain a nested sense object  
                                    if (sourceSense?.SubSense != null)
                                    {
                                        var sense = ParseGeneralSenseProperties<Sense>(sourceSense.SubSense);
                                        sense.SenseNumber = sourceSense.SubSense.SenseNumber;
                                        ParseSpecificSenseProperties(sourceSense.SubSense, sense);
                                        sense.IsBindingSubstitute = true;

                                        pseq.Senses.Add(sense);
                                    }
                                }

                                if (sourceSequence[0].Name == Response.SseqEnum.Sense)
                                {
                                    var sourceSense = sourceSequence[1].Sense;
                                    if (sourceSense != null)
                                    {
                                        var sense = ParseGeneralSenseProperties<Sense>(sourceSense);
                                        sense.SenseNumber = sourceSense.SenseNumber;
                                        ParseSpecificSenseProperties(sourceSense, sense);
                                        
                                        pseq.Senses.Add(sense);
                                    }
                                }

                            }

                            senseSequence.ParenthesizedSenseSequence.Add(pseq);
                        }


                    }
                    // else? 
                    //sourceSseq.Length != 2, should not occur
                }

                definition.SenseSequence.Add(senseSequence);
            }
        }

        /// <summary>
        /// Creates a new sense instance from a source sense with properties that occur on all sense types.
        /// </summary>
        private T ParseGeneralSenseProperties<T>(Response.SenseBase sourceSense)
            where T : SenseBase, new()
        {
            var sense = new T();

            if (sourceSense.GeneralLabels.Any())
            {
                sense.GeneralLabels = new List<Label>();
                foreach (var generalLabel in sourceSense.GeneralLabels)
                {
                    sense.GeneralLabels.Add(generalLabel);
                }
            }

            if (sourceSense.SubjectStatusLabels.Any())
            {
                sense.SubjectStatusLabels = new List<Label>();
                foreach (var subjectStatusLabel in sourceSense.SubjectStatusLabels)
                {
                    sense.SubjectStatusLabels.Add(subjectStatusLabel);
                }
            }

            if (sourceSense.Variants.Any())
            {
                sense.Variants = new List<Variant>();

                foreach (var sourceVar in sourceSense.Variants)
                {
                    //sense.VerbalIllustrations.Add(new VerbalIllustration
                    //{
                    //    RawSentence = variant.Text,
                    //    Sentence = _parseOptions.RemoveMarkup ? MarkupManipulator.RemoveMarkupFromString(variant.Text) : variant.Text,
                    //    HtmlSentence = _parseOptions.RemoveMarkup ? MarkupManipulator.ReplaceMarkupInString(variant.Text) : variant.Text
                    //});

                    var variant = new Variant
                    {
                        Cutback = sourceVar.Cutback,
                        Text = sourceVar.Text,
                        Label = sourceVar.VariantLabel,
                        SenseSpecificInflectionPluralLabel = sourceVar.SenseSpecificInflectionPluralLabel
                    };

                    if (sourceVar.Pronunciations.Any())
                    {
                        variant.Pronunciations = new List<Pronunciation>();
                        foreach (var pronunciation in sourceVar.Pronunciations)
                        {
                            variant.Pronunciations.Add(PronunciationHelper.Parse(pronunciation, _language, _parseOptions.AudioFormat));
                        }
                    }

                    sense.Variants.Add(variant);
                }
            }

            if (sourceSense.Pronunciations.Any())
            {
                sense.Pronunciations = new List<Pronunciation>();
                foreach (var pronunciation in sourceSense.Pronunciations)
                {
                    sense.Pronunciations.Add(PronunciationHelper.Parse(pronunciation, _language, _parseOptions.AudioFormat));
                }
            }

            if (sourceSense.Inflections.Any())
            {
                sense.Inflections = InflectionHelper.Parse(sourceSense.Inflections, _language, _parseOptions.AudioFormat).ToList();
            }

            if (sourceSense.Etymologies.Any())
            {
                sense.Etymology = EtymologyHelper.Parse(sourceSense.Etymologies, _parseOptions);
            }

            // todo  sgram


            return sense;
        }

        public void ParseSpecificSenseProperties(Response.SenseBase sourceSense, SenseBase targetSense)
        {
            foreach (var definingTextObjects in sourceSense.DefiningTexts)
            {
                if (definingTextObjects.Any(d => d.TypeOrText == "text"))
                {
                    var definition = definingTextObjects.FirstOrDefault(d => d.TypeOrText != "text");
                    string definitionText = definition.TypeOrText;

                    if (targetSense is Sense sense)
                    {
                        sense.Synonyms = SynonymsParser.ExtractSynonyms(definitionText).ToList();

                        targetSense.DefiningText = new FormattedText(definitionText, _parseOptions);
                        if (sense.Synonyms.Any())
                        {
                            // not very robust, but until now I only found sx links at the beginning of a string in the spanish-english dictionary
                            // in that case the synonyms should be removed from the text, in other cases we keep them between square brackets
                            if (sense.DefiningText.RawText.StartsWith("{sx"))
                            {
                                foreach (var synonym in sense.Synonyms)
                                {
                                    definitionText = definitionText.Replace(synonym, "");
                                }
                            }
                            else
                            {
                                foreach (var synonym in sense.Synonyms)
                                {
                                    definitionText = definitionText.Replace(synonym, $"[{synonym}]");
                                }
                            }
                        }
                    }
                    else
                    {
                        targetSense.DefiningText = new FormattedText(definitionText, _parseOptions);
                    }
                }

                // the vis (verbal illustrations) element contains examples or other text that furhter illustrates the definition
                if (definingTextObjects.Any(d => d.TypeOrText == "vis"))
                {
                    if (targetSense.VerbalIllustrations == null)
                    {
                        targetSense.VerbalIllustrations = new List<VerbalIllustration>();
                    }

                    foreach (var dtWrapper in definingTextObjects.Where(to => to.DefiningTextArray != null))
                    {
                        foreach (var dto in dtWrapper.DefiningTextArray)
                        {
                            if (dto.DefiningText != null)
                            {
                                var text = dto.DefiningText.Text;
                                var example = new VerbalIllustration
                                {
                                    Sentence = new FormattedText(text, _parseOptions)
                                };

                                var aq = dto.DefiningText.Quote;
                                if (aq != null)
                                {
                                    example.AttributionOfQuote = new AttributionOfQuote
                                    {
                                        Author = aq.Author,
                                        PublicationDate = aq.PublicationDate,
                                        Source = aq.Source
                                    };

                                    if (aq.Subsource != null)
                                    {
                                        example.AttributionOfQuote.Subsource = new SubSource
                                        {
                                            PublicationDate = aq.Subsource.PublicationDate,
                                            Source = aq.Subsource.Source
                                        };
                                    }
                                }

                                targetSense.VerbalIllustrations.Add(example);
                            }
                        }
                    }
                }
            }

            // sdsense
            if (sourceSense is Response.Sense s && s.DividedSense != null)
            {
                var dSense = ParseGeneralSenseProperties<DividedSense>(s.DividedSense);
                ParseSpecificSenseProperties(s.DividedSense, dSense);
                dSense.SenseDivider = s.DividedSense.SenseDivider;

                ((Sense)targetSense).DividedSense = dSense;
            }
        }
    }
}
