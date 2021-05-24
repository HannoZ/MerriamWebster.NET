using System.Collections.Generic;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <remarks>
    /// Prefixed List with 'Mw' (Merriam-Webster) to avoid confusion with the .NET BCL <see cref="List{T}"/> class.
    /// </remarks>
    public class MwList
    {
        [JsonProperty("wd")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string Word { get; set; }

        [JsonProperty("wvrs", NullValueHandling = NullValueHandling.Ignore)]
        public WordVariant[] Variants { get; set; } = { };

        [JsonProperty("wsls", NullValueHandling = NullValueHandling.Ignore)]
        public WordSubjectStatusLabel SubjectStatusLabel { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}