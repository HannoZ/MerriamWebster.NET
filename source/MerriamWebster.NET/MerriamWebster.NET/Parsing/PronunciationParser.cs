using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    public class PronunciationParser
    {
        public static IEnumerable<Pronunciation> Parse(JsonElement sourceElement)
        {
            if (sourceElement.ValueKind != JsonValueKind.Array)
            {
                throw new ArgumentException("The provided JSON must be an array of pronuncation objects");
            }

            foreach (var pr in sourceElement.EnumerateArray())
            {
                var pronunciation = new Pronunciation
                {
                    Ipa = JsonParserHelper.GetStringValue(pr, "ipa"),
                    Wod = JsonParserHelper.GetStringValue(pr, "wod"),
                    WrittenPronunciation = JsonParserHelper.GetStringValue(pr, "mw") ?? string.Empty,
                    LabelBeforePronunciation = JsonParserHelper.GetStringValue(pr, "l"),
                    LabelAfterPronunciation = JsonParserHelper.GetStringValue(pr, "l2"),
                    Punctuation = JsonParserHelper.GetStringValue(pr, "pun")
                };

                if (pr.TryGetProperty("sound", out var sound))
                {
                    pronunciation.AudioLink = AudioLinkCreator.CreateLink(sound);
                }

                yield return pronunciation;
            }
        }
    }
}