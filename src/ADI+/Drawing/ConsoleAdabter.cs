using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ADIPlus.Drawing
{
    public abstract class ConsoleAdabter
    {
        protected AsciiColor m_clearColor;
        public abstract void RenderBuffer(AsciiColor[] color);
        public abstract void SetChar(uint x, uint y, AsciiColor color);
        public abstract uint Width { get; }
        public abstract uint Height { get; }

        protected ConsoleAdabter()
        {
            m_clearColor = AsciiColor.empty;
        }

        public virtual void DeferredRender() {}
        public virtual void AllowRender() {}        

        public void Clear()
        {
            Clear(AsciiColor.empty);
        }

        public void Clear(AsciiColor color)
        {
            m_clearColor = color;
            DoClear(m_clearColor);
        }

        protected abstract void DoClear(AsciiColor color);
    }

    
}