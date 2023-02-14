using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    public class CognateCrossReferenceDictionaryEntryMemberParser : IDictionaryEntryMemberParser
    {
        // TODO unit tests

        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "cxs")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            target.CognateCrossReferences = new List<CognateCrossReference>();

            var source = json.Value;
            foreach (var cxs in source.EnumerateArray())
            {
                var crossRef = new CognateCrossReference();
                if (cxs.TryGetProperty("cxl", out var cxl))
                {
                    crossRef.Label = cxl.GetString();
                }

                if (cxs.TryGetProperty("cxtis", out var cxtis))
                {
                    crossRef.CrossReferenceTargets = new List<CrossReferenceTarget>();
                    foreach (var cxti in cxtis.EnumerateArray())
                    {
                        var crossReferenceTarget = new CrossReferenceTarget();
                        if (cxti.TryGetProperty("cxl", out cxl))
                        {
                            crossReferenceTarget.Label = cxl.GetString();
                        }

                        if (cxti.TryGetProperty("cxr", out var cxr))
                        {
                            crossReferenceTarget.TargetId = cxr.GetString();
                        }

                        if (cxti.TryGetProperty("cxt", out var cxt))
                        {
                            crossReferenceTarget.Target = cxt.GetString();
                        }

                        if (cxti.TryGetProperty("cxn", out var cxn))
                        {
                            crossReferenceTarget.SenseNumber = cxn.GetString();
                        }

                        crossRef.CrossReferenceTargets.Add(crossReferenceTarget);
                    }
                }

                target.CognateCrossReferences.Add(crossRef);
            }

        }
    }
}