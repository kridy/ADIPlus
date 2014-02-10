using System;
namespace ADIPlus.Drawing
{
    internal abstract class ConsoleAdabter : IDisposable
    {
        protected AsciiColor[] m_buffer;

        public AsciiColor[] GetBuffer()
        {
            return m_buffer;
        }

        public abstract void Invalidate();

        public uint X { get; private set; }
        public uint Y { get; private set; }
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public Rectangle ClientRect { get; private set; }


        protected ConsoleAdabter(uint width, uint height)
        {
            X = 0;
            Y = 0;
            
            Width = width;
            Height = height;
            
            ClientRect = new Rectangle(X, Y, Width, Height);
        }

        internal abstract void InitializeBuffer();

        public void Clear()
        {
            Clear(AsciiColor.empty);
        }

        public void Clear(AsciiColor color)
        {
            m_buffer.Init(color);
            //TODO init buffer with content from the console.
            Invalidate();
        }

        public virtual void Dispose(){}
    }
}