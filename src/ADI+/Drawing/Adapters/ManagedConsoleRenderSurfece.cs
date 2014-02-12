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
            foreach (var t in m_buffer) 
            {
                Console.BackgroundColor = t.Color.BackgroundColor;
                Console.ForegroundColor = t.Color.ForgroundColor;
                Console.SetCursorPosition(0,0);
                Console.Write(t.Character);
            }
        }

        internal override void InitializeBuffer()
        {
            m_buffer =new CellDescription[Width * Height];
            m_buffer.Init(AsciiColors.White);
        }
    }
}