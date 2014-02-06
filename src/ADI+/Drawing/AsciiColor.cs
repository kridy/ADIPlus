using System;

namespace ADIPlus.Drawing
{
    public class AsciiColor
    {
        public static readonly AsciiColor empty = new AsciiColor(ConsoleColor.Black, ConsoleColor.Black, ' ');

        private AsciiColor()
            : this(ConsoleColor.Black, ConsoleColor.Black, ' ')
        {}

        public AsciiColor(ConsoleColor forgroundColor, ConsoleColor backgroundColor, char character)
        {             
            ForgroundColor = forgroundColor;
            BackgroundColor = backgroundColor;
            Character = character;
        }

        public ConsoleColor ForgroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public char Character { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1}-{2}", ForgroundColor, BackgroundColor, Character);
        }
    }
}