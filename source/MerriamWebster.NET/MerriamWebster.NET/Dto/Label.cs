namespace MerriamWebster.NET.Dto
{
    /// <summary>
    /// A label provides a brief note on the grammatical function, subject area, register, regional usage, or capitalization of a headword, whether generally or in a particular sense.
    /// </summary>
    public class Label
    {
        /// <summary>
        /// Gets or sets the label text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Creates a new default instance of the <see cref="Label"/> class.
        /// </summary>
        public Label()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Label"/> class with specified text.
        /// </summary>
        public Label(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Creates a new Label object from a string input.
        /// </summary>
        /// <param name="label">The label text.</param>
        /// <returns>A new label instance with the provided label text.</returns>
        public static implicit operator Label(string label)
        {
            return new Label(label);
        }

        /// <summary>
        /// Takes a Label object and returns the Text value. 
        /// </summary>
        /// <param name="label">The label object.</param>
        /// <returns>The label text.</returns>
        public static implicit operator string(Label label)
        {
            return label.Text;
        }
    }
}