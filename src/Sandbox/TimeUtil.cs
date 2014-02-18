using System;
using System.Collections.Generic;
using System.Linq;

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
                action();
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
                    return m_times.Aggregate((total, current) => total + current);
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
}