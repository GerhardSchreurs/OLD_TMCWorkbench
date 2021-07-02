using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Tools
{
    public static class ObjectCollater
    {
        public static bool AreEqual<T>(List<T> list1, List<T> list2)
        {
            var s1 = JsonConvert.SerializeObject(list1);
            var s2 = JsonConvert.SerializeObject(list2);

            var isEqual = s1 == s2;

            return isEqual;
        }

        public static bool NotEqual<T>(List<T> list1, List<T> list2)
        {
            return AreEqual(list1, list2) == false;
        }


        public static bool AreEqual(object obj1, object obj2)
        {
            var obj1Serialized = JsonConvert.SerializeObject(obj1);
            var obj2Serialized = JsonConvert.SerializeObject(obj2);

            return obj1Serialized == obj2Serialized;
        }

        public static bool NotEqual(object obj1, object obj2)
        {
            return AreEqual(obj1, obj2) == false;
        }
    }
}
