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
        //TODO: Better name?
        public static T GetValueFromAnnonymousType<T>(this object src, string itemkey)
        {
            Type type = src.GetType();
            T itemvalue = (T)type.GetProperty(itemkey).GetValue(src, null);
            return itemvalue;
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static bool IsNumeric(this object src)
        {
            if (src == null) { return false; }
            var s = src.ToString();
            return StringExtensions.IsNumeric(s);
        }

        public static int ToInt(this object src)
        {
            return Converter.ToInt32(src);
        }

        public static string ToStr(this object src)
        {
            if (src == null) return string.Empty;
            return src.ToString();
        }

        public static string ToLow(this object src)
        {
            if (src == null) return string.Empty;
            return src.ToString().ToLower();
        }

        public static double ToDbl(this object src)
        {
            if (src == null) return 0;
            return Converter.ToDouble(src);
        }

        //TODO: Use https://www.nuget.org/packages/FastMember?
        public static object GetPropertyValue(this object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        //TODO: Use https://www.nuget.org/packages/FastMember?
        public static void SetPropertyValue(this object src, string propName, object value)
        {
            src.GetType().GetProperty(propName).SetValue(src, value, null);
        }
    }
}
