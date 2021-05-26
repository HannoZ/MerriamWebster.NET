using System;
using MerriamWebster.NET.Response;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Helper class to create links to an artwork file.
    /// </summary>
    public class ArtworkLinkCreator
    {

        /// <summary>
        /// Creates a link to a web page that contains the artwork.
        /// </summary>
        /// <param name="artwork">The artwork object.</param>
        /// <returns>A <see cref="Uri"/> that locates the page.</returns>
        public static Uri CreatePageLink(Artwork artwork)
        {
            if (string.IsNullOrEmpty(artwork?.Id))
            {
                return null;
            }

            return new Uri(string.Format(Configuration.ArtworkHtmlPagePlaceholder, artwork.Id));
        }

        /// <summary>
        /// Creates a direct link to an artwork file.
        /// </summary>
        /// <param name="artwork">The artwork object.</param>
        /// <returns>A <see cref="Uri"/> that locates the file.</returns>
        public static Uri CreateDirectLink(Artwork artwork)
        {
            if (string.IsNullOrEmpty(artwork?.Id))
            {
                return null;
            }

            return new Uri(string.Format(Configuration.ArtworkDirectLinkPlaceholder, artwork.Id));
        }
    }
}