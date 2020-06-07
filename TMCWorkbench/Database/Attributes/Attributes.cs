using AwesomeProxy;
using AwesomeProxy.FilterAttribute;
using Newtonsoft.Json;
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

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited =false)]
    public class Col : Attribute
    {
        public Col([CallerMemberName] string propertyName = null)
        {
        }

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

    public class RowAttribute : AopBaseAttribute
    {
        public override void OnExecuted(ExecutedContext result)
        {
            Console.WriteLine(JsonConvert.SerializeObject(result.Args));
        }

        public override void OnExecuting(ExecutingContext args)
        {
            //Console.WriteLine($"Inkomende parameters:{JsonConvert.SerializeObject(args.Args)}");
        }
    }
}
