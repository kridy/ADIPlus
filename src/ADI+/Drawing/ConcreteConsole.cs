using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADIPlus.Drawing
{
    public class PixelDescriptionCollection : IEnumerable<PixelDescription>
    {
        private readonly List<PixelDescription> m_pixelDescriptions;

        public PixelDescriptionCollection()
        {
            m_pixelDescriptions = new List<PixelDescription>();
        }

        public void Add(AsciiColor color, uint x, uint y)
        {
            Add(color, new Point(x,y));
        }

        public void Add(AsciiColor color, Point location)
        {
            m_pixelDescriptions.Add(new PixelDescription(color, location));
        }

        public void AlignPixelData()
        {
            m_pixelDescriptions.OrderBy(pxd => pxd.Location.Y).ThenBy(pxd => pxd.Location.Y);
        }

        public IEnumerator<PixelDescription> GetEnumerator()
        {
            return m_pixelDescriptions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }

    public class PixelDescription
    {
        public PixelDescription(AsciiColor color, Point location)
        {
            Color = color;
            Location = location;
        }

        public AsciiColor Color { get; private set; }
        public Point Location { get; private set; }
    }

    internal class ConcreteConsole : ConsoleAdabter
    {
        private bool m_isRenderingDeffered;

        public ConcreteConsole()
        {
            Console.CursorVisible = false;
            m_isRenderingDeffered = false;
        }

        public override void SetChar(uint x, uint y, AsciiColor color)
        {
            if (m_isRenderingDeffered)
            {
                pxCol.Add(color, x, y);
                return;
            }

            Console.BackgroundColor = color.BackgroundColor;
            Console.ForegroundColor = color.ForgroundColor;
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write(color.Character);
        }


        private PixelDescriptionCollection pxCol; 

        public override void DeferredRender()
        {
            if (m_isRenderingDeffered) return;

            pxCol = new PixelDescriptionCollection();
            
            m_isRenderingDeffered = true;
        }

        public override void AllowRender()
        {
            if (!m_isRenderingDeffered) return;
            
            var sb = new StringBuilder();
            var startLocation = new Point(0,0);
            var foregroundColor = ConsoleColor.Black;
            var backgroundColor = ConsoleColor.Black;

            pxCol.AlignPixelData();

            var value = pxCol.GroupBy(description => description.Location.Y);


            //foreach (var pxd in pxCol)
            //{             
            //    if (prevY == pxd.Location.Y)
            //    {
            //        if (sb.Length == 0)
            //        {
            //            foregroundColor = pxd.Color.ForgroundColor;
            //            backgroundColor = pxd.Color.BackgroundColor;

            //            startLocation = pxd.Location;
            //        }

            //        sb.Append(pxd.Color.Character);
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = foregroundColor;
            //        Console.BackgroundColor = backgroundColor;
            //        Console.SetCursorPosition((int)startLocation.X, (int)startLocation.Y);
            //        Console.Write(sb.ToString());
            //        sb.Clear();
            //        prevY = (int)pxd.Location.Y;
            //    }
            //}

            

            m_isRenderingDeffered = false;
        }

        public override uint Width
        {
            get { return (uint)Console.WindowWidth; }
        }

        public override uint Height
        {
            get { return (uint)Console.WindowHeight; }
        }

        protected override void DoClear(AsciiColor color)
        {
            Console.Clear();
        }
    }
}