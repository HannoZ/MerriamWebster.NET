using System.Collections.Generic;
using System.Linq;

namespace MerriamWebster.NET.Dto
{
    public class Entry
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public Language Language { get; set; }
        public string Pos { get; set; }
        public string SubCategory { get; set; }
        public ICollection<Pronunciation> Pronunciations { get; set; } = new List<Pronunciation>();
        public ICollection<string> Stems { get; set; } = new List<string>();
        public string Gender { get; set; }
        public ICollection<Sense> Senses { get; set; } = new List<Sense>();
        public Conjugations Conjugations { get; set; }
        public ICollection<CrossReference> CrossReferences { get; set; } = new List<CrossReference>();
        public ICollection<string> ShortDefs { get; set; } = new List<string>();
        public ICollection<string> Synonyms { get; set; } = new List<string>();
        public ICollection<string> Antonyms { get; set; } = new List<string>();

        public string Summary => string.Join(", ", Senses.Where(s => !string.IsNullOrEmpty(s.Text)).Select(s => s.Text));
    }
}