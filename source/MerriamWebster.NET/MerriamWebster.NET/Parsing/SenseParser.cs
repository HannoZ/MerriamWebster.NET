using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Results;

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
        /// Parses the input definition into a collection of <see cref="Sense"/>s.
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

                                if (sourceSense.CrossReferences.Any())
                                {
                                    sense.CrossReferences = CrossReferenceHelper.Parse(sourceSense.CrossReferences).ToList();
                                }

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

                                if (sourceSense.CrossReferences.Any())
                                {
                                    sense.CrossReferences = CrossReferenceHelper.Parse(sourceSense.CrossReferences).ToList();
                                }

                                senseSequence.Senses.Add(sense);
                            }
                        }
                        else if (sourceSseq[0].Name == Response.SseqEnum.Pseq && sourceSseq[1].SenseSequences != null)
                        {
                            var pseq = new SenseSequenceSense()
                            {
                                IsParenthesizedSenseSequence = true,
                                Senses = new List<SenseSequenceSense>()
                            };

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

                            senseSequence.Senses.Add(pseq);
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

            if (!string.IsNullOrEmpty(sourceSense.SenseSpecificGrammaticalLabel))
            {
                sense.SenseSpecificGrammaticalLabel = sourceSense.SenseSpecificGrammaticalLabel;
            }

            if (sourceSense.Variants.Any())
            {
                sense.Variants = VariantHelper.Parse(sourceSense.Variants, _language, _parseOptions.AudioFormat).ToList();
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
                sense.Etymology = sourceSense.Etymologies.ParseEtymology();
            }
            
            return sense;
        }

        private void ParseSpecificSenseProperties(Response.SenseBase sourceSense, SenseBase targetSense)
        {
            sourceSense.ParseDefiningText(targetSense, _language, _parseOptions.AudioFormat);

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
