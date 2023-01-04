using System;
using System.Collections.Generic;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using CognateCrossReference = MerriamWebster.NET.Results.CognateCrossReference;
using CrossReferenceTarget = MerriamWebster.NET.Results.CrossReferenceTarget;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class CognateCrossReferenceParser : IContentParser
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

            if (!source.CognateCrossReferences.HasValue())
            {
                return target;
            }

            target.CognateCrossReferences = new List<CognateCrossReference>(source.CognateCrossReferences.Length);

            foreach (var sourceCr in source.CognateCrossReferences)
            {
                var targetCr = new CognateCrossReference
                {
                    Label = sourceCr.Label
                };

                foreach (var crossReferenceTarget in sourceCr.CrossReferenceTargets)
                {
                    targetCr.CrossReferenceTargets.Add(new CrossReferenceTarget
                    {
                        Target = crossReferenceTarget.Target,
                        Label = crossReferenceTarget.Label,
                        TargetId = crossReferenceTarget.TargetId,
                        SenseNumber = crossReferenceTarget.SenseNumber
                    });
                }

                target.CognateCrossReferences.Add(targetCr);
            }

            return target;
        }
    }
}