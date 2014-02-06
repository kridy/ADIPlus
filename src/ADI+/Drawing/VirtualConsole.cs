using System;

namespace ADIPlus.Drawing
{
    internal class VirtualConsole : ConsoleAdabter
    {
        private readonly CharImage m_image;

        public VirtualConsole(CharImage image)
        {

            if (image == null)
                throw new ArgumentNullException("image");
				
            m_image = image;
            DoClear(m_clearColor);
        }

        public override void RenderBuffer(AsciiColor[] color)
        {
            throw new NotImplementedException();
        }

        public override void SetChar(uint x, uint y, AsciiColor ch)
        {
            m_image[(Width*y) + x] = ch;
        }

        public override uint Width
        {
            get { return m_image.Width; }
        }

        public override uint Height
        {
            get { return m_image.Height; }
        }

        protected override void DoClear(AsciiColor color)
        {
            m_image.Init(color);
        }
    }
}