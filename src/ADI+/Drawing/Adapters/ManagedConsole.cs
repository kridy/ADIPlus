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
            : base((uint)Console.WindowWidth, (uint)Console.WindowHeight)
        {            
        }

        public override void Invalidate()
        {
            foreach (var t in m_buffer) 
            {
                Console.BackgroundColor = t.BackgroundColor;
                Console.ForegroundColor = t.ForgroundColor;
                Console.SetCursorPosition(0,0);
                Console.Write(t.Character);
            }
        }

        internal override void InitializeBuffer()
        {
            m_buffer =new AsciiColor[Width * Height];
            m_buffer.Init(AsciiColor.empty);
        }
    }
}