using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Events.EventArgs
{
    public class BrowseEventArgs
    {
        public BrowseEventArgs(DirectoryInfo directoryInfo)
        {
            DirectoryInfo = directoryInfo;
        }

        public DirectoryInfo DirectoryInfo;
    }
}
