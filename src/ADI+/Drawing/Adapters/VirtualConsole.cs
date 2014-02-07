using System;

namespace ADIPlus.Drawing
{
    internal class VirtualConsole : ConsoleAdabter
    {
        private readonly Image m_image;

        public VirtualConsole(Image image)
            :base(image.Width, image.Height)
        {
            
            if (image == null)
                throw new ArgumentNullException("image");
				
            m_image = image;
        }

        public override void Invalidate(Rectangle rectangle)
        {
            for (var i = 0; i < m_buffer.Length; i++)
            {
                m_image[(uint) i] = m_buffer[i];
            }
        }
      
    }
}