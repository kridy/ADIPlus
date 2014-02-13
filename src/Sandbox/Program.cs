using System;
using System.IO;
using ADIPlus;
using ADIPlus.Drawing;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            var location = new Point((uint) Console.WindowWidth/2, (uint) Console.WindowHeight/2);
            const uint width = (uint)10; // (uint)Console.WindowWidth;
            const uint height = (uint)6; // (uint)Console.WindowHeight;

            var backbuffer = new Image(width, height);
            using (var bufferRender = AsciiGraphics.FromCharImage(backbuffer))
            using (var displayRender = AsciiGraphics.FromUnManagedConsole())
            {
                do
                {
                    displayRender.Clear();
#if true

                    for (uint i = 0; i < height; i++)
                    {
                        bufferRender.DrawHorizontalLine(
                            new AsciiPen("*", AsciiColors.Red),
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

                    displayRender.DrawImage(location.X, location.Y, backbuffer);

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            location = location.YDecremented();
                            break;
                        case ConsoleKey.RightArrow:
                            location = location.XIncremented();
                            break;
                        case ConsoleKey.LeftArrow:
                            location = location.XDecremented();
                            break;
                        case ConsoleKey.DownArrow:
                            location = location.YIncremented();
                            break;
                        case ConsoleKey.Escape:
                            exit = true;
                            break;
                    }
                } while (!exit);
            }
        }
    }
}