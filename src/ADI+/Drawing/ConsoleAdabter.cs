namespace ADIPlus.Drawing
{
    public abstract class ConsoleAdabter
    {
        protected AsciiColor m_clearColor;
        public abstract void SetChar(uint x, uint y, AsciiColor color);
        public abstract uint Width { get; }
        public abstract uint Height { get; }

        protected ConsoleAdabter()
        {
            m_clearColor = AsciiColor.Empty();
        }

        public virtual void DeferredRender() {}
        public virtual void AllowRender() {}        

        public void Clear()
        {
            Clear(AsciiColor.Empty());
        }

        public void Clear(AsciiColor color)
        {
            m_clearColor = color;
            DoClear(m_clearColor);
        }

        protected abstract void DoClear(AsciiColor color);
    }
}