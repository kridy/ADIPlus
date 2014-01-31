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
        }

        public override void SetChar(uint x, uint y, AsciiColor ch)
        {
            m_image[(Width*y) + x] = ch;
        }

        public override uint Width
        {
            get { return (uint)Console.WindowWidth; }
        }

        public override uint Height
        {
            get { return (uint)Console.WindowHeight; }

        }
    }
}