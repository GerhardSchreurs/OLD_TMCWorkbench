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
        public FileInfoEventArgs(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }

        public FileInfo FileInfo;
    }
}
