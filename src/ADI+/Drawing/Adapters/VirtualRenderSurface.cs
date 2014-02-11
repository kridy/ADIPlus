using System;

namespace ADIPlus.Drawing
{
    internal class VirtualRenderSurface : RenderSurferce
    {
        private readonly Image m_image;

        public VirtualRenderSurface(Image image)
            :base(image.Width, image.Height)
        {
            
            if (image == null)
                throw new ArgumentNullException("image");
				
            m_image = image;
        }

        public override void Invalidate()
        {
            for (var i = 0; i < m_buffer.Length; i++)
            {
                m_image[(uint) i] = m_buffer[i];
            }
        }

        internal override void InitializeBuffer()
        {
            m_buffer = new AsciiPen[Width * Height];
            m_buffer.Init(AsciiColors.White);
        }
      
    }
}