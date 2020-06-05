using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Database.Attributes
{

    //[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    //public class ColIsAutoIndex : System.Attribute
    //{
    //}

    //[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    //public class ColIsID : System.Attribute
    //{
    //}

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited =false)]
    public class Col : Attribute
    {
        //public Col([CallerMemberName] string propertyName = null)
        //{
        //    Debug.WriteLine(propertyName);
        //}

        private bool _isPrimaryKey;
        private bool _isAutoIncrement;

        public bool IsPrimaryKey
        {
            get => _isPrimaryKey;
            set => _isPrimaryKey = value;
        }

        public bool IsAutoIncrement
        {
            get => _isAutoIncrement;
            set => _isAutoIncrement = value;
        }
    }
}
