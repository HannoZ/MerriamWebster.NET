using System;

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
        /// <param name="id">The artwork id.</param>
        /// <returns>A <see cref="Uri"/> that locates the page.</returns>
        public static Uri? CreatePageLink(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return new Uri(string.Format(Configuration.ArtworkHtmlPagePlaceholder, id));
        }

        /// <summary>
        /// Creates a direct link to an artwork file.
        /// </summary>
        /// <param name="id">The artwork id.</param>
        /// <returns>A <see cref="Uri"/> that locates the file.</returns>
        public static Uri? CreateDirectLink(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return new Uri(string.Format(Configuration.ArtworkDirectLinkPlaceholder, id));
        }
    }
}