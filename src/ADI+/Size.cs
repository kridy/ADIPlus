namespace ADIPlus.Drawing
{
    public class Size
    {
        private readonly uint m_width;
        private readonly uint m_height;

        public Size(uint width, uint height)
        {
            m_width = width;
            m_height = height;
        }

        public uint Width
        {
            get { return m_width; }
        }

        public uint Height
        {
            get { return m_height; }
        }

        public Size WidthIncremented(uint incrementBy = 1)
        {
            return new Size(m_width + incrementBy, m_height);
        }

        public Size HeightIncremented(uint incrementBy = 1)
        {
            return new Size(m_width, m_height + incrementBy);
        }

        public Size WidthDecremented(uint decrementBy = 1)
        {
            return new Size(m_width - decrementBy, m_height);
        }

        public Size HeightDecremented(uint decrementBy = 1)
        {
            return new Size(m_width, m_height - decrementBy);
        }
    }
}