using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    internal class InflectionHelper
    {
        public static IEnumerable<Inflection> Parse(Response.Inflection[] sources, Language language, AudioFormat audioFormat)
        {
            foreach (var source in sources)
            {
                var inflection = new Inflection
                {
                    Label = source.Label,
                    Cutback = source.Cutback,
                    Value = source.Value,
                    SenseSpecificInflectionPluralLabel = source.SenseSpecificInflectionPluralLabel
                };

                if (source.Pronunciations.Any())
                {
                    inflection.Pronunciations = new List<Pronunciation>();
                    foreach (var pronunciation in source.Pronunciations)
                    {
                        inflection.Pronunciations.Add(PronunciationHelper.Parse(pronunciation, language, audioFormat));
                    }
                }

                if (source.Alternate != null)
                {
                    inflection.Alternate = new AlternateInflection
                    {
                        Cutback = source.Alternate.Cutback,
                        Inflection = source.Alternate.Inflection
                    };
                }

                yield return inflection;
            }
        }
    }
}