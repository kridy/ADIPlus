using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADIPlus.Drawing
{

    internal class ManagedConsoleRenderSurfece : RenderSurferce
    {
        public ManagedConsoleRenderSurfece()
            : base((uint)Console.WindowWidth, (uint)Console.WindowHeight)
        {            
        }

        public override void Invalidate(Rectangle rect)
        {
            for (var y = rect.Y; y < rect.Height + rect.Y; y++)
            for (var x = rect.X; x < rect.Width + rect.X; x++)
            {
                var cell = m_buffer[(y*rect.Width + x)];
                Console.BackgroundColor = cell.Color.BackgroundColor;
                Console.ForegroundColor = cell.Color.ForgroundColor;
                Console.SetCursorPosition((int)x, (int)y);
                Console.Write(cell.Character);
            }
        }

        internal override void InitializeBuffer()
        {
            m_buffer =new CellDescription[Width * Height];
            m_buffer.Init(AsciiColors.White);
        }
    }
}