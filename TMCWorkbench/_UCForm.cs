using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench
{
    public partial class _UCForm : Form
    {
        private bool _isUCForm;

        public _UCForm()
        {
            InitializeComponent();

            if(_isUCForm)
            {
                this.TopLevel = false;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Dock = DockStyle.Fill;
            }
        }
    }
}
