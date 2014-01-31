using ADIPlus.Drawing;

namespace ADIPlus.Forms
{
    public abstract class AsciiControle
    {
        public Point Location { get; set; }
        public Size Size { get; set; }

        public void Invalidate()
        {           
            var g = AsciiGraphics.FromConsole();
            var cRect = new Rectangle(0, 0, Size.Width, Size.Height);

            InvokePaint(this, new AsciiPaintEventArgs(g, cRect));
        }

        protected void InvokePaint(AsciiControle control, AsciiPaintEventArgs e)
        {
        }

        public virtual void OnPaint(AsciiPaintEventArgs e)
        {
        }
    }
}