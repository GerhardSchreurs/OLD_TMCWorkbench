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
    public partial class ResettableTextArea : UserControl
    {
        public ResettableTextArea()
        {
            InitializeComponent();
        }

        public string LabelTitle
        {
            get => ctrResettable.Title;
            set => ctrResettable.Title = value;
        }

        public override string Text
        {
            get => txtArea.Text;
            set => txtArea.Text = value;
        }
    }
}
