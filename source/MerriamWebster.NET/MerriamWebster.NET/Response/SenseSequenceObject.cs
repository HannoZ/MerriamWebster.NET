namespace MerriamWebster.NET.Response
{
    public struct SenseSequenceObject
    {
        public SenseSequence SenseSequence;
        public string Name;

        public static implicit operator SenseSequenceObject(SenseSequence senseSequence) => new SenseSequenceObject { SenseSequence = senseSequence };
        public static implicit operator SenseSequenceObject(string name) => new SenseSequenceObject { Name = name };
    }
}