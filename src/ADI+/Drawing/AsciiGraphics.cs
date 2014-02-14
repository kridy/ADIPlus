using System;
namespace ADIPlus.Drawing
{
    public class AsciiGraphics : IDisposable
    {
        private readonly RenderSurferce m_surface;

        private AsciiGraphics(RenderSurferce surface)
        {
            m_surface = surface;
            m_surface.InitializeBuffer();
        }

        public void DrawPoint(AsciiPen pen, Point location)
        {
            DrawPoint(pen, location.X, location.Y);
        }

        private void DrawPoint(AsciiPen pen, uint x, uint y)
        {
            var buffer = m_surface.GetBuffer();

            if (x >= m_surface.Width || y >= m_surface.Height) return;

            var index = (y * m_surface.Width) +x;

            buffer[index].Character = pen.String[0];
            buffer[index].Color = pen.Color;

        }

        public void DrawHorizontalLine(AsciiPen pen, Point location, uint width)
        {
            DrawHorizontalLine(pen, location.X, location.Y, width);
        }

        public void DrawHorizontalLine(AsciiPen pen, uint x, uint y, uint width)
        {
            var buffer = m_surface.GetBuffer();
            var stringIndex = 0;

            if (x >= m_surface.Width || y >= m_surface.Height) return;

            for (uint i = 0; i < width; i++)
            {
                var offsetX = i + x;
                if (offsetX >= m_surface.Width) break;

                var index = (y*m_surface.Width) + offsetX;

                buffer[index].Character = pen.String[stringIndex++ % pen.String.Length];
                buffer[index].Color = pen.Color;
            }

            var clipArea = m_surface.ClientRectangle.Intersect(new Rectangle(x, y, width, 1));

            m_surface.Invalidate(clipArea);
        }

        public void DrawVerticalLine(AsciiPen pen, Point location, uint height)
        {
            DrawVerticalLine(pen, location.X, location.Y, height);
        }

        public void DrawVerticalLine(AsciiPen pen, uint x, uint y, uint height)
        {
            var buffer = m_surface.GetBuffer();
            var stringIndex = 0;

            if (x >= m_surface.Width || y >= m_surface.Height) return;

            for (uint i = 0; i < height; i++)
            {
                var offsetY = i + y;
                if (m_surface.Height <= offsetY) break;

                var index = (offsetY*m_surface.Width) + x;


                buffer[index].Character = pen.String[stringIndex++ % pen.String.Length];
                buffer[index].Color = pen.Color;
            }

            var clipArea = m_surface.ClientRectangle.Intersect(new Rectangle(x, y, 1, height));

            m_surface.Invalidate(clipArea);
        }       

        public void DrawImage(uint x, uint y, Image image)
        {
            var buffer = m_surface.GetBuffer();

            if (x >= m_surface.Width || y >= m_surface.Height) return;

            for (uint imgY = 0; imgY < image.Height; imgY++)
            {
                var offsetY = imgY + y;
                if (m_surface.Height <= offsetY) break;

                for (uint imgX = 0; imgX < image.Width; imgX++)
                {                   
                    var offsetX = imgX + x;
                    if (m_surface.Width <= offsetX) break;
                    
                    buffer[(offsetY * m_surface.Width) + offsetX] = image[(imgY * image.Width) + imgX];
                }
            }

            var clipArea = m_surface.ClientRectangle.Intersect(image.Rectangle.Relocate(x, y));

            m_surface.Invalidate(clipArea);
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
            m_surface.Clear();
        }

        public void Clear(AsciiColor color)
        {
            m_surface.Clear(color);
        }
                   
        public static AsciiGraphics FromCharImage(Image image)
        {
            var fromCharImage = new AsciiGraphics(new ImageRenderSurface(image));
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
            m_surface.Dispose();
        }
    }
}