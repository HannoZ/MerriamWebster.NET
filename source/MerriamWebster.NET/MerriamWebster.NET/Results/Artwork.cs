using System;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// Entries may have illustrations to provide a visual depiction of the headword.
    /// All information needed to display an image is contained in this class.
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// <para>
    /// When displaying an image on a page, it is typically preceded by lead-in text such as "Illustration of [headword]".
    /// </para>
    /// </remarks>
    public class Artwork
    {
        /// <summary>
        /// The image caption text.
        /// </summary>
        public string? Caption { get; set; }
        /// <summary>
        /// A direct link to the image.
        /// </summary>
        public Uri? ImageLocation { get; set; }
        /// <summary>
        /// Location of the page that contains this image.
        /// </summary>
        public Uri? HtmlLocation { get; set; }
    }
}