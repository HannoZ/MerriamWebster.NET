﻿using System;
using MerriamWebster.NET.Response;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
using Artwork = MerriamWebster.NET.Results.Artwork;

namespace MerriamWebster.NET.Parsing.Content
{
    internal class ArtworkParser : IContentParser
    {
        public void Parse(MwDictionaryEntry source, EntryBase target, ParseOptions options)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));

            if (source.Artwork != null)
            {
                //target.Artwork = new Artwork
                //{
                //    Caption = source.Artwork.Caption,
                //    HtmlLocation = ArtworkLinkCreator.CreatePageLink(source.Artwork),
                //    ImageLocation = ArtworkLinkCreator.CreateDirectLink(source.Artwork)
                //};
            }

        }
    }
}