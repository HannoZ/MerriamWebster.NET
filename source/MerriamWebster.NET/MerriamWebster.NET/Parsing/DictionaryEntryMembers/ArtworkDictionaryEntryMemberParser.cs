using System;
using System.Text.Json;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;

namespace MerriamWebster.NET.Parsing.DictionaryEntryMembers
{
    internal class ArtworkDictionaryEntryMemberParser :  IDictionaryEntryMemberParser
    {
        public void Parse(JsonProperty json, EntryBase target)
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
                Caption = JsonParserHelper.GetStringValue(source, "capt"),
                HtmlLocation = ArtworkLinkCreator.CreatePageLink(artId),
                ImageLocation = ArtworkLinkCreator.CreateDirectLink(artId)
            };

            target.Artwork = artwork;
        }

    }
}