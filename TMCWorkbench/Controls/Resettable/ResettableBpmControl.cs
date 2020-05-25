using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableBpmControl : _ResettableControlPanel
    {
        public ResettableBpmControl()
        {
            InitializeComponent();

            this.txtBPM.KeyPress += Handle_textBox_KeyPress;
            this.btnPlus.Click += Handle_BtnPlus_Click;
            this.btnMin.Click += Handle_BtnMin_Click;
        }

        private void Handle_BtnPlus_Click(object sender, EventArgs e)
        {
            this.txtBPM.Text = (txtBPM.Text.ToInt() * 2).ToString();
        }

        private void Handle_BtnMin_Click(object sender, EventArgs e)
        {
            this.txtBPM.Text = (txtBPM.Text.ToInt() / 2).ToString();
        }

        public override string LabelTitle
        {
            get => base.LabelTitle;
            set
            {
                base.LabelTitle = value;
                this.resettableControl1.Title = value;
            }
        }

        private void Handle_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private int _bpm;

        public int BPM
        {
            get { return _bpm; }
            set
            {
                _bpm = value;
                txtBPM.Text = value.ToString();
            }
        }
    }
}
