using System;
using System.Collections.Generic;
using ADIPlus.Drawing;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {


            var colors = new Dictionary<int, ConsoleColor>
                         {
                             {0, ConsoleColor.Blue},
                             {1, ConsoleColor.Cyan},
                             {2, ConsoleColor.Green},
                             {3, ConsoleColor.Yellow},
                             {4, ConsoleColor.Magenta},
                             {5, ConsoleColor.Red}
                         };

            var random = new Random();

            var backbuffer = new Image(19, 19);
            var bufferRender = AsciiGraphics.FromCharImage(backbuffer);
            var displayRender = AsciiGraphics.FromUnManagedConsole();

            do
            {
                for (uint i = 0; i < backbuffer.Height; i++)
                {
                    //bufferRender.DrawHorizontalLine(GetRandomColorAscii(colors, random), new Point(0, i), backbuffer.Width);
                    bufferRender.DrawVerticalLine(GetRandomColorAscii(colors, random), new Point(i, 0), backbuffer.Height);
                }
                displayRender.DrawImage(30, 3, backbuffer);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static AsciiColor GetRandomColorAscii(Dictionary<int, ConsoleColor> colors, Random random)
        {
            return new AsciiColor(GetRandomColor(colors, random), GetRandomColor(colors, random), '*');
        }

        private static ConsoleColor GetRandomColor(Dictionary<int, ConsoleColor> colors, Random random)
        {
            return colors[random.Next(0, 5)];
        }
    }
}