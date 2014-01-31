using System;

namespace ADIPlus.Drawing
{
    internal class VirtualConsole : ConsoleAdabter
    {        
        public VirtualConsole(CharImage image)
        {
            
        }

        public override void SetChar(uint x, uint y, AsciiColor ch)
        {
            
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