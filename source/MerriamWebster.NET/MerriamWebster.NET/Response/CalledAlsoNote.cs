using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// A called-also note lists other names a headword is called in a given sense.
    /// </summary>
    public class CalledAlsoNote
    {
        /// <summary>
        /// Contains introductory text "called also"
        /// </summary>
        [JsonProperty("intro")]
        public string Intro { get; set; }

        /// <summary>
        /// One or more called-also targets
        /// </summary>
        [JsonProperty("cats")]
        public CalledAlsoTarget[] Targets { get; set; } = { };
    }
}
