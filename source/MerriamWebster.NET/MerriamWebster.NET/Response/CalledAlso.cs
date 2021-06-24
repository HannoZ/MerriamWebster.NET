using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class CalledAlso
    {
        [JsonProperty("intro")]
        public string Intro { get; set; }

        [JsonProperty("cats")]
        public CalledAlsoTarget[] Targets { get; set; }
    }
}
