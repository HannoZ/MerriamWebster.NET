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
        private readonly ParseOptions _parseOptions;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SenseParser"/> class.
        /// </summary>
        /// <param name="def">The definition object to parse.</param>
        /// <param name="parseOptions">The parse options.</param>
        public SenseParser(Response.Definition def, ParseOptions parseOptions)
        {
            _def = def;
            _parseOptions = parseOptions;
        }

        /// <summary>
        /// Parses the input definition into a collection of <see cref="Sense"/>s.
        /// </summary>
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
                            ? MarkupManipulator.RemoveMarkupFromString(definitionText)
                            : definitionText;
                        sense.HtmlText = _parseOptions.ReplaceMarkup
                            ? MarkupManipulator.ReplaceMarkupInString(definitionText)
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
                                        ? MarkupManipulator.RemoveMarkupFromString(sdText)
                                        : sdText;
                                    sense.Text += $"; {text}";

                                    var htmlText = _parseOptions.ReplaceMarkup
                                        ? MarkupManipulator.ReplaceMarkupInString(sdText)
                                        : sdText;
                                    sense.HtmlText += $"; {htmlText}";
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
                                    var text = dto.DefiningText.Text;
                                    var example = new Example
                                    {
                                        RawSentence = text,
                                        Sentence = _parseOptions.RemoveMarkup ? MarkupManipulator.RemoveMarkupFromString(text) : text,
                                        HtmlSentence = _parseOptions.ReplaceMarkup ? MarkupManipulator.ReplaceMarkupInString(text) : text,
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
                            Sentence = _parseOptions.RemoveMarkup ? MarkupManipulator.RemoveMarkupFromString(variant.Text) : variant.Text,
                            HtmlSentence = _parseOptions.RemoveMarkup ? MarkupManipulator.ReplaceMarkupInString(variant.Text) : variant.Text
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

                if (sourceSence.SubjectStatusLabels.Any())
                {
                    sense.AdditionalInformation = sourceSence.SubjectStatusLabels.ToList();
                }

                senses.Add(sense);
            }

            return senses;
        }
    }
}
