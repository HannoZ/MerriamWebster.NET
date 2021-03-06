﻿using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Parsing.Markup;

namespace MerriamWebster.NET.Parsing
{
    public class SenseParser
    {
        private readonly Response.Definition _def;
        private readonly ParseOptions _parseOptions;
        
        public SenseParser(Response.Definition def, ParseOptions parseOptions)
        {
            _def = def;
            _parseOptions = parseOptions;
        }

        public ICollection<Sense> Parse()
        {
            var senses = new List<Sense>();

            // this is where the magic happens. The actual senses are hidden deep inside a complex structure of multiple nested arrays.
            // code below extracts the data from there
            var sourceSenses = _def.SenseSequences.SelectMany(sseqs => sseqs.Select(sseq => sseq))
                .SelectMany(sseqs => sseqs)
                .Where(sseq => sseq.Sense != null)
                .OrderBy(sseq => sseq.Sense.SenseNumber)
                .Select(sseq => sseq.Sense)
                .Where(s => s.DefiningTexts != null)
                .ToList();

            foreach (var sourceSence in sourceSenses.Where(s => s != null))
            {
                var sense = new Sense();
                foreach (var definingTextObjects in sourceSence.DefiningTexts)
                {
                    if (definingTextObjects.Any(d => d.TypeOrText == "text"))
                    {
                        var definition = definingTextObjects.FirstOrDefault(d => d.TypeOrText != "text");
                        string definitionText = definition.TypeOrText;

                        sense.Synonyms = SynonymsParser.ExtractSynonyms(definitionText).ToList();
                        sense.RawText = definitionText;
                        foreach (var synonym in sense.Synonyms)
                        {
                            definitionText = definitionText.Replace(synonym, "");
                        }

                        sense.Text = _parseOptions.RemoveMarkup
                            ? MarkupRemover.RemoveMarkupFromString(definitionText)
                            : definitionText;

                        if (sourceSence.DividedSense != null)
                        {
                            foreach (var sdDefiningTextObject in sourceSence.DividedSense.DefiningTexts)
                            {
                                if (sdDefiningTextObject.Any(d => d.TypeOrText == "text"))
                                {
                                    var sdDef = sdDefiningTextObject.FirstOrDefault(d => d.TypeOrText != "text");
                                    string sdText = $"{sourceSence.DividedSense.SenseDivider}: {sdDef.TypeOrText}" ;

                                    sense.RawText += $"; {sdText}";
                                    var text = _parseOptions.RemoveMarkup
                                        ? MarkupRemover.RemoveMarkupFromString(sdText)
                                        : sdText;
                                    sense.Text += $"; {text}";
                                }
                            }
                        }
                    }

                    // the vis (verbal illustrations) element contains examples 
                    if (definingTextObjects.Any(d => d.TypeOrText == "vis"))
                    {
                        foreach (var dtWrapper in definingTextObjects.Where(to => to.DefiningTextArray != null))
                        {
                            foreach (var dto in dtWrapper.DefiningTextArray)
                            {
                                if (dto.DefiningText != null)
                                {
                                    var example = new Example
                                    {
                                        RawSentence = dto.DefiningText.Text,
                                        Sentence = _parseOptions.RemoveMarkup ? MarkupRemover.RemoveMarkupFromString(dto.DefiningText.Text) : dto.DefiningText.Text,
                                        Translation = dto.DefiningText.Translation
                                    };
                                    sense.Examples.Add(example);
                                }
                            }
                        }
                    }
                }

                // variants contain an alternative spelling or different way of using the sense and can be treated as examples
                if (sourceSence.Variants.Any())
                {
                    foreach (var variant in sourceSence.Variants)
                    {
                        sense.Examples.Add(new Example
                        {
                            RawSentence = variant.Text,
                            Sentence = _parseOptions.RemoveMarkup ? MarkupRemover.RemoveMarkupFromString(variant.Text) : variant.Text
                        });
                    }
                }

                if (sourceSence.CrossReferences.Any())
                {
                    foreach (var crossReference in sourceSence.CrossReferences.SelectMany(cr=> cr))
                    {
                        sense.CrossReferences.Add(new CrossReference
                        {
                            Target = crossReference.Target,
                            Text = crossReference.Text
                        });
                    }
                }

                senses.Add(sense);
            }

            return senses;
        }
    }
}
