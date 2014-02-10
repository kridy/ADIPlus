namespace ADIPlus.Drawing
{
    internal static class AsciiUtil
    {
        public static void Init(this Image image, AsciiPen initPen)
        {
            for (uint i = 0; i < image.Size; i++)
                image[i] = initPen;
        }

        internal static void Init(this AsciiPen[] image, AsciiPen initPen)
        {
            for (uint i = 0; i < image.Length; i++)
                image[i] = initPen;
        }
    }

    public class Image
    {
        private readonly Rectangle m_rect;
        private readonly AsciiPen[] m_buffer;

        public Image(uint width, uint height)
        {
            m_rect = new Rectangle(new Point(0,0), new Size(width,height));
            m_buffer = new AsciiPen[m_rect.Width * m_rect.Height];
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

        public AsciiPen this[uint index]
        {
            get { return m_buffer[index]; }
            set { m_buffer[index] = value; }
        }


    }
}