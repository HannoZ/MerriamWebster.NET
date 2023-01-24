using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Medical;

namespace MerriamWebster.NET.Parsing.DefiningText
{
    public class BiographicalNameWrapDefiningTextParser : IDefiningTextParser
    {
        public IDefiningText Parse(JsonElement source)
        {
            var biographicalNameWrap = new BiographicalNameWrap
            {
                FirstName = JsonParserHelper.GetStringValue(source, "pname"),
                Surname = JsonParserHelper.GetStringValue(source, "sname"),
                AlternateName = JsonParserHelper.GetStringValue(source, "altname"),
            };

            if (source.TryGetProperty("prs", out var prs))
            {
                biographicalNameWrap.Pronunciations = new List<Pronunciation>(PronunciationParser.Parse(prs));
            }

            return biographicalNameWrap;
        }
    }
}