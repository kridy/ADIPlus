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

            var backbuffer = new CharImage(80, 25);
            var displayRender = AsciiGraphics.FromConsole();
            var bufferRender = AsciiGraphics.FromCharImage(backbuffer);

            do{
                bufferRender.DrawHorizontalLine(new AsciiColor(ConsoleColor.Blue, ConsoleColor.Black, '*'), new Point(10, 10), 40);
                bufferRender.DrawVerticalLine(new AsciiColor(ConsoleColor.Green, ConsoleColor.Yellow, '*'), new Point(10, 10), 7);

                displayRender.DrawImage(backbuffer);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }        
    }
}
