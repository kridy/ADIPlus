namespace ADIPlus.Drawing
{
    internal static class AsciiUtil
    {
        internal static void Init(this Image image, AsciiColor color)
        {
            for (uint i = 0; i < image.Size; i++)
                image[i] = new CellDescription(' ', color); ;
        }

        internal static void Init(this CellDescription[] image, AsciiColor color)
        {
            for (uint i = 0; i < image.Length; i++)
                image[i] = new CellDescription(' ', color); ;
        }
    }

    public class Image
    {
        private readonly Rectangle m_rect;
        private readonly CellDescription[] m_buffer;

        public Image(uint width, uint height)
        {
            m_rect = new Rectangle(new Point(0,0), new Size(width,height));
            m_buffer = new CellDescription[m_rect.Width * m_rect.Height];
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

        internal CellDescription this[uint index]
        {
            get { return m_buffer[index]; }
            set { m_buffer[index] = value; }
        }
    }
}