using System;

namespace ADIPlus.Drawing
{
    public class AsciiColor
    {
        public AsciiColor(ConsoleColor forgroundColor, ConsoleColor backgroundColor)
        {
            ForgroundColor = forgroundColor;
            BackgroundColor = backgroundColor;    
        }

        public ConsoleColor ForgroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1}", ForgroundColor, BackgroundColor);
        }
    }
}