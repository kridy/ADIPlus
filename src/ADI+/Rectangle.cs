using System;

namespace ADIPlus.Drawing
{
    public class Rectangle
    {
        private static Rectangle Empty;
        private readonly Point m_location;
        private readonly Size m_size;

        private Rectangle()
            :this(0,0,0,0)
        { }

        public Rectangle(uint x, uint y, uint width, uint height)
            : this(new Point(x, y), new Size(width, height))
        { }

        public Rectangle(Point location, Size size)
        {
            m_location = location;
            m_size = size;
        }

        public Point Location
        {
            get { return m_location; }
        }

        public Size Size
        {
            get { return m_size; }
        }

        public uint X
        {
            get { return m_location.X; }
        }

        public uint Y
        {
            get { return m_location.Y; }
        }

        public uint Width
        {
            get { return m_size.Width; }
        }

        public uint Height
        {
            get { return m_size.Height; }
        }

        public Rectangle Intersect(Rectangle rect)
        {
            return Intersect(rect, this);            
        }
        
        public static Rectangle Intersect(Rectangle a, Rectangle b)
        {
            var x = Math.Max(a.X, b.X);
            var num2 = Math.Min((a.X + a.Width), (b.X + b.Width));
            var y = Math.Max(a.Y, b.Y);
            var num4 = Math.Min((a.Y + a.Height),(b.Y + b.Height));
            if ((num2 >= x) && (num4 >= y))
            {
                return new Rectangle(x, y, num2 - x, num4 - y);
            }
            return Empty;
        }
        
        public bool IntersectsWith(Rectangle rect)
        {
            return ((((rect.X < (this.X + this.Width)) && 
                (this.X < (rect.X + rect.Width))) && 
                (rect.Y < (this.Y + this.Height))) && 
                (this.Y < (rect.Y + rect.Height)));
        }

        public uint Area {
            get { return Width * Height; }
        }

        public uint Circumference
        {
            get { return (Width * 2) + (Height*2); }
        }
    }
}