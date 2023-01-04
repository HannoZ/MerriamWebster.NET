using System;
using System.Collections.Generic;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using DefiningText = MerriamWebster.NET.Results.DefiningText;
using Usage = MerriamWebster.NET.Results.Usage;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class UsagesParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (!source.Usages.HasValue())
            {
                return target;
            }
            
            target.Usages = new List<Usage>();
            foreach (var srcUsage in source.Usages)
            {
                var usage = new Usage
                {
                    ParagraphLabel = srcUsage.ParagraphLabel
                };

                foreach (var complexTypeWrapper in srcUsage.ParagraphText)
                {
                    var type = complexTypeWrapper[0].TypeLabelOrText;
                    if (type == DefiningTextTypes.Text)
                    {
                        usage.ParagraphTexts.Add(new DefiningText(complexTypeWrapper[1].TypeLabelOrText));
                    }
                    else if (type == DefiningTextTypes.VerbalIllustration)
                    {
                        foreach (var dt in complexTypeWrapper[1].DefiningTextComplexTypes)
                        {
                            usage.ParagraphTexts.Add(VisHelper.Parse(dt.DefiningText));
                        }
                    }
                    else if (type == DefiningTextTypes.InAdditionReference)
                    {
                        // TODO, requires sample json
                    }
                }

                target.Usages.Add(usage);
            }

            return target;
        }
    }
}