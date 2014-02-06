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

            var backbuffer = new CharImage(80, 25);
            var displayRender = AsciiGraphics.FromManagedConsole();
            var bufferRender = AsciiGraphics.FromCharImage(backbuffer);

            do
            {

                    for (uint i = 0; i < 25; i++)
                    {
                        //Console.Write("********************************************************************************");
                        bufferRender.DrawHorizontalLine(
                            new AsciiColor(colors[random.Next(0, 5)], colors[random.Next(0, 5)], '*'), new Point(0, i), 80);
                    }

                    displayRender.DrawImage(backbuffer);
                //displayRender.DrawHorizontalLine(new AsciiColor(colors[random.Next(0, 5)], colors[random.Next(0, 5)], '*'), new Point(10, 10), 60);
                //displayRender.DrawVerticalLine(new AsciiColor(colors[random.Next(0, 5)], colors[random.Next(0, 5)], '*'), new Point(10, 10), 14);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            displayRender.Clear(new AsciiColor(ConsoleColor.White,ConsoleColor.DarkBlue,'*'));
            Console.ReadKey(true);
        }
    }
}

//using System;
//using System.IO;
//using System.Runtime.InteropServices;
//using Microsoft.Win32.SafeHandles;

//namespace ConsoleApplication1
//{
//    class Program
//    {

//        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
//        static extern SafeFileHandle CreateFile(
//            string fileName,
//            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
//            [MarshalAs(UnmanagedType.U4)] uint fileShare,
//            IntPtr securityAttributes,
//            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
//            [MarshalAs(UnmanagedType.U4)] int flags,
//            IntPtr template);

//        [DllImport("kernel32.dll", SetLastError = true)]
//        static extern bool WriteConsoleOutput(
//          SafeFileHandle hConsoleOutput,
//          CharInfo[] lpBuffer,
//          Coord dwBufferSize,
//          Coord dwBufferCoord,
//          ref SmallRect lpWriteRegion);

//        [StructLayout(LayoutKind.Sequential)]
//        public struct Coord
//        {
//            public short X;
//            public short Y;

//            public Coord(short X, short Y)
//            {
//                this.X = X;
//                this.Y = Y;
//            }
//        };

//        [StructLayout(LayoutKind.Explicit)]
//        public struct CharUnion
//        {
//            [FieldOffset(0)]
//            public char UnicodeChar;
//            [FieldOffset(0)]
//            public byte AsciiChar;
//        }

//        [StructLayout(LayoutKind.Explicit)]
//        public struct CharInfo
//        {
//            [FieldOffset(0)]
//            public CharUnion Char;
//            [FieldOffset(2)]
//            public short Attributes;
//        }

//        [StructLayout(LayoutKind.Sequential)]
//        public struct SmallRect
//        {
//            public short Left;
//            public short Top;
//            public short Right;
//            public short Bottom;
//        }


//        [STAThread]
//        static void Main(string[] args)
//        {
//            SafeFileHandle h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

//            if (!h.IsInvalid)
//            {
//                CharInfo[] buf = new CharInfo[20 * 10];
//                SmallRect rect = new SmallRect() { Left = 10, Top = 10, Right = 20, Bottom = 10 };

//                for (byte character = 65; character < 65 + 26; ++character)
//                {
//                    for (short attribute = 17; attribute < 32; ++attribute)
//                    {
//                        for (int i = 0; i < buf.Length; ++i)
//                        {
//                            buf[i].Attributes = attribute;
//                            buf[i].Char.AsciiChar = character;
//                        }

//                        bool b = WriteConsoleOutput(h, buf,
//                          new Coord() { X = 20, Y = 10 },
//                          new Coord() { X = 10, Y = 10 },
//                          ref rect);

//                        //Console.ReadKey(true);
//                    }
//                }
//            }
//            Console.ReadKey();
//        }
//    }
//}
