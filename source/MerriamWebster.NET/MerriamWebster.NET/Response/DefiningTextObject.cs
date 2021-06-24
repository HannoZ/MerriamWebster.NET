namespace MerriamWebster.NET.Response
{
    public struct DefiningTextObject
    {
        public DefiningTextComplexTypeWrapper[] DefiningTextComplexTypeWrapperArray;
        public DefiningText DefiningText;

        public static implicit operator DefiningTextObject(DefiningTextComplexTypeWrapper[] arr) => new DefiningTextObject { DefiningTextComplexTypeWrapperArray = arr };
        public static implicit operator DefiningTextObject(DefiningText dt) => new DefiningTextObject { DefiningText = dt };
    }
}