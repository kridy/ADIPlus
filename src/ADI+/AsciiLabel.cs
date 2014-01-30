namespace ADIPlus
{
    public class AsciiLabel : AsciiControle
    {
        public override void OnPaint(AsciiPaintEventArgs e)
        {
            var rect = e.ClipRectangle;
            var g = e.Graphics;
        }

        public string Text { get; set; }
    }
}