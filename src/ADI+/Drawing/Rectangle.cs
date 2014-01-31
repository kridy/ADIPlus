namespace ADIPlus.Drawing
{
    public class Rectangle
    {
        private readonly Point m_location;
        private readonly Size m_size;

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

        public uint Left
        {
            get { return m_location.X; }
        }

        public uint Top
        {
            get { return m_location.Y; }
        }

        public uint Right
        {
            get { return m_location.X + m_size.Width; }
        }

        public uint Buttom
        {
            get { return m_location.Y + m_size.Height; }
        }
    }
}