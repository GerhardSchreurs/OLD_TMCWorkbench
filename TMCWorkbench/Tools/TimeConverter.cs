using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Tools
{
    public static class TimeConverter
    {
        public static Tuple<int, int> ConvertToMinutesAndSeconds(long ms)
        {
            var timeSpan = TimeSpan.FromMilliseconds(ms);

            var minutes = (timeSpan.Hours * 60) + timeSpan.Minutes;
            var seconds = timeSpan.Seconds;

            return new Tuple<int, int>(minutes, seconds);
        }

        public static int ConvertToMilliseconds(int minutes, int seconds)
        {
           return (minutes * 60000) + (seconds * 1000);
        }
    }
}
