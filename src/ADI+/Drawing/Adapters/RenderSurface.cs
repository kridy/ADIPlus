using System;
namespace ADIPlus.Drawing
{
    internal class CellDescription
    {
        public CellDescription(char character, AsciiColor color)
        {
            Character = character;
            Color = color;
        }

        public char Character { get; set; }
        public AsciiColor Color { get; set; }
    }

    internal abstract class RenderSurferce : IDisposable
    {
        protected CellDescription[] m_buffer;

        public CellDescription[] GetBuffer()
        {
            return m_buffer;
        }

        public void Invalidate()
        {
            Invalidate(ClientRectangle);
        }
        public abstract void Invalidate(Rectangle rect);

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
            Invalidate(ClientRectangle);
        }

        public virtual void Dispose(){}
    }
}