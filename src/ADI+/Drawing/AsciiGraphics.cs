using System;
namespace ADIPlus.Drawing
{
    public class AsciiGraphics : IDisposable
    {
        private readonly ConsoleAdabter m_console;

        private AsciiGraphics(ConsoleAdabter console)
        {
            m_console = console;
            m_console.InitializeBuffer();
        }

        public void DrawHorizontalLine(AsciiColor color, Point location, uint width)
        {
            DrawHorizontalLine(color, location.X, location.Y, width);
        }

        public void DrawHorizontalLine(AsciiColor color, uint x, uint y, uint width)
        {
            var buffer = m_console.GetBuffer();

            for (uint i = 0; i < width; i++)
                buffer[(y * width) + (x + i)] = color;

            m_console.Invalidate();
        }

        public void DrawVerticalLine(AsciiColor color, Point location, uint height)
        {
            DrawVerticalLine(color, location.X, location.Y, height);
        }

        public void DrawVerticalLine(AsciiColor color, uint x, uint y, uint height)
        {
            var buffer = m_console.GetBuffer();

            for (uint i = 0; i < height; i++)
                buffer[(i * m_console.Width) + x] = color;

            m_console.Invalidate();
        }       

        public void DrawImage(uint x, uint y, Image image)
        {
            var buffer = m_console.GetBuffer();
            uint counter = 0;
            for (uint imgY = 0; imgY < image.Height; imgY++)
            {
                var offsetY = imgY + y;
                if (m_console.Height <= offsetY) break;

                for (uint imgX = 0; imgX < image.Width; imgX++)
                {                   
                    var offsetX = imgX + x;
                    if (m_console.Width <= offsetX)
                    {
                        break;
                    }


                    buffer[(offsetY * m_console.Width) + offsetX] = image[(imgY * image.Width) + imgX];
                }
            }

            m_console.Invalidate();
        }

        public void DrawImage(Point location, Image image)
        {
            DrawImage(location.X, location.Y, image);
        }

        public void DrawImage(Image image)
        {
            DrawImage(new Point(0, 0),image);
        }

        public void Clear()
        {
            m_console.Clear();
        }

        public void Clear(AsciiColor color)
        {
            m_console.Clear(color);
        }
                   
        public static AsciiGraphics FromCharImage(Image image)
        {
            var fromCharImage = new AsciiGraphics(new VirtualConsole(image));
            return fromCharImage;
        }

        public static AsciiGraphics FromManagedConsole()
        {
            var fromManagedConsole = new AsciiGraphics(new ManagedConsole());
            return fromManagedConsole;
        }

        public static AsciiGraphics FromUnManagedConsole()
        {
            var fromUnManagedConsole = new AsciiGraphics(new UnManagedConsole());
            return fromUnManagedConsole;
        }

        public void Dispose()
        {
            m_console.Dispose();
        }
    }
}