namespace ADIPlus.Drawing
{
    public abstract class ConsoleAdabter
    {
        public abstract void SetChar(uint x, uint y, AsciiColor color);
        public abstract uint Width { get; }
        public abstract uint Height { get; }
    }
}