using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A thesaurus subject/status label describes the subject area (eg, "computing") or regional/usage status (eg, "British", "formal", "slang") of a synonym, antonym, or other word listed in a thesaurus entry.
    /// </summary>
    public class WordSubjectStatusLabel
    {
        [JsonProperty("wsl")]
        public string Label { get; set; }
    }
}