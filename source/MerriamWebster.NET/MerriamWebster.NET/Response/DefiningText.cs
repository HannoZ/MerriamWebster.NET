﻿using Newtonsoft.Json;

namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The <see cref="DefiningText"/> is the text of the definition or translation for a particular <see cref="Sense"/>.
    /// </summary>
    public class DefiningText
    {
        [JsonProperty("t")]
        public string Text { get; set; }

        [JsonProperty("tr")]
        public string Translation { get; set; }
    }

    
    public struct DefiningTextComplexType
    {
        public DefiningText DefiningTextClass;
        public DefiningText[] DtClassArray;
        public string TypeOrLabel;

        public static implicit operator DefiningTextComplexType(DefiningText dt) => new DefiningTextComplexType { DefiningTextClass = dt };
        public static implicit operator DefiningTextComplexType(DefiningText[] arr) => new DefiningTextComplexType { DtClassArray = arr };
        public static implicit operator DefiningTextComplexType(string s) => new DefiningTextComplexType { TypeOrLabel = s };
    }

    public struct DefiningTextComplexTypeWrapper
    {
        public DefiningTextComplexType[] DefiningTextComplexTypeArray;
        public string TypeOrLabel;

        public static implicit operator DefiningTextComplexTypeWrapper(DefiningTextComplexType[] arr) => new DefiningTextComplexTypeWrapper { DefiningTextComplexTypeArray = arr };
        public static implicit operator DefiningTextComplexTypeWrapper(string s) => new DefiningTextComplexTypeWrapper { TypeOrLabel = s };
    }

    public struct DefiningTextObject
    {
        public DefiningTextComplexTypeWrapper[] DefiningTextComplexTypeWrapperArray;
        public DefiningText DefiningText;

        public static implicit operator DefiningTextObject(DefiningTextComplexTypeWrapper[] arr) => new DefiningTextObject { DefiningTextComplexTypeWrapperArray = arr };
        public static implicit operator DefiningTextObject(DefiningText dt) => new DefiningTextObject { DefiningText = dt };
    }
}