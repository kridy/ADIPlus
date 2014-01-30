using System;

namespace ADIPlus
{
    public class AsciiGraphics
    {
        public void SetChar(int x, int y, AsciiColor ch)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ch.BackgroundColor;
            Console.ForegroundColor = ch.ForgroundColor;
            Console.Write(ch.Character);
        }
    }

    public  class AsciiColor
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
    }
}