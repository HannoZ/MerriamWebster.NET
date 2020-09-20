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
                .Where(ss => ss.Definitions != null)
                .ToList();

            foreach (var sourceSence in sourceSenses.Where(ss => ss != null))
            {
                var sense = new Sense();
                foreach (var translationObjects in sourceSence.Definitions)
                {
                    if (translationObjects.Any(d => d.String == "text"))
                    {
                        var translationObject = translationObjects.First(d => d.String != "text");
                        var translation = translationObject.String;

                        sense.Synonyms = SynonymsParser.ExtractSynonyms(translation);

                        sense.RawTranslation = translation;
                        sense.Translation = _parseOptions.RemoveMarkup
                            ? MarkupRemover.RemoveMarkupFromString(translation)
                            : translation;
                    }

                    if (translationObjects.Any(d => d.String == "vis"))
                    {
                        foreach (var translationObject in translationObjects.Where(to => to.TranslationClassArray != null))
                        {
                            foreach (var translationClass in translationObject.TranslationClassArray)
                            {
                                var example = new Example
                                {
                                    Sentence = translationClass.Text,
                                    Translation = translationClass.Translation
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
                            Sentence = variant.Text
                        });
                    }
                }

                senses.Add(sense);
            }

            return senses;
        }
    }
}
