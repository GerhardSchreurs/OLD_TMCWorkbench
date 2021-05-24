﻿using System;
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

        public delegate void ListViewSelectedEventArgsDelegate(object sender, string fullName);
        public static event ListViewSelectedEventArgsDelegate OnListViewBrowserControlSelected;

        public static void RaiseOnBrowserListViewSelected(object sender, string fullName)
        {
            OnListViewBrowserControlSelected?.Invoke(sender, fullName);
        }

        public delegate void ListViewTrackSelectedEventArgsDelegate(object sender, int trackId);
        public static event ListViewTrackSelectedEventArgsDelegate OnListViewTrackControlSelected;

        public static void RaiseOnTrackListViewSelected(object sender, int trackId)
        {
            OnListViewTrackControlSelected?.Invoke(sender, trackId);
        }

        public delegate void TrackProcessedEventArgsDelegate(object sender, long time);
        public static event TrackProcessedEventArgsDelegate OnTrackProcessed;

        public static void RaiseOnTrackProcessed(object sender, long time)
        {
            OnTrackProcessed?.Invoke(sender, time);
        }
    }
}
