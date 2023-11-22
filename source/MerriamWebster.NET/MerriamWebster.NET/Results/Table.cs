using System;

namespace MerriamWebster.NET.Results
{
    /// <summary>
    /// A reference from an entry to a table
    /// </summary>
    /// <remarks>
    /// <b>Display Guidance:</b>
    /// Typically presented as a link in a separate paragraph, where the link text is provided by <see cref="Displayname"/>.
    /// The table is generally presented as an image on a separate page.
    /// </remarks>
    public class Table
    {
        private const string BaseUri = "https://www.merriam-webster.com/table/collegiate/{0}.htm";

        /// <summary>
        /// ID of the target table. 
        /// </summary>
        /// <remarks>For internal use</remarks>
        public string? TableId { get; set; }
        /// <summary>
        ///  Text to display in table link.
        /// </summary>
        public FormattedText? Displayname { get; set; }

        /// <summary>
        /// Gets the location of the table, based on the <see cref="TableId"/>.
        /// </summary>
        public Uri? TableLocation => !string.IsNullOrEmpty(TableId) ? new Uri(string.Format(BaseUri, TableId)) : null;
    }
}