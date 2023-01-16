using System;
using System.Collections.Generic;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    public class PronuncationParser
    {
        public static IEnumerable<Pronunciation> Parse(JsonElement sourceElement)
        {
            if (sourceElement.ValueKind != JsonValueKind.Array)
            {
                throw new ArgumentException("The provided JSON must be an array of pronuncation objects");
            }

            foreach (var pr in sourceElement.EnumerateArray())
            {
                var pronunciation = new Pronunciation();

                if (pr.TryGetProperty("sound", out var sound))
                {
                    pronunciation.AudioLink = AudioLinkCreator.CreateLink(sound);
                }

                if (pr.TryGetProperty("ipa", out var ipa))
                {
                    pronunciation.Ipa = ipa.GetString();
                }

                if (pr.TryGetProperty("wod", out var wod))
                {
                    pronunciation.Wod = wod.GetString();
                }

                if (pr.TryGetProperty("mw", out var mw))
                {
                    pronunciation.WrittenPronunciation = mw.GetString();
                }

                if (pr.TryGetProperty("l", out var l))
                {
                    pronunciation.LabelBeforePronunciation = l.GetString();
                }

                if (pr.TryGetProperty("l2", out var l2))
                {
                    pronunciation.LabelAfterPronunciation = l2.GetString();
                }

                if (pr.TryGetProperty("pun", out var pun))
                {
                    pronunciation.Punctuation = pun.GetString();
                }

                yield return pronunciation;
            }
        }
    }
}