using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A thesaurus word variant is a variant spelling of a synonym, antonym, or other word listed in a thesaurus entry. 
    /// </summary>
    public class WordVariant
    {
        [JsonProperty("wvl")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string Label { get; set; }

        [JsonProperty("wva")]
        public string Variant { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}