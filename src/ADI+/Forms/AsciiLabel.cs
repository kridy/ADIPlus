using System;
using ADIPlus.Drawing;

namespace ADIPlus.Forms
{
    public class AsciiChar : AsciiControle
    {
        public override void OnPaint(AsciiPaintEventArgs e)
        {
            var g = e.Graphics;
            //g.SetChar(0,0,new AsciiColor(ConsoleColor.Blue, ConsoleColor.Yellow, '*'));
        }

        public string Text { get; set; }
    }

    public class AsciiLabel : AsciiControle
    {
        public override void OnPaint(AsciiPaintEventArgs e)
        {
            var rect = e.ClipRectangle;
            var g = e.Graphics;
        }

        public string Text { get; set; }
    }
}