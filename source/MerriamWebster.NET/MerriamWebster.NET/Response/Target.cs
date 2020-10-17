using System;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// Matching target entry in other Merriam-Webster data set.
    /// </summary>
    public class Target
    {
        /// <summary>
        ///  Target entry universally unique identifier.
        /// </summary>
        [JsonProperty("tuuid")]
        public Guid Identifier { get; set; }

        /// <summary>
        /// Target entry source data set.
        /// </summary>
        [JsonProperty("tsrc")]
        public string Source { get; set; }
    }
}