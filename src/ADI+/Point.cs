namespace ADIPlus.Drawing
{
    public class Point
    {
        private readonly uint m_x;
        private readonly uint m_y;

        public Point(uint x, uint y)
        {
            m_x = x;
            m_y = y;
        }

        public uint Y
        {
            get { return m_y; }
        }

        public uint X
        {
            get { return m_x; }
        }

        public Point XIncremented(uint incrementBy = 1)
        {
            return new Point(m_x + incrementBy, m_y);
        }

        public Point YIncremented(uint incrementBy = 1)
        {
            return new Point(m_x, m_y + incrementBy);
        }

        public Point XDecremented(uint decrementBy = 1)
        {
            return new Point(m_x - decrementBy, m_y);
        }

        public Point YDecremented(uint decrementBy = 1)
        {
            return new Point(m_x, m_y - decrementBy);
        }
    }
}