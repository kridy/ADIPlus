using System;

namespace ADIPlus.Drawing
{
    public class AsciiColor
    {
        public AsciiColor(ConsoleColor forgroundColor, ConsoleColor backgroundColor, char character)
        {             
            ForgroundColor = forgroundColor;
            BackgroundColor = backgroundColor;
            Character = character;
        }

        public ConsoleColor ForgroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public char Character { get; set; }


        public static AsciiColor Empty()
        {
            return new AsciiColor(ConsoleColor.Black, ConsoleColor.Black, ' ');
        }
    }
}