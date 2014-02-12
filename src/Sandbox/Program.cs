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
            ////Console.mo
            //Console.WindowHeight = 50;
            //Console.WindowWidth = 100;
            //Console.BufferHeight = 50;
            //Console.BufferWidth= 100;

            //var hfile = Kernel32.CreateFile(
            //    "CONOUT$",
            //    0x40000000,
            //    2,
            //    IntPtr.Zero,
            //    FileMode.Open,
            //    0,
            //    IntPtr.Zero);

            //var charbuffer = new Kernel32.CharInfo[2];
            //charbuffer[0].Char.AsciiChar = (byte)'A';
            //charbuffer[0].Attributes = (short)ConsoleColor.Red | ((int) ConsoleColor.Yellow << 4);

            //charbuffer[1].Char.AsciiChar = (byte)'B';
            //charbuffer[1].Attributes = (short)ConsoleColor.Red | ((int)ConsoleColor.Yellow << 4);

            //Kernel32.Coord charBufSize = new Kernel32.Coord(2, 1);
            //Kernel32.Coord characterPos = new Kernel32.Coord(0, 0);
            //Kernel32.SmallRect writeArea = new Kernel32.SmallRect
            //                                   {
            //                                       Top = 1,
            //                                       Left = 0,
            //                                       Right = 1,
            //                                       Bottom = 2
            //                                   };
            //Kernel32.WriteConsoleOutput(hfile, charbuffer, charBufSize, characterPos, ref writeArea);

            //Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("");
            const uint width = (uint)10; // (uint)Console.WindowWidth;
            const uint height = (uint)10; // (uint)Console.WindowHeight;

            var backbuffer = new Image(width, height);
            using (var bufferRender = AsciiGraphics.FromCharImage(backbuffer))
            using (var displayRender = AsciiGraphics.FromUnManagedConsole())
            {
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

                displayRender.DrawImage(75,20, backbuffer);

                Console.ReadKey(true);
            }
        }
    }
}