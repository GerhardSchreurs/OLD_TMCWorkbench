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

        public static void RaiseOnBrowse(object sender, DirectoryInfo directoryInfo)
        {
            OnBrowserControlBrowse?.Invoke(sender, new DirectoryInfoEventArgs(directoryInfo));
        }

        public delegate void ListViewSelectedEventArgsDelegate(object sender, string fullName, bool isInDB, Guid guid);
        public static event ListViewSelectedEventArgsDelegate OnListViewBrowserControlSelected;

        public static void RaiseOnBrowserListViewSelected(object sender, string fileName, bool isInDB, Guid guid)
        {
            OnListViewBrowserControlSelected?.Invoke(sender, fileName, isInDB, guid);
        }

        public delegate void ListViewTrackSelectedEventArgsDelegate(object sender, int trackId, Guid guid, string fileName);
        public static event ListViewTrackSelectedEventArgsDelegate OnListViewTrackControlSelected;

        public static void RaiseOnTrackListViewSelected(object sender, int trackId, Guid guid, string fileName)
        {
            OnListViewTrackControlSelected?.Invoke(sender, trackId, guid, fileName);
        }
    }
}
