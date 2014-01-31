namespace ADIPlus.Drawing
{
    internal static class AsciiUtil
    {
        public static void Init(this AsciiColor[] buffer)
        {
            for (var i = 0; i < buffer.Length; i++)
                buffer[i] = AsciiColor.Empty();
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
            m_buffer.Init();
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