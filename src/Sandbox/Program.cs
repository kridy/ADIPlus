using System;
using ADIPlus.Drawing;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = (uint)Console.WindowWidth;
            var height = (uint)Console.WindowHeight;

            var backbuffer = new Image(width, height);
            using (var bufferRender = AsciiGraphics.FromCharImage(backbuffer))
            using (var displayRender = AsciiGraphics.FromUnManagedConsole())
            {
                for (uint i = 0; i < height; i++)
                {
                    bufferRender.DrawHorizontalLine(
                        new AsciiPen('*', AsciiColors.Red),
                        new Point(0, i), width);
                }

                displayRender.DrawImage(backbuffer);

                Console.ReadKey(true);
            }
        }
    }
}