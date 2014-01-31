namespace ADIPlus.Drawing
{
    public class AsciiGraphics
    {
        private readonly ConsoleAdabter m_console;

        private AsciiGraphics(ConsoleAdabter console)
        {
            m_console = console;
        }

        public void DrawHorizontalLine(AsciiColor ch, Point location, uint width)
        {
            DrawHorizontalLine(ch, location.X, location.Y, width);
        }

        public void DrawHorizontalLine(AsciiColor ch, uint x, uint y, uint width)
        {
            for (uint i = 0; i < width; i++)
                m_console.SetChar(x + i, y, ch);
        }

        public void DrawVerticalLine(AsciiColor ch, Point location, uint height)
        {
            DrawVerticalLine(ch, location.X, location.Y, height);
        }

        public void DrawVerticalLine(AsciiColor ch, uint x, uint y, uint height)
        {
            for (uint i = 0; i < height; i++)
                m_console.SetChar(x, y + i, ch);
        }

        private bool IsValid(uint x, uint y)
        {
            return x <= m_console.Width && y <= m_console.Height;
        }

        public static AsciiGraphics FromCharImage(CharImage image)
        {
            return new AsciiGraphics(new VirtualConsole(image));
        }

        public static AsciiGraphics FromConsole()
        {
            return new AsciiGraphics(new ConcreatConsole());
        }
    }
}