namespace MerriamWebster.NET.Response
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public struct DefiningTextObject
    {
        public DefiningTextComplexTypeWrapper[] DefiningTextComplexTypeWrappers;
        public DefiningText DefiningText;

        public static implicit operator DefiningTextObject(DefiningTextComplexTypeWrapper[] arr) => new DefiningTextObject { DefiningTextComplexTypeWrappers = arr };
        public static implicit operator DefiningTextObject(DefiningText dt) => new DefiningTextObject { DefiningText = dt };
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}