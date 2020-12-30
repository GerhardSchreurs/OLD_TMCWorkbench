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
    public partial class TextAreaStateControl : UserControl
    {
        public void Clear()
        {
            TextOrg = string.Empty;
            TextNew = string.Empty;
        }

        public string TextOrg 
        {
            get => txtOrg.Text;
            set => txtOrg.Text = value;
        }

        public string TextNew
        {
            get => txtNew.Text;
            set => txtNew.Text = value;
        }

        public TextAreaStateControl()
        {
            InitializeComponent();

            ShowNew();
        }

        public void Show(bool showNew = true)
        {
            if (showNew)
                ShowNew();
            else
                ShowOld();
        }

        public void ShowNew()
        {
            txtOrg.Visible = false;
            txtNew.Visible = true;
            txtNew.Dock = DockStyle.Fill;
        }

        public void ShowOld()
        {
            txtNew.Visible = false;
            txtOrg.Visible = true;
            txtOrg.Dock = DockStyle.Fill;
        }
    }
}
