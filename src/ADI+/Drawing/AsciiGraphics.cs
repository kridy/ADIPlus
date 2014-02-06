namespace ADIPlus.Drawing
{
    public class AsciiGraphics
    {
        private readonly ConsoleAdabter m_console;
        //private readonly AsciiColor[] m_buffer;

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
            var buffer = m_console.GetBuffer();

            for (uint i = 0; i < width; i++)
                buffer[(y*width) + (x+i)] = ch;

            m_console.Invalidate();

            var temp = m_console.GetBuffer();

        }

        public void DrawVerticalLine(AsciiColor ch, Point location, uint height)
        {
            DrawVerticalLine(ch, location.X, location.Y, height);
        }

        public void DrawVerticalLine(AsciiColor ch, uint fx, uint fy, uint height)
        {
            //for (uint i = 0; i < height; i++)
            //    m_console.SetChar(x, y + i, ch);
        }       

        public void DrawImage(uint x, uint y, Image image)
        {
            var buffer = m_console.GetBuffer();
            uint counter = 0;
            for (uint imgY = 0; imgY < image.Height; imgY++)
            {
                if (m_console.Height <= imgY + y) break;

                for (uint imgX = 0; imgX < image.Width; imgX++)
                {
                    if (m_console.Width <= imgX + x) break;

                    buffer[((imgY + y) * m_console.Width) + (imgX + x)]  = image[counter++];
                }
            }

            //var xOffset = x;
            //var yOffset = y;
            
            //for (uint imgY = 0; imgY < image.Height; imgY++)
            //{
            //    var y1 = imgY + yOffset;
            //    if (y1 >= m_console.Height) break; 

            //    for (uint imgX = 0; imgX < image.Width; imgX++)
            //    {
            //        var x1 = imgX + xOffset;                   
            //        if (x1 >= m_console.Width) break;

            //        buffer[(y1*image.Width) + x1] = image[(imgY*image.Width) + imgX];
            //    }
            //}

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
            fromCharImage.Clear();
            return fromCharImage;
        }

        public static AsciiGraphics FromManagedConsole()
        {
            var fromManagedConsole = new AsciiGraphics(new ManagedConsole());
            fromManagedConsole.Clear();
            return fromManagedConsole;
        }

        public static AsciiGraphics FromUnManagedConsole()
        {
            var fromUnManagedConsole = new AsciiGraphics(new UnManagedConsole());
            fromUnManagedConsole.Clear();
            return fromUnManagedConsole;
        }
    }
}