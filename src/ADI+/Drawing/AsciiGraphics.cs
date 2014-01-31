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

        public void DrawImage(uint x, uint y, CharImage image)
        {
            var xOffset = x;
            var yOffset = y;

            for (uint imgY = 0; imgY < image.Height; imgY++)
            {
                var y1 = imgY + yOffset;
                if (y1 >= m_console.Height) break; 

                for (uint imgX = 0; imgX < image.Width; imgX++)
                {
                    var x1 = imgX + xOffset;                   
                    if (x1 >= m_console.Width) break;

                    m_console.SetChar(x1, y1, image[(imgY*image.Width) + imgX]);
                }
            }
        }

        public void DrawImage(Point location, CharImage image)
        {
            DrawImage(location.X, location.Y, image);
        }

        public void DrawImage(CharImage image)
        {
            DrawImage(new Point(0, 0),image);
        }

        public static AsciiGraphics FromCharImage(CharImage image)
        {
            return new AsciiGraphics(new VirtualConsole(image));
        }

        public static AsciiGraphics FromConsole()
        {
            return new AsciiGraphics(new ConcreteConsole());
        }
    }
}