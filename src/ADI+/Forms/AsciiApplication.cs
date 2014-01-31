namespace ADIPlus.Forms
{
    public class AsciiApplication
    {
        private AsciiForm m_asciiForm;

        private AsciiApplication(AsciiForm asciiForm)
        {
            m_asciiForm = asciiForm;
            m_asciiForm.Invalidate();
        }

        public static void Run(AsciiForm asciiForm)
        {
            var app = new AsciiApplication(asciiForm);

        }
    }
}