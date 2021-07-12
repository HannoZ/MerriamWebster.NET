using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Dto;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to parse defining text properties.
    /// </summary>
    public static class DefiningTextParser
    {
        /// <summary>
        /// Parses the defining text contents from the source sense and stores it on the target sense.
        /// </summary>
        public static void ParseDefiningText(this Response.SenseBase sourceSense, SenseBase targetSense, Language language, AudioFormat audioFormat)
        {
            foreach (var definingTextObjects in sourceSense.DefiningTexts)
            {
                if (definingTextObjects.Length != 2)
                {
                    continue;
                }

                var definitionType = definingTextObjects[0].TypeOrText;

                if (definitionType == DefiningTextTypes.Text)
                {
                    string definitionText = definingTextObjects[1].TypeOrText;

                    if (targetSense is Sense sense)
                    {
                        sense.Synonyms = SynonymsParser.ExtractSynonyms(definitionText).ToList();

                        var definingText = new DefiningText(definitionText);
                        targetSense.DefiningTexts.Add(definingText);
                        if (sense.Synonyms.Any())
                        {
                            // not very robust, but until now I only found sx links at the beginning of a string in the spanish-english dictionary
                            // in that case the synonyms should be removed from the text, in other cases we keep them between square brackets
                            if (definingText.Text.RawText.StartsWith("{sx"))
                            {
                                foreach (var synonym in sense.Synonyms)
                                {
                                    definitionText = definitionText.Replace(synonym, "");
                                }
                            }
                            else
                            {
                                foreach (var synonym in sense.Synonyms)
                                {
                                    definitionText = definitionText.Replace(synonym, $"[{synonym}]");
                                }
                            }
                        }
                    }
                    else
                    {
                        targetSense.DefiningTexts.Add(new DefiningText(definitionText));
                    }
                }
                
                if (definitionType == DefiningTextTypes.VerbalIllustration)
                {
                    foreach (var dto in definingTextObjects[1].DefiningTextObjects)
                    {
                        if (dto.DefiningText != null)
                        {
                            var vis = VisHelper.Parse(dto.DefiningText);
                            targetSense.DefiningTexts.Add(vis);
                        }
                    }
                }

                if (definitionType == DefiningTextTypes.GenderLabel)
                {
                    targetSense.DefiningTexts.Add(new GenderLabel(definingTextObjects[1].TypeOrText));
                }

                if (definitionType == DefiningTextTypes.BiographicalNameWrap)
                {
                    var dt = definingTextObjects[1].DefiningText;

                    var biographicalNameWrap = new BiographicalNameWrap
                    {
                        AlternateName = dt.Altname,
                        FirstName = dt.Pname,
                        Surname = dt.Surname
                    };

                    if (dt.Pronunciations.Any())
                    {
                        biographicalNameWrap.Pronunciations = new List<Pronunciation>();
                        foreach (var pronunciation in dt.Pronunciations)
                        {
                            biographicalNameWrap.Pronunciations.Add(PronunciationHelper.Parse(pronunciation, language, audioFormat));
                        }
                    }

                    targetSense.DefiningTexts.Add(biographicalNameWrap);
                }

                if (definitionType == DefiningTextTypes.CalledAlsoNote)
                {
                    var ca = definingTextObjects[1].DefiningText;
                    var calledAlsoNote = new CalledAlsoNote
                    {
                        Intro = ca.Intro
                    };
                    
                    foreach (var cat in ca.Cats)
                    {
                        calledAlsoNote.Targets.Add(new CalledAlsoTarget
                        {
                            ParenthesizedNumber = cat.ParenthesizedNumber,
                            Reference = cat.Reference,
                            TargetText = cat.Text
                        });
                    }

                    targetSense.DefiningTexts.Add(calledAlsoNote);
                }

                if (definitionType == DefiningTextTypes.RunIn)
                {
                    var arr = definingTextObjects[1].DefiningTextObjects;
                    foreach (var definingTextObject in arr)
                    {
                        var typeOrLabel = definingTextObject.DefiningTextComplexTypeWrappers[0].TypeLabelOrText;
                        if (typeOrLabel == "riw")
                        {
                            var ri = definingTextObject.DefiningTextComplexTypeWrappers[1].RunInWrap;
                            if (ri != null)
                            {
                                var runInWord = new RunInWord
                                {
                                    Text = ri.Text,
                                    RunInEntry = ri.RunInEntry
                                };

                                if (ri.Vrs.Any())
                                {
                                    runInWord.Variants = VariantHelper.Parse(ri.Vrs, language, audioFormat).ToList();
                                }

                                if (ri.Pronunciations.Any())
                                {
                                    runInWord.Pronunciations = new List<Pronunciation>();
                                    foreach (var pronunciation in ri.Pronunciations)
                                    {
                                        runInWord.Pronunciations.Add(PronunciationHelper.Parse(pronunciation, language, audioFormat));
                                    }
                                }

                                targetSense.DefiningTexts.Add(runInWord);
                            }
                        }

                        if (typeOrLabel == DefiningTextTypes.Text)
                        {
                            targetSense.DefiningTexts.Add(new DefiningText(definingTextObject.DefiningTextComplexTypeWrappers[1].TypeLabelOrText));
                        }
                    }
                }

                if (definitionType == DefiningTextTypes.SupplementalNote)
                {
                    var arr = definingTextObjects[1].DefiningTextObjects[0].DefiningTextComplexTypeWrappers;
                    var supplementalInformationNote = new SupplementalInformationNote
                    {
                        Text = arr[1].TypeLabelOrText
                    };

                    targetSense.DefiningTexts.Add(supplementalInformationNote);
                    
                    // todo nested ri, vis, requires sample json 
                }

                if (definitionType == DefiningTextTypes.UsageNote)
                {
                    var arr = definingTextObjects[1].DefiningTextObjects[0].DefiningTextComplexTypeWrappers;
                    if (arr == null){ continue;}

                    var un = new UsageNote();

                    foreach (var dtWrapper in arr.Where(x=>x.DefiningTextComplexTypes?.Any() == true))
                    {
                        var unType = dtWrapper.DefiningTextComplexTypes[0].TypeOrLabel;
                        if (unType == DefiningTextTypes.Text)
                        {
                            un.Text = dtWrapper.DefiningTextComplexTypes[1].TypeOrLabel;
                        }
                        else if (unType == DefiningTextTypes.VerbalIllustration)
                        {
                            if (un.VerbalIllustrations == null)
                            {
                                un.VerbalIllustrations = new List<VerbalIllustration>();
                            }

                            foreach (var definingText in dtWrapper.DefiningTextComplexTypes[1].DtClassArray)
                            {
                                var vis = VisHelper.Parse(definingText);
                                un.VerbalIllustrations.Add(vis);
                            }
                        }

                        // todo "ri", requires sample json 
                    }
                    
                    targetSense.DefiningTexts.Add(un);
                }

            }

        }
    }
}