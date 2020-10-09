using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCWorkbench.Tools;

namespace Extensions
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
            return Extensions.StringExtensions.IsNumeric(s);
        }

        public static int ToInt(this object value)
        {
            return Converter.ToInt32(value);
        }

    }
}
