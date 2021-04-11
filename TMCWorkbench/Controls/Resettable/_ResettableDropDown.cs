using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class _ResettableDropDown : _ResettablePanel
    {
        public _ResettableDropDown()
        {
            InitializeComponent();
        }

        public int GetValue()
        {
            return this.ddList.SelectedValue.ToInt();
        }
    }
}
