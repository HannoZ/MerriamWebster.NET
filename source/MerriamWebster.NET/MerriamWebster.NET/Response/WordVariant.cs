using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A thesaurus word variant is a variant spelling of a synonym, antonym, or other word listed in a thesaurus entry. 
    /// </summary>
    public class WordVariant
    {
        [JsonProperty("wvl")]
        public string Label { get; set; }

        [JsonProperty("wva")]
        public string Variant { get; set; }
    }
}