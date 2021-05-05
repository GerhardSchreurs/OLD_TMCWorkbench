using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls
{
    public partial class ControlEditableList : UserControl
    {
        public ControlEditableList()
        {
            InitializeComponent();

            gridGroups.DataSource = DB.DBManager.Instance.C.Database.SqlQuery<string>("");

            
        }
    }
}
