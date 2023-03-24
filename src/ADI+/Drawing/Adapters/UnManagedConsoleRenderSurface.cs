using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using Microsoft.Win32.SafeHandles;

namespace ADIPlus.Drawing
{
    public class UnManagedConsoleRenderSurface : RenderSurferce
    {

        private readonly SafeFileHandle m_consoleBufferWriteHandle;
        private readonly Kernel32.CharInfo[] m_CharBuffer;

        public UnManagedConsoleRenderSurface()
            : base((uint)Console.WindowWidth, (uint)Console.WindowHeight)
        {
            m_consoleBufferWriteHandle = Kernel32.CreateFile(
                "CONOUT$",
                0x40000000,
                2,
                IntPtr.Zero,
                FileMode.Open,
                0,
                IntPtr.Zero);

            m_CharBuffer = new Kernel32.CharInfo[Width * Height];

        }

        short color = 0;

        public override void Invalidate(Rectangle rect)
        {
            var charBufSize = new Kernel32.Coord((short)Width, (short)Height);
            var characterPos = new Kernel32.Coord((short)rect.X, (short)rect.Y);
            var writeArea = new Kernel32.SmallRect()
                                   {
                                       Left = (short)rect.X,
                                       Top = (short)rect.Y,
                                       Right = (short)(rect.Width + rect.X),
                                       Bottom = (short)(rect.Height + rect.Y)
                                   };

            for (var y = rect.Y; y < rect.Height + rect.Y; y++)
            for (var x = rect.X; x < rect.Width + rect.X; x++)
            {
                var i = (y*Width + x);

                    m_CharBuffer[i].Char.AsciiChar  = (byte)m_buffer[i].Character;
                    m_CharBuffer[i].Attributes      = (short)((int)m_buffer[i].Color.ForgroundColor |
                                                             ((int)m_buffer[i].Color.BackgroundColor << 4));
            }

            Kernel32.WriteConsoleOutput(
                m_consoleBufferWriteHandle,
                m_CharBuffer,
                charBufSize,
                characterPos,
                ref writeArea);
        }

        internal override void InitializeBuffer()
        {
            //TODO init buffer with content from the console
            m_buffer = new CellDescription[Width * Height];
            m_buffer.Init(AsciiColors.White);
        }

        public override void Dispose()
        {
            m_consoleBufferWriteHandle.Close();
        }
    }
}