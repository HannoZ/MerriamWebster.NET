using System;

namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// Entries may have illustrations to provide a visual depiction of the headword.
    /// </summary>
    public class Artwork
    {
        /// <summary>
        /// The image caption.
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// A direct link to the image.
        /// </summary>
        public Uri ImageLocation { get; set; }
        /// <summary>
        /// Location of the page that contains this image.
        /// </summary>
        public Uri HtmlLocation { get; set; }
    }
}