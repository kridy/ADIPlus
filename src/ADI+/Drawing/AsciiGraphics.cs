using System;
namespace ADIPlus.Drawing
{
    public class AsciiGraphics : IDisposable
    {
        private readonly RenderSurferce m_console;

        private AsciiGraphics(RenderSurferce console)
        {
            m_console = console;
            m_console.InitializeBuffer();
        }

        public void DrawHorizontalLine(AsciiPen pen, Point location, uint width)
        {
            DrawHorizontalLine(pen, location.X, location.Y, width);
        }

        public void DrawHorizontalLine(AsciiPen pen, uint x, uint y, uint width)
        {
            var buffer = m_console.GetBuffer();
            var strIndex = 0;
            if (m_console.Height <= y) return;

            for (uint i = 0; i < width; i++)
            {
                var offsetX = i + x;
                if (m_console.Width <= offsetX) break;

                var index = (y*m_console.Width) + offsetX;

                buffer[index].Character = pen.String[strIndex++ % pen.String.Length];
                buffer[index].Color = pen.Color;
            }

            m_console.Invalidate(null);
        }

        public void DrawVerticalLine(AsciiPen pen, Point location, uint height)
        {
            DrawVerticalLine(pen, location.X, location.Y, height);
        }

        public void DrawVerticalLine(AsciiPen pen, uint x, uint y, uint height)
        {
            var buffer = m_console.GetBuffer();
            var strIndex = 0;
            if (m_console.Width <= x) return;

            for (uint i = 0; i < height; i++)
            {
                var offsetY = i + y;
                if (m_console.Height <= offsetY) break;

                var index = (offsetY*m_console.Width) + x;


                buffer[index].Character = pen.String[strIndex++ % pen.String.Length];
                buffer[index].Color = pen.Color;
            }

            m_console.Invalidate(null);
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
                    if (m_console.Width <= offsetX) break;
                    
                    buffer[(offsetY * m_console.Width) + offsetX] = image[(imgY * image.Width) + imgX];
                }
            }

            var imageLocationRect = new Rectangle(x, y, image.Width, image.Height);
            var imageRenderedContentRect = imageLocationRect.Intersect(m_console.ClientRectangle);

            m_console.Invalidate(imageRenderedContentRect);
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
            var fromCharImage = new AsciiGraphics(new VirtualRenderSurface(image));
            return fromCharImage;
        }

        public static AsciiGraphics FromManagedConsole()
        {
            var fromManagedConsole = new AsciiGraphics(new ManagedConsoleRenderSurfece());
            return fromManagedConsole;
        }

        public static AsciiGraphics FromUnManagedConsole()
        {
            var fromUnManagedConsole = new AsciiGraphics(new UnManagedConsoleRenderSurface());
            return fromUnManagedConsole;
        }

        public void Dispose()
        {
            m_console.Dispose();
        }
    }
}