using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;

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
            var sourceSenses = _def.SenseSequenceObjects.SelectMany(ssObjs => ssObjs.Select(ssObjArray => ssObjArray))
                .SelectMany(ssObjArray => ssObjArray)
                .Where(sso => sso.SenseSequence != null)
                .OrderBy(sso => sso.SenseSequence.SenseNumber)
                .Select(sso => sso.SenseSequence)
                .Where(ss => ss.DefiningTexts != null)
                .ToList();

            foreach (var sourceSence in sourceSenses.Where(ss => ss != null))
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
                    }

                    // the vis (verbal illustrations) element contains examples 
                    if (definingTextObjects.Any(d => d.TypeOrText == "vis"))
                    {
                        foreach (var dto in definingTextObjects.Where(to => to.DefiningTextArray != null))
                        {
                            foreach (var definingText in dto.DefiningTextArray)
                            {
                                var example = new Example
                                {
                                    RawSentence = definingText.Text,
                                    Sentence = _parseOptions.RemoveMarkup ? MarkupRemover.RemoveMarkupFromString(definingText.Text) : definingText.Text,
                                    Translation = definingText.Translation
                                };
                                sense.Examples.Add(example);
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
