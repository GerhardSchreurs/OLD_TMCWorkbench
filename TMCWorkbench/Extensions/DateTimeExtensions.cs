using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDateString(this DateTime d)
        {
            return d.ToString("yyyy/dd/MM (MMM)", CultureInfo.InvariantCulture);
        }
    }
}
