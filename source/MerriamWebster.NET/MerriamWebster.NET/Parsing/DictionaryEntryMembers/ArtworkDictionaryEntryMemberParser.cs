using System;
using System.Text.Json;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    internal class ArtworkDictionaryEntryMemberParser :  IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, Entry target)
        {
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (json.Name != "art")
            {
                throw new ArgumentException($"Cannot handle json object {json.Name}", nameof(json));
            }

            var source = json.Value;
            var artId = JsonParserHelper.GetStringValue(source, "artid");

            var artwork = new Artwork
            {
                Caption = JsonParserHelper.GetStringValue(source, "capt") ?? string.Empty,
                HtmlLocation = ArtworkLinkCreator.CreatePageLink(artId),
                ImageLocation = ArtworkLinkCreator.CreateDirectLink(artId)
            };

            target.Artwork = artwork;
        }

    }
}