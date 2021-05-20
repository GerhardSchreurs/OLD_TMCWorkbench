using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Dialogs
{
    public partial class DialogBase : Form
    {
        private bool _closeWithEscape = true;

        public bool CloseWithEscape
        {
            get => _closeWithEscape;
            set => _closeWithEscape = value;
        }

        public DialogBase()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (CloseWithEscape == false) return base.ProcessCmdKey(ref msg, keyData);

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
