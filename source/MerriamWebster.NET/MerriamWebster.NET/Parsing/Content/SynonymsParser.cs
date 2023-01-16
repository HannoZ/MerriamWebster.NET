using System;
using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using DefiningText = MerriamWebster.NET.Results.DefiningText;
using Synonym = MerriamWebster.NET.Results.Synonym;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class SynonymsParser : IContentParser
    {
        public void Parse(MwDictionaryEntry source, EntryBase target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (source.Synonyms.HasValue())
            {
               // target.Synonyms = ParseSynonyms().ToList();
            }


            IEnumerable<Synonym> ParseSynonyms()
            {
                foreach (var srcSynonym in source.Synonyms)
                {
                    var synonym = new Synonym
                    {
                        ParagraphLabel = srcSynonym.Pl
                    };

                    if (srcSynonym.Sarefs?.Any() == true)
                    {
                        synonym.SeeInAdditionReference = new List<string>(srcSynonym.Sarefs);
                    }

                    foreach (var dt in srcSynonym.Pt)
                    {
                        if (dt[0].TypeLabelOrText == DefiningTextTypes.Text)
                        {
                            synonym.DefiningTexts.Add(new DefiningText(dt[1].TypeLabelOrText));
                        }
                        else if (dt[0].TypeLabelOrText == DefiningTextTypes.VerbalIllustration)
                        {
                            foreach (var dtc in dt[1].DefiningTextComplexTypes)
                            {
                                synonym.DefiningTexts.Add(VisHelper.Parse(dtc.DefiningText));
                            }
                        }
                    }

                    yield return synonym;
                }
            }
        }


    }
}