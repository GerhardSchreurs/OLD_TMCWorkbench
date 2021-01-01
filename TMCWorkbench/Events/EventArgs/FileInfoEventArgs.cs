using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Events.EventArgs
{
    public class FileInfoEventArgs
    {
        public FileInfoEventArgs(string fullName)
        {
            FullName = fullName;
        }

        public string FullName;
    }
}
