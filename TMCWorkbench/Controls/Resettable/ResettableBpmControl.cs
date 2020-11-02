using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench;

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
            this.resettableControl1.OnReset += Handle_ResettableControl1_OnReset;
        }

        private void Handle_ResettableControl1_OnReset(object sender, EventArgs e)
        {
            UpdateUI(_bpmOriginal);
        }

        private void Handle_BtnPlus_Click(object sender, EventArgs e)
        {
            this.txtBPM.Text = (txtBPM.Text.ToInt() * 2).ToStr();
        }

        private void Handle_BtnMin_Click(object sender, EventArgs e)
        {
            this.txtBPM.Text = (txtBPM.Text.ToInt() / 2).ToStr();
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

        private void UpdateUI(int bpm)
        {
            txtBPM.Text = bpm.ToStr();
        }

        public void SetValue(int bpm)
        {
            this.resettableControl1.ResetToolTip();
            BPM = bpm;

            UpdateUI(bpm);
        }

        public void SetValueOriginal(int bpm)
        {
            _bpmOriginal = bpm;

            this.resettableControl1.SetToolTip(bpm.ToStr(), BPM.ToStr());
        }

        private int _bpmOriginal;

        public int BPM
        {
            get; private set;
            //set
            //{
            //    _bpm = value;
            //    txtBPM.Text = value.ToStr();
            //}
        }
    }
}
