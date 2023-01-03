using System;
using MerriamWebster.NET.Dto;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class ArtworkParser : IContentParser
    {
        public Entry Parse(MwDictionaryEntry source, Entry target, ParseOptions options)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (source.Artwork != null)
            {
                target.Artwork = new Dto.Artwork
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