using ADIPlus;
using Microsoft.Win32.SafeHandles;

public static class Program
{
    static void Main(string[] args)
    {
        FConsole.Write("Helloworld", 0, 0);
    }
}

public static class FConsole
{
    private static readonly SafeFileHandle m_consoleBufferWriteHandle;

    static FConsole()
    {
        m_consoleBufferWriteHandle = Kernel32.CreateFile(
                "CONOUT$",
                0x40000000,
                2,
                IntPtr.Zero,
                FileMode.Open,
                0,
                IntPtr.Zero);
    }
    public static void Write(string text, int x, int y)
    {
        var charBufSize = new Kernel32.Coord((short)text.Length, 1);
        var characterPos = new Kernel32.Coord(0, 0);
        var m_CharBuffer = new Kernel32.CharInfo[text.Length];
        var writeArea = new Kernel32.SmallRect()
        {
            Left = (short)x,
            Top = (short)y,
            Right = (short)(x + text.Length),
            Bottom = (short)y
        };

        for (int i = 0; i < text.Length; i++)
        {
            m_CharBuffer[i].Char.UnicodeChar = (char)text[i];
            m_CharBuffer[i].Attributes = (short)ConsoleColor.White; 
        }

        var res =Kernel32.WriteConsoleOutput(
                m_consoleBufferWriteHandle,
                m_CharBuffer,
                charBufSize,
                characterPos,
                ref writeArea);
    }
}
