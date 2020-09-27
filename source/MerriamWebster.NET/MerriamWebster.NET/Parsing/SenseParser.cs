using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing
{
    public class SenseParser
    {
        private readonly Definition _def;
        private readonly ParseOptions _parseOptions;
        
        public SenseParser(Definition def, ParseOptions parseOptions)
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

                        sense.Synonyms = SynonymsParser.ExtractSynonyms(definitionText);
                        sense.RawText = definitionText;
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

                if (sourceSence.Variants?.Any() == true)
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

                senses.Add(sense);
            }

            return senses;
        }
    }
}
