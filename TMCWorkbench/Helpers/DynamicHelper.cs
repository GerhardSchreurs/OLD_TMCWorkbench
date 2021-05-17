using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Helpers
{
    public static class DynamicHelper
    {
        public static dynamic GetPropertyValueFromDynamic(dynamic item, string property)
        {
            //return item.GetPropertyValue(property);
            var propertyInfo = item.GetType().GetProperty(property);
            return propertyInfo.GetValue(item, null);
        }

        public static T GetPropertyValueFromDynamic<T>(object item, string property)
        {
            Type type = item.GetType();
            return (T)type.GetProperty(property).GetValue(item, null);
        }
    }
}
