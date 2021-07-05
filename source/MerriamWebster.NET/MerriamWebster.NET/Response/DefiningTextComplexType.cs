namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public struct DefiningTextComplexType
    {
        public DefiningText DefiningTextClass;
        public DefiningText[] DtClassArray;
        public string TypeOrLabel;

        public static implicit operator DefiningTextComplexType(DefiningText dt) => new DefiningTextComplexType { DefiningTextClass = dt };
        public static implicit operator DefiningTextComplexType(DefiningText[] arr) => new DefiningTextComplexType { DtClassArray = arr };
        public static implicit operator DefiningTextComplexType(string s) => new DefiningTextComplexType { TypeOrLabel = s };
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}