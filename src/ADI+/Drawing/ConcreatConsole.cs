using System;

namespace ADIPlus.Drawing
{
    internal class ConcreatConsole : ConsoleAdabter
    {
        public ConcreatConsole()
        {
            Console.CursorVisible = false;
        }

        public override void SetChar(uint x, uint y, AsciiColor color)
        {
            Console.SetCursorPosition((int)x, (int)y);
            Console.BackgroundColor = color.BackgroundColor;
            Console.ForegroundColor = color.ForgroundColor;
            Console.Write(color.Character);
        }

        public override uint Width
        {
            get { return (uint)Console.WindowWidth; }
        }

        public override uint Height
        {
            get { return (uint)Console.WindowHeight; }

        }
    }
}