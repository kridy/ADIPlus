using System;

namespace ADIPlus.Drawing
{
    public static class AsciiColors
    {
        public static AsciiColor Black
        {
            get { return new AsciiColor(ConsoleColor.Black, ConsoleColor.Black); }
        }
        public static AsciiColor Blue
        {
            get { return new AsciiColor(ConsoleColor.Blue, ConsoleColor.Black); }
        }
        public static AsciiColor Cyan
        {
            get { return new AsciiColor(ConsoleColor.Cyan, ConsoleColor.Black); }
        }
        public static AsciiColor DarkBlue
        {
            get { return new AsciiColor(ConsoleColor.DarkBlue, ConsoleColor.Black); }
        }
        public static AsciiColor DarkCyan
        {
            get { return new AsciiColor(ConsoleColor.DarkCyan, ConsoleColor.Black); }
        }
        public static AsciiColor DarkGray
        {
            get { return new AsciiColor(ConsoleColor.DarkGray, ConsoleColor.Black); }
        }
        public static AsciiColor DarkGreen
        {
            get { return new AsciiColor(ConsoleColor.DarkGreen, ConsoleColor.Black); }
        }
        public static AsciiColor DarkMagenta
        {
            get { return new AsciiColor(ConsoleColor.DarkMagenta, ConsoleColor.Black); }
        }
        public static AsciiColor DarkRed
        {
            get { return new AsciiColor(ConsoleColor.DarkRed, ConsoleColor.Black); }
        }
        public static AsciiColor DarkYellow
        {
            get { return new AsciiColor(ConsoleColor.DarkYellow, ConsoleColor.Black); }
        }
        public static AsciiColor Gray
        {
            get { return new AsciiColor(ConsoleColor.Gray, ConsoleColor.Black); }
        }
        public static AsciiColor Green
        {
            get { return new AsciiColor(ConsoleColor.Green, ConsoleColor.Black); }
        }
        public static AsciiColor Magenta
        {
            get { return new AsciiColor(ConsoleColor.Magenta, ConsoleColor.Black); }
        }
        public static AsciiColor Red
        {
            get { return new AsciiColor(ConsoleColor.Red, ConsoleColor.Black); }
        }
        public static AsciiColor White
        {
            get { return new AsciiColor(ConsoleColor.White, ConsoleColor.Black); }
        }
        public static AsciiColor Yellow
        {
            get { return new AsciiColor(ConsoleColor.Yellow, ConsoleColor.Black); }
        }
    }

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

    public class AsciiPen
    {
        private readonly AsciiColor m_color;
        public static readonly AsciiPen empty = new AsciiPen(' ', AsciiColors.Black);

        public AsciiPen(char character, AsciiColor color)
        {
            m_color = color;
            StartCap = EndCap = Character = character;
        }

        public char StartCap { get; set; }
        public char EndCap { get; set; }
        public char Character { get; set; }

        public AsciiColor Color
        {
            get { return m_color; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Color, Character);
        }
    }
}