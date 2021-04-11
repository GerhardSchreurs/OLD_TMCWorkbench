using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Controls.Resettable
{
    interface IRefreshableInit
    {
        void Init(bool refresh = false);
    }
}
