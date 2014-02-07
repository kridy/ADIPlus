using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace ADIPlus.Drawing
{
    internal class UnManagedConsole : ConsoleAdabter
    {        

        private readonly SafeFileHandle m_consoleBufferWriteHandle;
        private readonly Kernel32.CharInfo[] m_CharBuffer;
        private Kernel32.SmallRect m_rect;
        private bool m_renderIsDeferred;

        public UnManagedConsole()
            :base((uint)Console.WindowWidth, (uint)Console.WindowHeight)
        {            
            m_consoleBufferWriteHandle = Kernel32.CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            m_CharBuffer = new Kernel32.CharInfo[Width * Height];
            m_rect = new Kernel32.SmallRect() { Left = 0, Top = 0, Right = (short)Width, Bottom = (short)Height };
        }

        public override void Invalidate(Rectangle rectangle)
        {
            for (int i = 0; i < m_buffer.Length; i++)
            {
                m_CharBuffer[i].Attributes = (short)m_buffer[i].ForgroundColor;
                m_CharBuffer[i].Char.AsciiChar = (byte)m_buffer[i].Character;
            }

            bool b = Kernel32.WriteConsoleOutput(m_consoleBufferWriteHandle, m_CharBuffer,
                          new Kernel32.Coord() { X = 80, Y = 25 },
                          new Kernel32.Coord() { X = 0, Y = 0 },
                          ref m_rect);
        }
    }
}