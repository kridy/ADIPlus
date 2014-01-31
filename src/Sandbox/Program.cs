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
            var ag = AsciiGraphics.FromConsole();
            do{
                ag.DrawHorizontalLine(new AsciiColor(ConsoleColor.Blue, ConsoleColor.Black, '*'), new Point(10,10), 40);
                ag.DrawVerticalLine(new AsciiColor(ConsoleColor.Green, ConsoleColor.Yellow, '*'), new Point(10, 10), 7);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }        
    }
}
