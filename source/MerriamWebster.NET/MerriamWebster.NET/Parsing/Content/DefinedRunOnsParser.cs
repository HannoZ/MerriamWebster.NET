//using System;
//using System.Collections.Generic;
//using System.Linq;
//using MerriamWebster.NET.Response;
//using MerriamWebster.NET.Results;
//using MerriamWebster.NET.Results.Base;
//using DefinedRunOn = MerriamWebster.NET.Results.DefinedRunOn;
//using Definition = MerriamWebster.NET.Results.Definition;

//namespace MerriamWebster.NET.Parsing.Content
//{
//    internal class DefinedRunOnsParser : IContentParser
//    {
//        public void Parse(MwDictionaryEntry source, EntryBase target, ParseOptions options)
//        {
//            ArgumentNullException.ThrowIfNull(source, nameof(source));
//            ArgumentNullException.ThrowIfNull(target, nameof(target));
//            ArgumentNullException.ThrowIfNull(options, nameof(options));

//            // parse and add any additional results (they appear in the 'DefinedRunOns' ('dro') property)
//            if (!source.DefinedRunOns.HasValue())
//            {
//                return;
//            }

//            target.DefinedRunOns = new List<DefinedRunOn>();
                
//            foreach (var dro in source.DefinedRunOns)
//            {
//                var searchResult = new DefinedRunOn
//                {
//                    Phrase = dro.Phrase,
//                    FunctionalLabel = dro.FunctionalLabel,
//                    ParenthesizedSubjectStatusLabel = dro.ParenthesizedSubjectStatusLabel,
//                };

//                if (dro.GeneralLabels.Any())
//                {
//                    searchResult.GeneralLabels = new List<Label>();
//                    foreach (var generalLabel in dro.GeneralLabels)
//                    {
//                        searchResult.GeneralLabels.Add(generalLabel);
//                    }
//                }

//                if (dro.Sls.Any())
//                {
//                    searchResult.SubjectStatusLabels = new List<Label>();
//                    foreach (var sls in searchResult.SubjectStatusLabels)
//                    {
//                        searchResult.SubjectStatusLabels.Add(sls);
//                    }
//                }

//                foreach (var droDef in dro.Definitions)
//                {
//                    var senseParser = new SenseParser(droDef, Language.NotApplicable, options);
//                    var def = new Definition();
//                    senseParser.Parse(def);

//                    searchResult.Definitions.Add(def);
//                }

//                if (dro.Et.Any())
//                {
//                    searchResult.Etymology = dro.Et.ParseEtymology();
//                }

//                if (dro.Vrs.Any())
//                {
//                    searchResult.Variants = VariantHelper.Parse(dro.Vrs, Language.NotApplicable, options.AudioFormat).ToList();
//                }

//                target.DefinedRunOns.Add(searchResult);
//            }
            
//        }
//    }
//}