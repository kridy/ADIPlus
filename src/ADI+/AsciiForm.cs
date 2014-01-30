namespace ADIPlus
{
    public class AsciiForm
    {
        public AsciiForm()
        {
            Controle = new AsciiControlCollection();
        }

        public AsciiControlCollection Controle { get; private set; }
    }
}