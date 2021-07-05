using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A reference from an entry to a table.
    /// </summary>
    /// <remarks>
    ///A table reference URL should be in the following form: https://www.merriam-webster.com/table/collegiate/[base filename].htm where [base filename] equals the value of tableid
    /// </remarks>
    public class Table
    {
        /// <summary>
        /// ID of the target table.
        /// </summary>
        [JsonProperty("tableid")]
        public string Tableid { get; set; }
        /// <summary>
        ///  Text to display in table link.
        /// </summary>
        [JsonProperty("displayname")]
        public string Displayname { get; set; }
    }
}