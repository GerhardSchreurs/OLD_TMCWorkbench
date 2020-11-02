using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench
{
    public static class IntegerExtensions
    {
        public static string ToStr(this int i)
        {
            return i.ToString(CultureInfo.InvariantCulture);
        }
    }
}
