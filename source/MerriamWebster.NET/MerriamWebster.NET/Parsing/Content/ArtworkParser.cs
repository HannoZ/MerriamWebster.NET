using System;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using Artwork = MerriamWebster.NET.Results.Artwork;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class ArtworkParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (source.Artwork != null)
            {
                target.Artwork = new Artwork
                {
                    Caption = source.Artwork.Caption,
                    HtmlLocation = ArtworkLinkCreator.CreatePageLink(source.Artwork),
                    ImageLocation = ArtworkLinkCreator.CreateDirectLink(source.Artwork)
                };
            }

            return target;
        }
    }
}