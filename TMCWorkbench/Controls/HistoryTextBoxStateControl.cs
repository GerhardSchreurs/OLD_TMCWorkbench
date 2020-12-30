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
    public partial class HistoryTextBoxStateControl : UserControl
    {
        public void Clear()
        {
            TextOrg = string.Empty;
            TextNew = string.Empty;
        }

        public string TextOrg
        {
            get => txtOld.Text;
            set => txtOld.Text = value;
        }

        public string TextNew
        {
            get => txtNew.Text;
            set => txtNew.Text = value;
        }

        public HistoryTextBoxStateControl()
        {
            InitializeComponent();

            ShowNew();
        }

        public void ShowNew()
        {
            txtOld.Visible = false;
            txtNew.Visible = true;
            txtNew.Dock = DockStyle.Fill;
        }

        public void ShowOld()
        {
            txtNew.Visible = false;
            txtOld.Visible = true;
            txtOld.Dock = DockStyle.Fill;
        }
    }
}
