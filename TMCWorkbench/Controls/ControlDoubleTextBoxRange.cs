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
    public partial class ControlDoubleTextBoxRange : UserControl
    {
        public bool AllowsNegatives
        {
            get => ctrDoubleTextbox.AllowsNegatives;
            set => ctrDoubleTextbox.AllowsNegatives = value;
        }

        public int MaxValue
        {
            get => ctrDoubleTextbox.MaxValue;
            set => ctrDoubleTextbox.MaxValue = value;
        }

        public int MinValue
        {
            get => ctrDoubleTextbox.MinValue;
            set => ctrDoubleTextbox.MinValue = value;
        }

        public double? Result
        {
            get => ctrDoubleTextbox.Result;
            set => ctrDoubleTextbox.Result = value;
        }

        public string Modifier
        {
            get
            {
                if (ddlRange.SelectedIndex <= 0)
                    return null;

                return ddlRange.SelectedItem.ToStr();
            }
            set
            {
                if (value.IsNullOrEmpty())
                    ddlRange.SelectedIndex = 0;
                if (value == "=" || value == "==")
                    ddlRange.SelectedIndex = 1;
                if (value == "<" || value == "<=")
                    ddlRange.SelectedIndex = 2;
                if (value == ">" || value == ">=")
                    ddlRange.SelectedIndex = 4;
            }
        }

        public ControlDoubleTextBoxRange()
        {
            InitializeComponent();
        }
    }
}
