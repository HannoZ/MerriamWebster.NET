﻿using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    public class DefinedRunOnDefinition
    {
        [JsonProperty("sseq")]
        public SenseSequence[][][] Sseq { get; set; }
    }
}