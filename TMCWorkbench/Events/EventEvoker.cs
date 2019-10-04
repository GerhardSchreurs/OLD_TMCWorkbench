using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCWorkbench.Events.EventArgs;

namespace TMCWorkbench.Events
{
    public static class EventInvoker
    {
        public delegate void BrowseEventArgsDelegate(object sender, BrowseEventArgs playEventArgs);
        public static event BrowseEventArgsDelegate OnBrowse;

        public static void RaiseOnBrowse(object sender, DirectoryInfo directoryInfo)
        {
            OnBrowse?.Invoke(sender, new BrowseEventArgs(directoryInfo));
        }
    }
}
