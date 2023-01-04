using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    internal class VariantHelper
    {
        public static IEnumerable<Variant> Parse(Response.Variant[] sources, Language language, AudioFormat audioFormat)
        {
            if (!sources.HasValue())
            {
                 yield break; 
            }

            foreach (var source in sources)
            {
                var variant = new Variant
                {
                    Cutback = source.Cutback,
                    Label = source.VariantLabel,
                    SenseSpecificInflectionPluralLabel = source.SenseSpecificInflectionPluralLabel,
                    Text = source.Text
                };

                if (source.Pronunciations.Any())
                {
                    variant.Pronunciations = new List<Pronunciation>();
                    foreach (var pronunciation in source.Pronunciations)
                    {
                        variant.Pronunciations.Add(PronunciationHelper.Parse(pronunciation, language, audioFormat));
                    }
                }

                yield return variant;
            }
        }
    }
}