using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCWorkbench.Tools;

namespace TMCWorkbench
{
    public static class ObjectExtensions
    {
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static bool IsNumeric(this object value)
        {
            if (value == null) { return false; }
            var s = value.ToString();
            return StringExtensions.IsNumeric(s);
        }

        public static int ToInt(this object value)
        {
            return Converter.ToInt32(value);
        }

        public static string ToStr(this object value)
        {
            if (value == null) return string.Empty;
            return value.ToString();
        }
    }
}
