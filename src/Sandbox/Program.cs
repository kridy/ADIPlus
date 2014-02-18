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
            const int width = 100;
            const int height = 50;

            Console.CursorVisible = false;
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            Console.BufferWidth = width;
            Console.BufferHeight = height;

            const uint horizontalSpeed = 2;
            const uint verticalSpeed = 1;

            var exit = false;
            var location = new Point(width / 2, height / 2);

            var backbuffer = new Image(width, height);
            using (var bufferRender = AsciiGraphics.FromCharImage(backbuffer))
            using (var displayRender = AsciiGraphics.FromUnManagedConsole())
            {
                do
                {
                    bufferRender.Clear();
                 
                    for (uint i = 0; i < 2; i++)
                    {
                        bufferRender.DrawHorizontalLine(
                            new AsciiPen("*", AsciiColors.Red),
                            new Point(location.X, location.Y + i), 3);
                    }

                    displayRender.DrawImage(backbuffer);

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            location = location.YDecremented(verticalSpeed);
                            break;
                        case ConsoleKey.RightArrow:
                            location = location.XIncremented(horizontalSpeed);
                            break;
                        case ConsoleKey.LeftArrow:
                            location = location.XDecremented(horizontalSpeed);
                            break;
                        case ConsoleKey.DownArrow:
                            location = location.YIncremented(verticalSpeed);
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