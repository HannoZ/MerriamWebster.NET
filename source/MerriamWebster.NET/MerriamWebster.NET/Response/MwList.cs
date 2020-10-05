using System.Collections.Generic;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <remarks>
    /// Prefixed List with 'Mw' (Merriam-Webster) to avoid confusing with the BCL <see cref="List{T}"/> class.
    /// </remarks>
    public class MwList
    {
        [JsonProperty("wd")]
        public string Word { get; set; }

        [JsonProperty("wvrs", NullValueHandling = NullValueHandling.Ignore)]
        public WordVariant[] Variants { get; set; } = { };

        [JsonProperty("wsls", NullValueHandling = NullValueHandling.Ignore)]
        public WordSubjectStatusLabel SubjectStatusLabel { get; set; }
    }
}