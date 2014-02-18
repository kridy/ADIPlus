using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ADIPlus
{

    //TODO make internal again.
    internal class Kernel32
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern SafeFileHandle CreateConsoleScreenBuffer(
            [MarshalAs(UnmanagedType.U4)] uint dwDesiredAccess,
            [MarshalAs(UnmanagedType.U4)] uint dwShareMode,
            IntPtr lpSecurityAttributes,
            [MarshalAs(UnmanagedType.U4)] int dwFlags,
            IntPtr lpScreenBufferData);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetConsoleActiveScreenBuffer(SafeFileHandle hConsoleOutput);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern SafeFileHandle CreateFile(
            [MarshalAs(UnmanagedType.LPWStr)]string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool WriteConsoleOutput(
            SafeFileHandle hConsoleOutput,
            CharInfo[] lpBuffer,
            Coord dwBufferSize,
            Coord dwBufferCoord,
            ref SmallRect lpWriteRegion);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Coord
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
        internal struct CharUnion
        {
            [FieldOffset(0)]
            public char UnicodeChar;
            [FieldOffset(0)]
            public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct CharInfo
        {
            [FieldOffset(0)]
            public CharUnion Char;
            [FieldOffset(2)]
            public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }
    }
}