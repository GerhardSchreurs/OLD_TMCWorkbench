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
    public partial class ResettableTextControl : _ResettableControlPanel
    {
        public ResettableTextControl()
        {
            InitializeComponent();

            this.resettableControl1.OnReset += ResettableControl1_OnReset;
        }

        public void SwitchMode()
        {
            if (this.txtText.ForeColor == SystemColors.WindowText)
            {
                this.txtText.ForeColor = Color.DarkSlateGray;
            }
            else
            {
                this.txtText.ForeColor = SystemColors.WindowText;
            }
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

        public override string Text
        {
            get { 
                return txtText.Text;  
            }
            set {
                this.resettableControl1.ResetToolTip();
                _text = value;
                this.txtText.Text = value;
            }
        }

        private string _original;
        private string _text;

        public string Original
        {
            get
            {
                return _original;
            }
            set
            {
                _original = value;
                this.resettableControl1.SetToolTip(value, _text);
            }
        }

        private void ResettableControl1_OnReset(object sender, EventArgs e)
        {
            Text = _original;
        }
    }
}
