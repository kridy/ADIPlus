using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADIPlus;

namespace Sandbox
{
    class Program
    {


        static void Main(string[] args)
        {
            //var form = new Form();
            //form.Controls.Add(new MyClass(){ Location = new Point(10,10), Size = new Size(100,40)});            
            //Application.Run(form);



            //var cForm = new AsciiForm();
            //cForm.Controle.Add(new AsciiLabel(){Text = "Helloworld"});
            //AsciiApplication.Run(cForm);

        }

        
    }

    class MyClass :Control
    {
        public MyClass()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawString("Hello", new Font("Arial",12), Brushes.Black, 0, 0);
        }
    }

    
}
