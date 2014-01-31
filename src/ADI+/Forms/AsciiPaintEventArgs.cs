using ADIPlus.Drawing;

namespace ADIPlus.Forms
{
    public class AsciiPaintEventArgs
    {
        public AsciiPaintEventArgs(AsciiGraphics graphics, Rectangle clipRect)
        {
            Graphics = graphics;
            ClipRectangle = clipRect;
        }

        public AsciiGraphics Graphics { get; set; }
        public Rectangle ClipRectangle { get; set; }
    }
}
