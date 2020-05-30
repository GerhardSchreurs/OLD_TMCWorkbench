using System;
using System.Collections.Generic;
using System.Linq;
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

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class Col : Attribute
    {
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
