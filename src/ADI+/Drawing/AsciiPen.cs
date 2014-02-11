namespace ADIPlus.Drawing
{
    public class AsciiPen
    {
        private readonly AsciiColor m_color;
        public static readonly AsciiPen empty = new AsciiPen(' ', AsciiColors.Black);

        public AsciiPen(char character, AsciiColor color)
            :this(character.ToString(), color)
        { }

        public AsciiPen(string str, AsciiColor color)
        {
            m_color = color;
            StartCap = string.Empty;
            EndCap = string.Empty;
            String = str;
        }

        public string StartCap { get; set; }
        public string EndCap { get; set; }
        public string String { get; set; }

        public AsciiColor Color
        {
            get { return m_color; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Color, String);
        }
    }
}