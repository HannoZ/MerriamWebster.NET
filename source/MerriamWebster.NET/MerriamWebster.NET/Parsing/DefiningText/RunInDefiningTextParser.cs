using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    public class RunInDefiningTextParser : IDefiningTextParser
    {
        public IDefiningText Parse(JsonElement source)
        {
            var runIn = new RunIn();
            foreach (var ri in source.EnumerateArray())
            {
                var items = ri.EnumerateArray().ToList();
                var type = items[0].GetString();
           
                var wrap = new RunInWrap();

                if (type == "riw")
                {
                    var riw = items[1];
                    var rie = JsonParserHelper.GetStringValue(riw, "rie");
                    if (rie != null)
                    {
                        wrap.RunInEntryWord = rie;
                    }

                    if (riw.TryGetProperty("prs", out var prs))
                    {
                        wrap.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
                    }

                    // not sure if the variants occur as part of the run-in wrap, or as part of the run-in itself
                    if (riw.TryGetProperty("vrs", out var vrs))
                    {
                        wrap.Variants = new List<Variant>(VariantParser.Parse(vrs));
                    }
                }
                else if (type == "text")
                {
                    var text = items[1].GetString();
                    if (text != null)
                    {
                        wrap.Text = text;
                    }
                }

                runIn.Wraps.Add(wrap);
            }

            return runIn;
        }
    }
}