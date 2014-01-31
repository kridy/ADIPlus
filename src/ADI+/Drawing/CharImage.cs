namespace ADIPlus.Drawing
{
    public class CharImage
    {
        private readonly uint m_width;
        private readonly uint m_height;
        private readonly AsciiColor[] buffer;

        public CharImage(uint width, uint height)
        {
            m_width = width;
            m_height = height;
            buffer = new AsciiColor[width * height];
        }

        public uint Width
        {
            get { return m_width; }
        }

        public uint Height
        {
            get { return m_height; }
        }

        public AsciiColor this[int index]
        {
            get { return buffer[index]; }
            set { buffer[index] = value; }
        }
    }
}