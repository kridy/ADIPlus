using System;
namespace ADIPlus.Drawing
{
    internal abstract class RenderSurferce : IDisposable
    {
        protected AsciiPen[] m_buffer;

        public AsciiPen[] GetBuffer()
        {
            return m_buffer;
        }

        public abstract void Invalidate();

        public uint X { get { return ClientRectangle.X; } }
        public uint Y { get { return ClientRectangle.Y; } }
        public uint Width { get { return ClientRectangle.Width; } }
        public uint Height { get { return ClientRectangle.Height; } }
        
        public Rectangle ClientRectangle { get; private set; }

        protected RenderSurferce(uint width, uint height)
        {
            ClientRectangle = new Rectangle(0, 0, width, height);
        }

        internal abstract void InitializeBuffer();

        public void Clear()
        {
            Clear(AsciiColors.White);
        }

        public void Clear(AsciiColor color)
        {
            m_buffer.Init(color);
            Invalidate();
        }

        public virtual void Dispose(){}
    }
}