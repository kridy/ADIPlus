namespace ADIPlus.Drawing
{
    public abstract class ConsoleAdabter
    {
        protected AsciiColor[] m_buffer;

        public AsciiColor[] GetBuffer()
        {
            return m_buffer;
        }

        public abstract void Invalidate();
        
        public uint Width { get; private set; }
        public uint Height { get; private set; }

        protected ConsoleAdabter(uint width, uint height)
        {
            Width = width;
            Height = height;

            m_buffer =new AsciiColor[width * height]; 
        }       

        public void Clear()
        {
            Clear(AsciiColor.empty);
        }

        public void Clear(AsciiColor color)
        {
            m_buffer.Init(color);
            Invalidate();
        }
    }
}