using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIPlus.Drawing;

namespace Sandbox
{ 
    class Program
    {


        static void Main(string[] args)
        {

            var backbuffer = new CharImage(10, 4);
            var displayRender = AsciiGraphics.FromConsole();
            var bufferRender = AsciiGraphics.FromCharImage(backbuffer);

            do{
                bufferRender.DrawHorizontalLine(new AsciiColor(ConsoleColor.Blue, ConsoleColor.Black, '*'), new Point(0, 0), 9);
                bufferRender.DrawVerticalLine(new AsciiColor(ConsoleColor.Green, ConsoleColor.Yellow, '*'), new Point(0, 0), 3);

                displayRender.DrawImage(10,5,backbuffer);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }        
    }
}
