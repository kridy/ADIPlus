using System;
using System.Collections.Generic;
using ADIPlus.Drawing;

namespace Sandbox
{
    class Program
    {


        static void Main(string[] args)
        {
            var color = ConsoleColor.Yellow & ConsoleColor.DarkGreen;

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

            var backbuffer = new CharImage(20, 10);
            var displayRender = AsciiGraphics.FromManagedConsole();
            var bufferRender = AsciiGraphics.FromCharImage(backbuffer);
            var fastDispRender = AsciiGraphics.FromUnManagedConsole();

            do
            {

                    for (uint i = 0; i < 10; i++)
                    {
                        //Console.Write("********************************************************************************");
                        bufferRender.DrawHorizontalLine(
                            new AsciiColor(colors[random.Next(0, 5)], colors[random.Next(0, 5)], '*'), new Point(0, i), 20);
                    }

                    fastDispRender.DrawImage(10,10,backbuffer);
                //displayRender.DrawHorizontalLine(new AsciiColor(colors[random.Next(0, 5)], colors[random.Next(0, 5)], '*'), new Point(10, 10), 60);
                //displayRender.DrawVerticalLine(new AsciiColor(colors[random.Next(0, 5)], colors[random.Next(0, 5)], '*'), new Point(10, 10), 14);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            fastDispRender.Clear();

            //displayRender.Clear(new AsciiColor(ConsoleColor.White,ConsoleColor.DarkBlue,'*'));
            Console.ReadKey(true);
        }
    }
}