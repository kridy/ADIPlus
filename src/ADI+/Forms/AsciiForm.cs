namespace ADIPlus.Forms
{
    public class AsciiForm : AsciiContainerControl
    {
        public AsciiForm()
        {
            Controle = new AsciiControlCollection();
        }

        public AsciiControlCollection Controle { get; private set; }

        public void Invalidate()
        {
            //OnPaint(new AsciiPaintEventArgs());
        }

        public override void OnPaint(AsciiPaintEventArgs e)
        {
            
        }
    }

    public abstract class AsciiContainerControl :AsciiControle
    {
        public AsciiControlCollection Control { get; set; }

        protected AsciiContainerControl()
        {
            Control = new AsciiControlCollection();
        }
    }
}