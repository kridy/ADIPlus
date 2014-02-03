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

            var backbuffer = new CharImage(70, 20);
            var displayRender = AsciiGraphics.FromConsole();
            var bufferRender = AsciiGraphics.FromCharImage(backbuffer);

            do{

                for (uint i = 0; i < 20; i++)
                {
                    //Console.Write("********************************************************************************");
                    bufferRender.DrawHorizontalLine(
                        new AsciiColor(colors[random.Next(0, 5)], colors[random.Next(0, 5)], '*'), new Point(0, i), 70);
                }

                displayRender.DrawImage(backbuffer);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }        
    }
}
