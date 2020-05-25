using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Helpers
{
    public static class MillisecondsConverter
    {
        public static Tuple<int, int> ConvertToMinutesAndSeconds(long ms)
        {
            var timeSpan = TimeSpan.FromMilliseconds(ms);

            var minutes = (timeSpan.Hours * 60) + timeSpan.Minutes;
            var seconds = timeSpan.Seconds;

            return new Tuple<int, int>(minutes, seconds);
        }
    }
}
