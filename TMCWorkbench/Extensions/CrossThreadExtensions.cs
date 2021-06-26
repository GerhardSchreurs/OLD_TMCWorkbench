using System;
using System.Windows.Forms;

namespace TMCWorkbench
{
    public static class CrossThreadExtensions
    {
        public static void Do(this Control target, Action action)
        {
            if (target.InvokeRequired)
            {
                target.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        public static void Do<T1>(this Control target, Action<T1> action, T1 parameter)
        {
            if (target.InvokeRequired)
            {
                target.BeginInvoke(action, parameter);
            }
            else
            {
                action(parameter);
            }
        }

        public static void Do<T1, T2>(this Control target, Action<T1, T2> action, T1 p1, T2 p2)
        {
            if (target.InvokeRequired)
            {
                target.BeginInvoke(action, p1, p2);
            }
            else
            {
                action(p1, p2);
            }
        }
    }
}
