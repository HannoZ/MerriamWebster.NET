using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public  class Quote
    {
        [JsonProperty("t")]
        public string Text { get; set; }

        [JsonProperty("aq")]
        public AtributionOfQuote Aq { get; set; }
    }
}