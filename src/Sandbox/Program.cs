using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ADIPlus.Drawing;

namespace Sandbox
{
    public static class TimeUtil
    {
        public static TimeSpan MeasureTime(Action action)
        {
            var start = DateTime.Now;
            action.Invoke();
            return DateTime.Now - start;
        }

        public static TimeInfo MeasureAverageTime(Action action, int count)
        {
            var info = new TimeInfo();

            for (var i = 0; i < count; i++)
            {
                var start = DateTime.Now;
                action.Invoke();
                info.Add(DateTime.Now - start);
            }
            return info;
        }

        public class TimeInfo
        {
            private List<TimeSpan> m_times = new List<TimeSpan>();

            public List<TimeSpan> Times
            {
                get { return m_times; }
                set { m_times = value; }
            }

            public void Add(TimeSpan duration)
            {
                m_times.Add(duration);
            }

            public TimeSpan Total
            {
                get
                {
                    return m_times.Aggregate((total, current) => total += current);
                }
            }

            public TimeSpan Average
            {
                get
                {
                    return new TimeSpan(Total.Ticks/Times.Count);                    
                }
            }
        }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var width = Console.WindowWidth;
            var height = Console.WindowHeight;

            var backbuffer = new Image((uint) width, (uint) height);
            using(var bufferRender = AsciiGraphics.FromCharImage(backbuffer))
            using (var displayRender = AsciiGraphics.FromUnManagedConsole())
            {
                do
                {
                    var time = TimeUtil.MeasureAverageTime(() =>
                                {
                                    for (uint i = 0; i < height; i++)
                                    {
                                        bufferRender.DrawHorizontalLine(
                                            GetRandomColorAscii(random),
                                            new Point(0, i), backbuffer.Width);
                                        //bufferRender.DrawVerticalLine(
                                        //    GetRandomColorAscii(colors, random), new Point(i, 0),
                                        //    (uint) height);
                                    }
                                    displayRender.DrawImage(0, 0, backbuffer);
                                }, 1);


                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }

        private static AsciiPen GetRandomColorAscii(Random random)
        {

            return new AsciiPen('*', GetRandomColor(random));
        }

        private static AsciiColor GetRandomColor(Random random)
        {
            return new AsciiColor(
                (ConsoleColor)random.Next(0, 16), 
                (ConsoleColor)random.Next(0, 16));
        }
    }
}