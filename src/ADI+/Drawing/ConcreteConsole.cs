using System;
using System.Collections.Generic;
using System.Text;

namespace ADIPlus.Drawing
{
    internal class ConcreteConsole : ConsoleAdabter
    {
        private bool m_isRenderingDeffered;

        public ConcreteConsole()
        {
            Console.CursorVisible = false;
            m_isRenderingDeffered = false;
        }

        private ConsoleColor fc = ConsoleColor.Black; 
        private ConsoleColor bc = ConsoleColor.Black;
        private StringBuilder builder = new StringBuilder();
        private int m_startX = 0;
        private int m_prevX = 0;
        private int m_startY = 0;

        public override void SetChar(uint x, uint y, AsciiColor color)
        {
            if (m_isRenderingDeffered)
            {
                if (fc == color.ForgroundColor && 
                    bc == color.BackgroundColor && 
                    m_startY == y && 
                    (m_prevX +1) == x)
                {
                    builder.Append(color.Character);
                }
                else
                {
                    Console.ForegroundColor =color.ForgroundColor;
                    Console.BackgroundColor = color.BackgroundColor;
                    Console.SetCursorPosition(m_startX,m_startY);
                    Console.Write(builder.ToString());
                    m_startX = (int)x;
                    m_prevX = (int) x;
                    m_startY = (int) y;
                    fc = color.ForgroundColor;
                    bc = color.BackgroundColor;
                }
                return;
            }

            Console.BackgroundColor = color.BackgroundColor;
            Console.ForegroundColor = color.ForgroundColor;
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write(color.Character);
        }

        public override void DeferredRender()
        {
            fc = ConsoleColor.Black;
            bc = ConsoleColor.Black;
            builder = new StringBuilder();
            m_startX = 0;
            m_prevX = 0;
            m_startY = 0;
            m_isRenderingDeffered = true;
        }

        public override void AllowRender()
        {
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