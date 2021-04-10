using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static string ToLow(this object value)
        {
            if (value == null) return string.Empty;
            return value.ToString().ToLower();
        }

        //TODO: Use https://www.nuget.org/packages/FastMember?
        public static object GetPropertyValue(this object obj, string propName)
        {
            return obj.GetType().GetProperty(propName).GetValue(obj, null);
        }

        //TODO: Use https://www.nuget.org/packages/FastMember?
        public static void SetPropertyValue(this object obj, string propName, object value)
        {
            obj.GetType().GetProperty(propName).SetValue(obj, value, null);
        }
    }
}
