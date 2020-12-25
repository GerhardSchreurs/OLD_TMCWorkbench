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

   
        public string GetStringValue()
        {
            var value = string.Empty;

            if (ddList.SelectedIndex > 0)
            {
                dynamic item = ddList.SelectedItem;
                value = item.Name;
            }

            return value;
        }

        public int GetIntValue()
        {
            var value = 0;

            if (ddList.SelectedValue.IsNumeric())
            {
                value = ddList.SelectedValue.ToInt();
            }

            return value;
        }
    }
}
