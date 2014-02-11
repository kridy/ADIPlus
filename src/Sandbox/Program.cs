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
#if !true

                for (uint i = 0; i < height; i++)
                {
                    bufferRender.DrawHorizontalLine(
                        new AsciiPen("Helloworld", AsciiColors.Red),
                        new Point(0, i), width);
                }
#else
                for (uint i = 0; i < width; i++)
                {
                    bufferRender.DrawVerticalLine(
                        new AsciiPen("Helloworld", AsciiColors.Red),
                        new Point(i, 0), height);
                }
#endif

                displayRender.DrawImage(backbuffer);

                Console.ReadKey(true);
            }
        }
    }
}