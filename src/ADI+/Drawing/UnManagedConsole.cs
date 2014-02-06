﻿using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ADIPlus.Drawing
{
    public class UnManagedConsole : ConsoleAdabter {        

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

        public override void Invalidate()
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

    internal class Kernel32
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool FreeConsole();

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool AttachConsole(
            [MarshalAs(UnmanagedType.U4)] int dwProcessId );

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern SafeFileHandle CreateConsoleScreenBuffer(
            [MarshalAs(UnmanagedType.U4)] uint dwDesiredAccess,
            [MarshalAs(UnmanagedType.U4)] uint dwShareMode,
            IntPtr lpSecurityAttributes,
            [MarshalAs(UnmanagedType.U4)] int dwFlags,
            IntPtr lpScreenBufferData);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetConsoleActiveScreenBuffer(SafeFileHandle hConsoleOutput);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);

        [StructLayout(LayoutKind.Sequential)]
        public struct Coord
        {
            public short X;
            public short Y;

            public Coord(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Explicit)]
        public struct CharUnion
        {
            [FieldOffset(0)]
            public char UnicodeChar;
            [FieldOffset(0)]
            public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
            [FieldOffset(0)]
            public CharUnion Char;
            [FieldOffset(2)]
            public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

    }
}