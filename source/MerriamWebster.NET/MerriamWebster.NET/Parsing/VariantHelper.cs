using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse <see cref="Response.Variant"/>
    /// </summary>
    public class VariantHelper
    {
        /// <summary>
        /// Parses the source <see cref="Response.Variant"/> array to <see cref="Variant"/> objects.
        /// </summary>
        public static IEnumerable<Variant> Parse(Response.Variant[] sources, Language language, AudioFormat audioFormat)
        {
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