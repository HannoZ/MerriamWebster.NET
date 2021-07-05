namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The sense sequence contains a series of senses and subsenses, ordered by sense numbers beginning at Arabic numeral "1".
    /// </summary>
    public struct SenseSequence
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public SenseSequence[][] SenseSequences; // nested sseq occur inside the "pseq" construct
        public Sense Sense;
        public SseqEnum? Name;

        public static implicit operator SenseSequence(Sense sense) => new SenseSequence { Sense = sense };
        public static implicit operator SenseSequence(SseqEnum @enum) => new SenseSequence { Name = @enum };
        public static implicit operator SenseSequence(SenseSequence[][] sseq) => new SenseSequence { SenseSequences = sseq };

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}