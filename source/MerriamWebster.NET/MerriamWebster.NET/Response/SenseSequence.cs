namespace MerriamWebster.NET.Response
{
    /// <summary>
    /// The sense sequence contains a series of senses and subsenses, ordered by sense numbers beginning at Arabic numeral "1".
    /// </summary>
    public struct SenseSequence
    {
        public Sense Sense;
        public string Name;

        public static implicit operator SenseSequence(Sense sense) => new SenseSequence { Sense = sense };
        public static implicit operator SenseSequence(string name) => new SenseSequence { Name = name };
    }
}