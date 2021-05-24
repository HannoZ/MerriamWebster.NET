using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A thesaurus subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a synonym, antonym, or other word listed in a thesaurus entry.
    /// </summary>
    public class WordSubjectStatusLabel
    {
        [JsonProperty("wsl")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string Label { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}