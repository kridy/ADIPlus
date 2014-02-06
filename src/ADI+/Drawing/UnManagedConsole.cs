namespace ADIPlus.Drawing
{
    public class UnManagedConsole : ConsoleAdabter {
        private uint m_width;
        private uint m_height;

        public override void SetChar(uint x, uint y, AsciiColor color)
        {
            throw new System.NotImplementedException();
        }

        public override uint Width
        {
            get { return m_width; }
        }

        public override uint Height
        {
            get { return m_height; }
        }

        protected override void DoClear(AsciiColor color)
        {
            throw new System.NotImplementedException();
        }
    }
}