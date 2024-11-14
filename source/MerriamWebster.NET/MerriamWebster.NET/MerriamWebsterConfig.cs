namespace MerriamWebster.NET
{
    /// <summary>
    /// A simple POCO class to hold configuration values.
    /// </summary>
    public class MerriamWebsterConfig
    {
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether to include the raw JSON response. Default value is <c>false</c>.
        /// </summary>
        public bool IncludeRawResponse { get; set; } = false;
    }
}
