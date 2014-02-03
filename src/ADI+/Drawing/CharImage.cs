namespace ADIPlus.Drawing
{
    internal static class AsciiUtil
    {
        public static void Init(this CharImage image, AsciiColor initColor)
        {
            for (uint i = 0; i < image.Size; i++)
                image[i] = initColor;
        }
    }

    public class CharImage
    {
        private readonly uint m_width;
        private readonly uint m_height;
        private readonly AsciiColor[] m_buffer;

        public CharImage(uint width, uint height)
        {
            m_width = width;
            m_height = height;
            m_buffer = new AsciiColor[width * height];
        }

        public int Size 
        {
            get { return m_buffer.Length; }
        }

        public uint Width
        {
            get { return m_width; }
        }

        public uint Height
        {
            get { return m_height; }
        }

        public AsciiColor this[uint index]
        {
            get { return m_buffer[index]; }
            set { m_buffer[index] = value; }
        }
    }
}