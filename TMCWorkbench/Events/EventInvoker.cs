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
        public delegate void BrowseEventArgsDelegate(object sender, DirectoryInfoEventArgs directoryInfoEventArgs);
        public static event BrowseEventArgsDelegate OnBrowserControlBrowse;

        public delegate void ListViewSelectedEventArgsDelegate(object sender, FileInfoEventArgs fileinfoEventArgs);
        public static event ListViewSelectedEventArgsDelegate OnListViewControlSelected;


        public static void RaiseOnBrowse(object sender, DirectoryInfo directoryInfo)
        {
            OnBrowserControlBrowse?.Invoke(sender, new DirectoryInfoEventArgs(directoryInfo));
        }

        public static void RaiseOnListViewSelected(object sender, FileInfo fileInfo)
        {
            OnListViewControlSelected?.Invoke(sender, new FileInfoEventArgs(fileInfo));
        }
    }
}
