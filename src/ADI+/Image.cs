namespace ADIPlus.Drawing
{
    internal static class AsciiUtil
    {
        public static void Init(this Image image, AsciiColor initColor)
        {
            for (uint i = 0; i < image.Size; i++)
                image[i] = initColor;
        }

        internal static void Init(this AsciiColor[] image, AsciiColor initColor)
        {
            for (uint i = 0; i < image.Length; i++)
                image[i] = initColor;
        }
    }

    public class Image
    {
        private readonly Rectangle m_rect;
        private readonly AsciiColor[] m_buffer;

        public Image(uint width, uint height)
        {
            m_rect = new Rectangle(new Point(0,0), new Size(width,height));
            m_buffer = new AsciiColor[m_rect.Width * m_rect.Height];
        }

        public int Size 
        {
            get { return m_buffer.Length; }
        }

        public uint Width
        {
            get { return m_rect.Width; }
        }

        public uint Height
        {
            get { return m_rect.Height; }
        }

        public Rectangle Rectangle {
            get { return m_rect; }
        }

        public AsciiColor this[uint index]
        {
            get { return m_buffer[index]; }
            set { m_buffer[index] = value; }
        }


    }
}