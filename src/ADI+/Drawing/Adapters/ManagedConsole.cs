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
            for (int i = 0; i < m_buffer.Length; i++)
            {
                Console.BackgroundColor = m_buffer[i].BackgroundColor;
                Console.ForegroundColor = m_buffer[i].ForgroundColor;
                Console.SetCursorPosition(0,0);
                Console.Write(m_buffer[i].Character);
            }
        }

        internal override void InitializeBuffer()
        {
            m_buffer =new AsciiColor[Width * Height];
            m_buffer.Init(AsciiColor.empty);
        }
    }
}