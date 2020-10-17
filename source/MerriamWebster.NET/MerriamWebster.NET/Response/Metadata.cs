using System;
using MerriamWebster.NET.Response.JsonConverters;
using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class Metadata
    {
        /// <summary>
        /// Unique entry identifier within a particular dictionary data set, used in cross-references pointing to the entry. It consists of the headword, and in homograph entries, an appended colon and homograph number
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("lang")]
        public Lang Lang { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("sort")]
        [JsonConverter(typeof(StringLongConverter))]
        public long Sort { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("target")]
        public Target Target { get; set; }
        
        [JsonProperty("stems")] 
        public string[] Stems { get; set; } = { };
        
        [JsonProperty("syns")] 
        public string[][] Synonyms { get; set; } = { };

        [JsonProperty("ants")]
        public string[][] Antonyms { get; set; } = { };

        [JsonProperty("offensive")]
        public bool Offensive { get; set; }

        // highlight and AppShortdef are only used in the Learner's dictionary
        /// <summary>
        /// If text is "yes", the headword is a key part of English vocabulary that is highlighted in print.
        /// </summary>
        [JsonProperty("highlight")]
        public string Highlight { get; set; }

        [JsonProperty("app-shortdef")]
        public AppShortdef AppShortdef { get; set; }
    }
}