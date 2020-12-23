using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Extensions
{
    public static class EnumExtensions
    {
        public static string GetValue(this Enum @enum)
        {
            var attr =
                @enum.GetType().GetMember(@enum.ToString()).FirstOrDefault()?.
                    GetCustomAttributes(false).OfType<EnumMemberAttribute>().
                    FirstOrDefault();
            if (attr == null)
                return @enum.ToString();
            return attr.Value;
        }
    }
}
