using System;

namespace ADIPlus.Drawing
{
    internal class ImageRenderSurface : RenderSurferce
    {
        private readonly Image m_image;

        public ImageRenderSurface(Image image)
            :base(image.Width, image.Height)
        {
            
            if (image == null)
                throw new ArgumentNullException("image");
				
            m_image = image;
        }

        public override void Invalidate(Rectangle rect)
        {
            for (var y = rect.Y; y < rect.Height + rect.Y; y++)
            for (var x = rect.X; x < rect.Width + rect.X; x++)
            {
                m_image[(y* rect.Width + x)] = m_buffer[(y* rect.Width + x)];
            }
         }

        internal override void InitializeBuffer()
        {
            m_buffer = new CellDescription[Width * Height];
            m_buffer.Init(AsciiColors.White);
        }
      
    }
}