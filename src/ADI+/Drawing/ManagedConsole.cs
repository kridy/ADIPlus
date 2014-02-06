using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADIPlus.Drawing
{

    internal class ManagedConsole : ConsoleAdabter
    {
        public ManagedConsole()
        {
            Console.CursorVisible = false;
        }

        public override void RenderBuffer(AsciiColor[] color)
        {
            for (int i = 0; i < color.Length; i++)
            {
                Console.BackgroundColor = color[i].BackgroundColor;
                Console.ForegroundColor = color[i].ForgroundColor;
                Console.SetCursorPosition(0,0);
                Console.Write(color[i].Character);
            }
        }

        public override void SetChar(uint x, uint y, AsciiColor color)
        {
            Console.BackgroundColor = color.BackgroundColor;
            Console.ForegroundColor = color.ForgroundColor;
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write(color.Character);
        }

        public override uint Width
        {
            get { return (uint)Console.WindowWidth; }
        }

        public override uint Height
        {
            get { return (uint)Console.WindowHeight; }
        }

        protected override void DoClear(AsciiColor color)
        {
            Console.BackgroundColor = color.BackgroundColor;
            Console.ForegroundColor = color.ForgroundColor;
            Console.SetCursorPosition(0, 0);
            
            var builder = new StringBuilder();
            for (var i = 0; i < Width * Height; i++)
            {
                builder.Append(color.Character);
            }
            Console.Write(builder.ToString());
        }
    }
}