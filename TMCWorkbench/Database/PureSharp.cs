using Puresharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMCWorkbench.Database.Attributes;

namespace TMCWorkbench.Database
{
    /****************************************
    POINTCUT
    ****************************************/
    public class ColPointCut : Pointcut<Col> { }

    /****************************************
    ADVICE
    ****************************************/
    public class ColAdvice : IAdvice
    {
        private MethodBase m_Method;

        public ColAdvice(MethodBase method)
        {
            this.m_Method = method;
        }

        public void Instance<T>(T instance)
        {
        }

        public void Argument<T>(ref T value)
        {
        }

        public void Begin()
        {
            var type = this.GetType();

            Debug.WriteLine(this.m_Method);
        }

        public void Await(MethodInfo method, Task task)
        {
        }

        public void Await<T>(MethodInfo method, Task<T> task)
        {
        }

        public void Continue()
        {
        }

        public void Throw(ref Exception exception)
        {
        }

        public void Throw<T>(ref Exception exception, ref T value)
        {
        }

        public void Return()
        {
        }

        public void Return<T>(ref T value)
        {
        }

        public void Dispose()
        {
        }
    }

    /****************************************
    ASPECT
    ****************************************/
    public class ColAspect : Aspect
    {
        override public IEnumerable<Advisor> Manage(MethodBase method)
        {
            yield return Advice
                .For(method)
                .Around(() => new ColAdvice(method));
        }
    }
}
