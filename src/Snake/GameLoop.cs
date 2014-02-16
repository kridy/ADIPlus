using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Snake
{
    /// <summary>
    /// Vary vary basic gameloop
    /// </summary>
    internal class GameLoop
    {
        private readonly Game _game;

        public GameLoop(Game game)
        {
            _game = game;
        }

        public void Start()
        {
            _game.Start();

            double last = Timer.GetHighResTime();
            double start = Timer.GetHighResTime();
            double diff = 0.0;
            double accu = 0.0;
            double frameCount = 30;
            double frameTime = 1 / frameCount;

            while (_game.Started)
            {
                start = Timer.GetHighResTime();
                diff = start - last;
                last = start;

                if (diff > 0.25)
                    diff = 0.25;

                 accu += diff;

                while (accu >= frameTime)
                {
                    _game.Update(0, frameTime);
                    accu -= frameTime;
                }

                _game.Render();
            }

        }
    }


    public class Timer
    {
        [DllImport("KERNEL32")]
        private static extern bool QueryPerformanceCounter(
            out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        private static long frequency;

        static Timer()
        {
            if (QueryPerformanceFrequency(out frequency) == false)
            {
                // Frequency not supported
                throw new Win32Exception();
            }
        }

        public static double GetHighResTime()
        {
            long start;
            QueryPerformanceCounter(out start);
            
            return start / (double)frequency;
        }
    }
}