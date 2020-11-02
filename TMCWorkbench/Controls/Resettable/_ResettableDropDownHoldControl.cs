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
    public partial class _ResettableDropDownHoldControl : _ResettableControlPanel
    {
        public _ResettableDropDownHoldControl()
        {
            InitializeComponent();
        }

        public string GetValue()
        {
            var value = string.Empty;

            if (ddList.SelectedIndex > 0)
            {
                value = ddList.SelectedValue.ToStr();
            }
          
            return value;
        }
    }
}
